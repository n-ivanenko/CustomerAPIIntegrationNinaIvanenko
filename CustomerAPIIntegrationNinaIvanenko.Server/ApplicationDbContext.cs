using Microsoft.EntityFrameworkCore;
using CustomerAPIIntegration.Models;

namespace DBTest.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
           base(options)
        { }
        public DbSet<CustomerAPIIntegration.Models.Customer> Customer { get; set; } = default!;
        public DbSet<CustomerAPIIntegration.Models.CallAttempt> CallAttempt { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 001, Name = "Harry Styles", PhoneNumber = "1234567890", Email = "harrystyles@gmail.com" },
                new Customer { CustomerId = 002, Name = "Zayn Malik", PhoneNumber = "9876543210", Email = "zaynmalik@hotmail.com" }
            );

            modelBuilder.Entity<CallAttempt>().HasData(
                new CallAttempt { Id = 001, CustomerId = 001, Date = DateTime.Now, Notes = "Left a voicemail" },
                new CallAttempt { Id = 002, CustomerId = 002, Date = DateTime.Now, Notes = "Spoke with customer" }
            );
        }
    }
}