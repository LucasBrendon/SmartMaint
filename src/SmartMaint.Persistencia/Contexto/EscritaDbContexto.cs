using Microsoft.EntityFrameworkCore;
using SmartMaint.Persistencia.Interfaces;

namespace SmartMaint.Persistencia.Contexto
{
    public class EscritaDbContexto : DbContextoBase, IEscritaDbContexto
    {
        public EscritaDbContexto(DbContextOptions<EscritaDbContexto> options) : base(options)
        {
        }
    }
}
