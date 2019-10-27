using HW7.Models;
using Microsoft.EntityFrameworkCore;

namespace HW7.DataAccess
{
    public class Context : DbContext
    {
        private readonly string connectionString;

        public Context(string connectionString)
        {
            this.connectionString = connectionString;
            Database.EnsureCreated();
        }

        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<User> Users { get; set; }
        // и точно такие же другие сущности

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
