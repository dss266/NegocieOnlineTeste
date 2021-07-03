using System.Data.Entity;
using NegocieOnline.Business.Models.Cep;
using NegocieOnline.Infra.Data.Mappings;

namespace NegocieOnline.Infra.Data
{
    public class NegocieOnlineDbContext : DbContext
    {
        public NegocieOnlineDbContext(): base("postgresConnection")
        { }

        public DbSet<Cep> Ceps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CepConfig());
        }
    }
}