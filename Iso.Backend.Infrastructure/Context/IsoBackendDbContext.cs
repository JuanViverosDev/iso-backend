using Microsoft.EntityFrameworkCore;

namespace Iso.Backend.Infrastructure.Context
{
    public class IsoBackendDbContext : DbContext
    {


        public IsoBackendDbContext()
        {
        }

        public IsoBackendDbContext(DbContextOptions<IsoBackendDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            base.OnModelCreating(modelBuilder);
        }
    }
}