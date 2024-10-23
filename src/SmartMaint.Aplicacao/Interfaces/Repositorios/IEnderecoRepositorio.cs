using SmartMaint.Dominio.Entidades;

namespace SmartMaint.Aplicacao.Interfaces.Repositorios
{
    public interface IEnderecoRepositorio
    {
        Task<List<Endereco>> Listar();
        Task<Endereco> ConsultarPorIdTracking(long id);
        Task<Endereco> ConsultarPorCep(string cep);
        Task<Endereco> Criar(Endereco endereco);
        Task<Endereco> Atualizar(Endereco endereco);
    }
}
