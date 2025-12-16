using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.DataAccess.Entity
{
    public class SampleAppDbContext : DbContext
    {
        public SampleAppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Child> Child { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Parent> Parents { get; set; }
    }
}
