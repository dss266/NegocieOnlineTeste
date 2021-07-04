using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Text;
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

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }

    }

    public class FormattedDbEntityValidationException : Exception
    {
        public FormattedDbEntityValidationException(DbEntityValidationException innerException) :
            base(null, innerException)
        {
        }

        public override string Message
        {
            get
            {
                var innerException = InnerException as DbEntityValidationException;
                if (innerException != null)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine();
                    sb.AppendLine();
                    foreach (var eve in innerException.EntityValidationErrors)
                    {
                        sb.AppendLine(string.Format("- Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().FullName, eve.Entry.State));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            sb.AppendLine(string.Format("-- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage));
                        }
                    }
                    sb.AppendLine();

                    return sb.ToString();
                }

                return base.Message;
            }
        }
    }
}