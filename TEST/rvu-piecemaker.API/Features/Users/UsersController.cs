using CAIU.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RvuPiecemaker.Entities.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Users
{
  [Route("api/users")]
  public class UsersController : BaseController
  {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IUsersService _service;
    public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUsersService service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Get(_service.GetUsers);
    }

    [HttpGet("current")]
    public IActionResult GetCurrentUser()
    {
      return Get(_service.GetUser, UserId);
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
      return Get(_service.GetUser, id);
    }

    [HttpPost]
    // [Authorize(Policy = "Administrator")]
    public async Task<UserModel> CreateUser([FromBody]UserModel model)
    {

      var user = new ApplicationUser();
      user.UserName = model.Email;
      user.FirstName = model.FirstName;
      user.LastName = model.LastName;
      user.Email = model.Email;

      var newUser = await _userManager.CreateAsync(user, model.Password);

      if (newUser.Succeeded)
      {
        //_userService.SaveRoles(user.Id, model);

        string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        IdentityResult passwordChangeResult = await _userManager.ResetPasswordAsync(user, resetToken, model.Password);
      }

      var u = _service.GetUserModelFromUser(user);
      return u;
    }
  }
}
