using DatingApi.Models;
using System.Collections.Generic;

namespace DatingApi.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<AppUser> GetAllUsers();
        AppUser GetUserById(int id);
    }
}
