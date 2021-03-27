using DatingApi.Data;
using DatingApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace DatingApi.Repositories
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public SqlUserRepository(UserContext context)
        {
            _context = context;
        }
        public IEnumerable<AppUser> GetAllUsers()
        {
            return _context.Users.ToList();
        }
        public AppUser GetUserById(int id)
        {
            return _context.Users.SingleOrDefault(a => a.Id == id);
        }
        public AppUser GetUserByUsername(string username)
        {
            return _context.Users.SingleOrDefault(u => u.Username == username);
        }
        public void Create(AppUser user)
        {
            _context.Users.Add(user);
        }
        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
        public bool UserExists(string username)
        {
            return _context.Users.Any(u => u.Username == username.ToLower());
        }

    }
}
