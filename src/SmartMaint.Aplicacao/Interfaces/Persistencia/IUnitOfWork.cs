namespace SmartMaint.Aplicacao.Interfaces.Persistencia
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
