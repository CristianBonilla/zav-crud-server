using Microsoft.EntityFrameworkCore;

namespace Crud.Domain
{
    public partial class CrudContext : DbContext
    {
        public DbSet<VisitaEntity> Visitas { get; set; }

        public CrudContext(DbContextOptions<CrudContext> contextOptions) : base(contextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new VisitaConfig());
            // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
