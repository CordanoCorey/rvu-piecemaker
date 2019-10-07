using RvuPiecemaker.Entities.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Users
{
  public interface IUsersService
  {
    IEnumerable<UserModel> GetUsers();
    UserModel GetUser(int id);
    UserModel InsertUser(UserModel model);
    UserModel UpdateUser(UserModel model);
    void DeleteUser(int id);
    UserModel GetUserModelFromUser(ApplicationUser user);
  }

  public class UsersService : IUsersService
  {
    private readonly IUsersRepository _repo;

    public UsersService(IUsersRepository repo)
    {
      _repo = repo;
    }

    public void DeleteUser(int id)
    {
      _repo.Delete(id);
    }
    public UserModel GetUserModelFromUser(ApplicationUser user)
    {
      return new UserModel()
      {
        Id = user.Id,
        Email = user.Email,
        FirstName = user.FirstName,
        LastName = user.LastName,
        PasswordResetCode = user.PasswordResetCode
      };
    }

    public UserModel GetUser(int id)
    {
      return _repo.FindByKey(id);
    }

    public IEnumerable<UserModel> GetUsers()
    {
      return _repo.All();
    }

    public UserModel InsertUser(UserModel model)
    {
      var inserted = _repo.Insert(model);
      return GetUser(inserted.Id);
    }

    public UserModel UpdateUser(UserModel model)
    {
      var updated = _repo.Update(model);
      return GetUser(updated.Id);
    }
  }
}
