using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartMaint.Dominio.Entidades;

namespace SmartMaint.Persistencia.Mapeamentos
{
    public class EmpresaMapeamento : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("Emp_Id");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Emp_Nome")
                .HasColumnType("varchar(255)");

            builder.Property(x => x.Cnpj)
                .IsRequired(false)
                .HasColumnName("Emp_Cnpj")
                .HasColumnType("varchar(14)");

            builder.Property(x => x.Cpf)
                .IsRequired(false)
                .HasColumnName("Emp_Cpf")
                .HasColumnType("varchar(11)");

            builder.Property(x => x.Telefone)
                .IsRequired(false)
                .HasColumnName("Emp_Telefone")
                .HasColumnType("varchar(20)");

            builder.Property(x => x.Celular)
                .IsRequired(false)
                .HasColumnName("Emp_Celular")
                .HasColumnType("varchar(20)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Emp_Email")
                .HasColumnType("varchar(255)");

            builder.Property(x => x.Ativa)
                .IsRequired()
                .HasColumnName("Emp_Ativa");

            builder.Property(x => x.DataCadastro)
                .IsRequired()
                .HasColumnName("Emp_DataCadastro");

            builder.Property(x => x.DataAtualizacao)
                .IsRequired(false)
                .HasColumnName("Emp_DataAtualizacao");

            builder.Property(x => x.NumeroEndereco)
                .IsRequired()
                .HasColumnName("Emp_NumeroEndereco")
                .HasColumnType("varchar(20)");

            builder.Property(x => x.ComplementoEndereco)
                .IsRequired(false)
                .HasColumnName("Emp_ComplementoEndereco")
                .HasColumnType("varchar(255)");

            builder.Property(x => x.EnderecoId)
                .IsRequired()
                .HasColumnName("Emp_Endereco_Id");

            builder.HasMany(x => x.Usuarios)
                   .WithMany(x => x.Empresas)
                   .UsingEntity<Dictionary<string, object>>(
                       "Usuario_Empresa",
                       j => j.HasOne<Usuario>().WithMany().HasForeignKey("Usuario_Id"),
                       j => j.HasOne<Empresa>().WithMany().HasForeignKey("Empresa_Id")
                   );

            builder.HasMany(x => x.Perfis)
                .WithOne(x => x.Empresa)
                .HasForeignKey(x => x.EmpresaId);
        }
    }
}
