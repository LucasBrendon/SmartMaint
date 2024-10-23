using Microsoft.EntityFrameworkCore;
using SmartMaint.Dominio.Entidades;

namespace SmartMaint.Persistencia.Interfaces
{
    public interface IAplicacaoDbContexto
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }

        public int SaveChanges();
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
