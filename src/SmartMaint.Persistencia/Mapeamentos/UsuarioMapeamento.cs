using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartMaint.Dominio.Entidades;

namespace SmartMaint.Persistencia.Mapeamentos
{
    public class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("Usr_Id");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Usr_Nome")
                .HasColumnType("varchar(255)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Usr_Email")
                .HasColumnType("varchar(255)");

            builder.Property(x => x.Senha)
                .IsRequired()
                .HasColumnName("Usr_Senha")
                .HasColumnType("varchar(32)");

            builder.Property(x => x.Ativo)
                .IsRequired()
                .HasColumnName("Usr_Ativo");

            builder.Property(x => x.DataCadastro)
                .IsRequired()
                .HasColumnName("Usr_DataCadastro");

            builder.Property(x => x.DataAtualizacao)
                .IsRequired(false)
                .HasColumnName("Usr_DataAtualizacao");

            builder.Property(x => x.PerfilId)
                .IsRequired()
                .HasColumnName("Usr_Perfil_Id");

            builder.HasOne(x => x.Perfil)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.PerfilId);
        }
    }
}
