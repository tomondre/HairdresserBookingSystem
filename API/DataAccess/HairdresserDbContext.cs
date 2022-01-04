using API.Controllers;
using API.Models;
using Client.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace API.DataAccess
{
    public class HairdresserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CompanyOwner> CompanyOwners { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<WorkingDay> WorkingDays { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Hairdresser");
        }
    }
}