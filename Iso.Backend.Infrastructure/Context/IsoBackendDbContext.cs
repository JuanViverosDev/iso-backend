using Iso.Backend.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace Iso.Backend.Infrastructure.Context
{
    public class IsoBackendDbContext : DbContext
    {

        #region Auth Domain
        
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        
        #endregion Auth Domain

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