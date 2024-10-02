using SmartMaint.Aplicacao.Interfaces.Persistencia;

namespace SmartMaint.Persistencia.Contexto
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EscritaDbContexto _escritaDbContexto;

        public UnitOfWork(EscritaDbContexto escritaDbContexto)
        {
            _escritaDbContexto = escritaDbContexto;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            using var transaction = await _escritaDbContexto.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var result = await _escritaDbContexto.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return result;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}
