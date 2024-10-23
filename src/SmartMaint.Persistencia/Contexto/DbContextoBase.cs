using Microsoft.EntityFrameworkCore;
using SmartMaint.Dominio.Entidades;
using SmartMaint.Persistencia.Interfaces;
using System.Reflection;

namespace SmartMaint.Persistencia.Contexto
{
    public abstract class DbContextoBase : DbContext, IAplicacaoDbContexto
    {
        public DbContextoBase(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
