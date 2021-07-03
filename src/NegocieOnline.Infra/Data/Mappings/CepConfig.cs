using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using NegocieOnline.Business.Models.Cep;

namespace NegocieOnline.Infra.Data.Mappings
{
    public class CepConfig:EntityTypeConfiguration<Cep>
    {
        public CepConfig()
        {
            HasKey(f => f.Id);

            Property(f => f.CEP)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnAnnotation("IX_Cep",
                    new IndexAnnotation(new IndexAttribute{IsUnique = true}))
                .IsFixedLength();

            Property(f => f.Logradouro)
                .IsRequired()
                .HasMaxLength(500);            
            
            Property(f => f.Bairro)
                .IsRequired()
                .HasMaxLength(200);            
            
            Property(f => f.DDD)
                .IsRequired()
                .HasMaxLength(3);            
            
            Property(f => f.Uf)
                .IsRequired()
                .HasMaxLength(2);
            
            Property(f => f.Gia)
                .IsOptional()
                .HasMaxLength(20);            
            
            Property(f => f.Ibge)
                .IsOptional()
                .HasMaxLength(20);
            
            Property(f => f.Siafi)
                .IsOptional()
                .HasMaxLength(20);
            
            Property(f => f.Complemento)
                .IsOptional()
                .HasMaxLength(20);

            ToTable("tb_Cep");

        }
    }
}