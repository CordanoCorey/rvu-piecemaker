using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RvuPiecemaker.API.Features.Shifts;
using RvuPiecemaker.API.Features.Users;
using RvuPiecemaker.Entities.DataClasses;

namespace RvuPiecemaker.API.Infrastructure.Authentication
{
  /// <summary>
  /// Token generator middleware component which is added to an HTTP pipeline.
  /// This class is not created by application code directly,
  /// instead it is added by calling the <see cref="TokenProviderAppBuilderExtensions.UseSimpleTokenProvider(Microsoft.AspNetCore.Builder.IApplicationBuilder, TokenProviderOptions)"/>
  /// extension method.
  /// </summary>
  public class TokenProviderMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly TokenProviderOptions _options;
    private readonly ILogger _logger;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JsonSerializerSettings _serializerSettings;
    private readonly IMapper _mapper;

    public TokenProviderMiddleware(
        RequestDelegate next,
        IOptions<TokenProviderOptions> options,
        SignInManager<ApplicationUser> sim,
        UserManager<ApplicationUser> um,
        ILoggerFactory loggerFactory,
        IMapper mapper)
    {
      _next = next;
      _signInManager = sim;
      _userManager = um;
      _logger = loggerFactory.CreateLogger<TokenProviderMiddleware>();
      _mapper = mapper;

      _options = options.Value;
      ThrowIfInvalidOptions(_options);

      _serializerSettings = new JsonSerializerSettings
      {
        Formatting = Formatting.Indented,
        ContractResolver = new CamelCasePropertyNamesContractResolver()
      };
    }

    public Task Invoke(HttpContext context)
    {
      // If the request path doesn't match, skip
      if (!context.Request.Path.Equals(_options.Path, StringComparison.Ordinal))
      {
        return _next(context);
      }

      // Request must be POST with Content-Type: application/x-www-form-urlencoded
      if (!context.Request.Method.Equals("POST")
         || !context.Request.HasFormContentType)
      {
        context.Response.StatusCode = 400;
        return context.Response.WriteAsync("Bad request.");
      }

      _logger.LogInformation("Handling token request: " + context.Request.Path);

      return GenerateToken(context);
    }

    private async Task GenerateToken(HttpContext context)
    {
      var email = context.Request.Form["email"];
      var password = context.Request.Form["password"];
      var userId = 0;

      var signInResult = await _signInManager.PasswordSignInAsync(email, password, true, false);
      List<Claim> userclaims = new List<Claim>();
      if (signInResult.Succeeded)
      {
        var user = await _userManager.FindByEmailAsync(email);
        userId = user.Id;

        var umClaims = await _userManager.GetClaimsAsync(user);
        userclaims.AddRange(umClaims);
        if (userclaims.All(x => x.Type != "firstName"))
          userclaims.Add(new Claim("firstName", user.FirstName));
        if (userclaims.All(x => x.Type != "lastName"))
          userclaims.Add(new Claim("lastName", user.LastName));
        if (userclaims.All(x => x.Type != "email"))
          userclaims.Add(new Claim("email", user.Email));
        /*  sign in manager confirms the pw is good
         *  usermanager grabs the user and the claims
         *  claims are shoved into jwt later
         */
      }
      else
      {
        var err_response = new
        {
          statusCode = 400,
          message = "Invalid email or password."
        };
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync(JsonConvert.SerializeObject(err_response, _serializerSettings));
        return;
      }

      var now = DateTime.UtcNow;

      // Specifically add the jti (nonce), iat (issued timestamp), and sub (subject/user) claims.
      // You can add other claims here, if you want:
      var jwtclaims = new Claim[]
      {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, await _options.NonceGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(now).ToString(), ClaimValueTypes.Integer64)
      };
      userclaims.AddRange(jwtclaims);
      userclaims.Add(new Claim("UserId", userId.ToString()));

      // Create the JWT and write it to a string
      var jwt = new JwtSecurityToken(
          issuer: _options.Issuer,
          audience: _options.Audience,
          claims: userclaims,
          notBefore: now,
          expires: now.Add(_options.Expiration),
          signingCredentials: _options.SigningCredentials);

      //convert role claims to roles object on jwt payload
      List<ApplicationRole> roles = new List<ApplicationRole>();
      List<string> roleNames = new List<string>
            {
                "PublicUser",
                "DistrictUser",
                "DistrictApprover",
                "HospitalUser",
                "PortalAdmin",
            };
      foreach (var claim in userclaims)
      {
        if (!roleNames.Contains(claim.Type)) continue;
        //TODO: Finish once roles are solidified.
        //roles.Add(ReferralPortalRole.GetRoleFromClaim(claim));
      }

      jwt.Payload.Add("roles", roles);

      var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

      var response = new
      {
        access_token = encodedJwt,
        expires_in = (int)_options.Expiration.TotalSeconds,
        user = _mapper.Map<UserModel>(await _userManager.FindByEmailAsync(email))
      };

      // Serialize and return the response
      context.Response.ContentType = "application/json";
      await context.Response.WriteAsync(JsonConvert.SerializeObject(response, _serializerSettings));
    }

    private static void ThrowIfInvalidOptions(TokenProviderOptions options)
    {
      if (string.IsNullOrEmpty(options.Path))
      {
        throw new ArgumentNullException(nameof(TokenProviderOptions.Path));
      }

      if (string.IsNullOrEmpty(options.Issuer))
      {
        throw new ArgumentNullException(nameof(TokenProviderOptions.Issuer));
      }

      if (string.IsNullOrEmpty(options.Audience))
      {
        throw new ArgumentNullException(nameof(TokenProviderOptions.Audience));
      }

      if (options.Expiration == TimeSpan.Zero)
      {
        throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(TokenProviderOptions.Expiration));
      }

      //implemented custom in GenerateToken
      //if (options.IdentityResolver == null)
      //{
      //    throw new ArgumentNullException(nameof(TokenProviderOptions.IdentityResolver));
      //}

      if (options.SigningCredentials == null)
      {
        throw new ArgumentNullException(nameof(TokenProviderOptions.SigningCredentials));
      }

      if (options.NonceGenerator == null)
      {
        throw new ArgumentNullException(nameof(TokenProviderOptions.NonceGenerator));
      }
    }

    /// <summary>
    /// Get this datetime as a Unix epoch timestamp (seconds since Jan 1, 1970, midnight UTC).
    /// </summary>
    /// <param name="date">The date to convert.</param>
    /// <returns>Seconds since Unix epoch.</returns>
    public static long ToUnixEpochDate(DateTime date)
        => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
  }
}
