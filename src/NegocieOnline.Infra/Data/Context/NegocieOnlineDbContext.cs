using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using NegocieOnline.Business.Models.Cep;
using NegocieOnline.Infra.Data.Mappings;

namespace NegocieOnline.Infra.Data
{
    public class NegocieOnlineDbContext : DbContext
    {
        public NegocieOnlineDbContext() : base("postgresConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Cep> Ceps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            modelBuilder.Properties<string>()
                .Configure(p=>p
                    .HasColumnType("varchar")
                    .HasMaxLength(100));

            modelBuilder.Configurations.Add(new CepConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}