using Microsoft.EntityFrameworkCore;
using User.API.Models;

namespace User.API.Data.DbContexts
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public DbSet<UserModel>Users { get; set; }
    }
}
