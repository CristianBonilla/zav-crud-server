using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Crud.Domain
{
    public partial class CrudContext : DbContext
    {
        readonly Assembly assembly;
        public DbSet<VisitaEntity> Visitas { get; set; }

        public CrudContext(DbContextOptions<CrudContext> contextOptions) : base(contextOptions) =>
            assembly = Assembly.GetExecutingAssembly();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfiguration(new VisitaConfig());
            // string[] types = assembly.GetTypes()
            //     .Select(t => t.FullName)
            //     .ToArray();
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
