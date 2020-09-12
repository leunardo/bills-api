using infrastructure.records;
using Microsoft.EntityFrameworkCore;

namespace infrastructure
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<BillRecord> Bills { get; set; }
        public DbSet<BusinessRuleRecord> BusinessRules { get; set; }

        public DbContext()
        {
            Database.EnsureCreated();
        }

        ~DbContext()
        {
            Database.EnsureDeleted();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source=bills.db");
    }
}