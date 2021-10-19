using Microsoft.EntityFrameworkCore;
using RecordsModel.Model;

namespace RecordsModel
{
    public class ApplicationDBContext : DbContext
    {
        public static string _ConnectionString { get; set; }
        public DbSet<CompanyRecord> CompanyRecords { get; set; }
        public DbSet<User> Users { get; set; }


        public ApplicationDBContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CompanyRecord>().Property(p => p.Id);
            builder.Entity<User>().Property(p => p.Id);

        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
    }
}
