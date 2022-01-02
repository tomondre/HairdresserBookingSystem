using API.Controllers;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess
{
    public class HairdresserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Hairdresser");
        }
    }
}