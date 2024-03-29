using CustomerBalanceStatus.Models.Entities;
using System.Data.Entity;

namespace CustomerBalanceStatus.Models.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=ConnectionStringName")
        {
            
        }

        public DbSet<MusteriTanim> MusteriTanims { get; set; }
        public DbSet<MusteriFatura> MusteriFaturas { get; set; }

    }
}