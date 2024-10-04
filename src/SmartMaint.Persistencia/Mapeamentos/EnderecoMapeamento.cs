using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartMaint.Dominio.Entidades;

namespace SmartMaint.Persistencia.Mapeamentos
{
    public class EnderecoMapeamento : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("End_Id");

            builder.Property(x => x.Cep)
                .IsRequired()
                .HasColumnName("End_Cep")
                .HasColumnType("varchar(10)");

            builder.Property(x => x.Logradouro)
                .IsRequired()
                .HasColumnName("End_Logradouro")
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Bairro)
                .IsRequired()
                .HasColumnName("End_Bairro")
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Localidade)
                .IsRequired()
                .HasColumnName("End_Localidade")
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Uf)
                .IsRequired()
                .HasColumnName("End_Uf")
                .HasColumnType("varchar(2)");
        }
    }
}
