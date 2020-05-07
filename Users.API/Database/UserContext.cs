namespace Users.API.Database
{
    using Microsoft.EntityFrameworkCore;
    using Users.API.Models;

    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}