using CustomerBalanceStatus.Models.Entities;
using System.Data.Entity;

namespace CustomerBalanceStatus.Models.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=ConnectionStringName")
        {
            // Database.SetInitializer<AppDbContext>(null); // İlerleyen aşamalarda veritabanı oluşturma stratejisini belirtmek için kullanılabilir
        }

        public DbSet<MusteriTanim> MusteriTanims { get; set; }
        public DbSet<MusteriFatura> MusteriFaturas { get; set; }

    }
}