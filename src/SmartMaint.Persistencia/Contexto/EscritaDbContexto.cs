using Microsoft.EntityFrameworkCore;
using SmartMaint.Aplicacao.Interfaces.Persistencia;
using SmartMaint.Dominio.Entidades;

namespace SmartMaint.Persistencia.Contexto
{
    public class EscritaDbContexto : DbContext, IEscritaDbContexto
    {
        public EscritaDbContexto(DbContextOptions<EscritaDbContexto> options) : base(options)
        {
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
    }
}
