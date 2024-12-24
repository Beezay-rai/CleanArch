using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public sealed class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyAppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
