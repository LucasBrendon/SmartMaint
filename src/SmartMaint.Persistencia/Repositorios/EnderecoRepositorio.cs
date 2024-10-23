using Microsoft.EntityFrameworkCore;
using SmartMaint.Aplicacao.Interfaces.Repositorios;
using SmartMaint.Dominio.Entidades;
using SmartMaint.Persistencia.Interfaces;

namespace SmartMaint.Persistencia.Repositorios
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private readonly ILeituraDbContexto _leituraDbContexto;
        private readonly IEscritaDbContexto _escritaDbContexto;

        public EnderecoRepositorio(ILeituraDbContexto leituraDbContexto,
                                   IEscritaDbContexto escritaDbContexto)
        {
            _leituraDbContexto = leituraDbContexto;
            _escritaDbContexto = escritaDbContexto;
        }

        public async Task<List<Endereco>> Listar()
        {
            return await _leituraDbContexto.Enderecos.AsNoTracking().ToListAsync();
        }

        public async Task<Endereco> ConsultarPorCep(string cep)
        {
            return await _leituraDbContexto.Enderecos.AsNoTracking().Where(x => x.Cep.Equals(cep)).FirstOrDefaultAsync();
        }

        public async Task<Endereco> ConsultarPorIdTracking(long id)
        {
            return await _leituraDbContexto.Enderecos.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<Endereco> Criar(Endereco endereco)
        {
            _escritaDbContexto.Enderecos.Add(endereco);
            await _escritaDbContexto.SaveChangesAsync();

            return endereco;
        }

        public async Task<Endereco> Atualizar(Endereco endereco)
        {
            _escritaDbContexto.Enderecos.Update(endereco);
            await _escritaDbContexto.SaveChangesAsync();

            return endereco;
        }
    }
}
