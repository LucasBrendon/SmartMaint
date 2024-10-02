using Microsoft.EntityFrameworkCore;
using SmartMaint.Dominio.Entidades;

namespace SmartMaint.Aplicacao.Interfaces.Persistencia
{
    public interface IEscritaDbContexto
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
    }
}
