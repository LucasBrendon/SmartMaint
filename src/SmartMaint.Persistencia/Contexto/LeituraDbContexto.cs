using Microsoft.EntityFrameworkCore;
using SmartMaint.Persistencia.Interfaces;

namespace SmartMaint.Persistencia.Contexto
{
    public class LeituraDbContexto : DbContextoBase, ILeituraDbContexto
    {
        public LeituraDbContexto(DbContextOptions<LeituraDbContexto> options) : base(options)
        {
        }
    }
}
