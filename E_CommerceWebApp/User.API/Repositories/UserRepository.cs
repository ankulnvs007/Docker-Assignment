using Microsoft.EntityFrameworkCore;
using User.API.Models;
using User.API.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;
using User.API.Data.DbContexts;

namespace User.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return _context.Users.ToList();
        }

        public UserModel GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public UserModel CreateUser(UserModel user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public bool UpdateUser(UserModel user)
        {
            var existingUser = _context.Users.Find(user.UserId);
            if (existingUser == null)
            {
                return false;
            }

            _context.Entry(existingUser).CurrentValues.SetValues(user);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }
    }
}
