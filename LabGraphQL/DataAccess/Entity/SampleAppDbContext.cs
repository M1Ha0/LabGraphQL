using Microsoft.EntityFrameworkCore;

namespace LabGraphQL.DataAccess.Entity
{
    public class SampleAppDbContext : DbContext
    {
        public SampleAppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Parent> Parents { get; set; }
    }
}
