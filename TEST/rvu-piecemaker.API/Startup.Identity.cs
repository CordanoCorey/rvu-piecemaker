using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using RvuPiecemaker.API.Infrastructure.Authentication;
using RvuPiecemaker.Entities.Context;
using RvuPiecemaker.Entities.DataClasses;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RvuPiecemaker.API
{
  public partial class Startup
  {
    public static void ConfigureAuthServices(IConfiguration Configuration, IServiceCollection services)
    {
      var secretKey = Configuration["Auth:SimpleJwt:Secret"];
      var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));


      var tokenValidationParameters = new TokenValidationParameters
      {
        // The signing key must match!
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = signingKey,

        // Validate the JWT Issuer (iss) claim
        ValidateIssuer = true,
        ValidIssuer = Configuration["Auth:SimpleJwt:Issuer"],

        // Validate the JWT Audience (aud) claim
        ValidateAudience = true,
        ValidAudience = Configuration["Auth:SimpleJwt:Audience"],

        // Validate the token expiry
        ValidateLifetime = true,

        // If you want to allow a certain amount of clock drift, set that here:
        ClockSkew = TimeSpan.Zero
      };
      //Auth
      services.AddAuthentication().AddJwtBearer(options =>
      {
        options.IncludeErrorDetails = true;
        options.TokenValidationParameters = tokenValidationParameters;
        options.Events = new JwtBearerEvents
        {
          OnChallenge = context =>
                {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return Task.FromResult(0);
              },
        };
      });

      services.AddDbContext<RvuPiecemakerContext>(options
          => options.UseSqlServer(Configuration.GetConnectionString("rvu")));

      services.AddIdentity<ApplicationUser, ApplicationRole>(opts =>
      {
        opts.Password.RequireDigit = false;
        opts.Password.RequiredLength = 8;
        opts.Password.RequireNonAlphanumeric = false;
        opts.Password.RequireUppercase = false;
        opts.Password.RequireLowercase = false;

        opts.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
        opts.Lockout.MaxFailedAccessAttempts = 30;

        opts.User.RequireUniqueEmail = true;
      })
          .AddEntityFrameworkStores<RvuPiecemakerContext>().AddDefaultTokenProviders();
    }

    public static void ConfigureAuth(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IConfiguration config)
    {

      app.UseAuthentication();
      // Add JWT generation endpoint:
      var secretKey = config["Auth:SimpleJwt:Secret"];
      var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
      var signCreds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
      var options = new TokenProviderOptions
      {
        Path = "/api/token",
        Audience = config["Auth:SimpleJwt:Audience"],
        Issuer = config["Auth:SimpleJwt:Issuer"],
        SigningCredentials = signCreds,
        Expiration = TimeSpan.FromDays(30)
      };
      app.UseSimpleTokenProvider(options);
    }
  }
}
