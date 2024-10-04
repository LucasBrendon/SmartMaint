using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartMaint.Dominio.Entidades;

namespace SmartMaint.Persistencia.Mapeamentos
{
    public class PerfilMapeamento : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("Perfil");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("Perf_Id");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Perf_Nome")
                .HasColumnType("varchar(50)");

            builder.Property(x => x.TipoPerfil)
                .IsRequired()
                .HasColumnName("Perf_TipoPerfil");

            builder.Property(x => x.TipoAcoesPerfil)
                .IsRequired()
                .HasColumnName("Perf_Acoes");

            builder.Property(x => x.Ativo)
                .IsRequired()
                .HasColumnName("Perf_Ativo");

            builder.Property(x => x.DataCadastro)
               .IsRequired()
               .HasColumnName("Usr_DataCadastro");

            builder.Property(x => x.DataAtualizacao)
                .IsRequired(false)
                .HasColumnName("Usr_DataAtualizacao");

            builder.Property(x => x.EmpresaId)
                .IsRequired()
                .HasColumnName("Perf_Empresa_Id");

            builder.HasOne(x => x.Empresa)
                .WithMany(x => x.Perfis)
                .HasForeignKey(x => x.EmpresaId);
        }
    }
}
