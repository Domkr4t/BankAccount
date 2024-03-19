using BankAccount.Backend.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankAccount.Backend.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<PhisycalUserEntity> PhisycalUsers { get; set; }
        public DbSet<LegalUserEntity> LegalUsers { get; set; }  
        public DbSet<AccountEntity> Accounts { get; set; } 
        public DbSet<PaymentEntity> Payments { get; set; } 
        public DbSet<InterestRateEntity> InterestRates { get; set; }

    }

}
