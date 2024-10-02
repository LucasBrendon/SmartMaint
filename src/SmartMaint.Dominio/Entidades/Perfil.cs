using SmartMaint.Compartilhado.Enums;

namespace SmartMaint.Dominio.Entidades
{
    public class Perfil : EntidadeBase
    {
        public string Nome { get; set; }
        public ETipoPerfil TipoPerfil { get; set; }
        public ETipoAcaoPerfil[] TipoAcoesPerfil { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public long EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public List<Usuario> Usuarios { get; set; }

        protected Perfil()
        {
            Usuarios = new List<Usuario>();
        }

        public Perfil(string nome, ETipoPerfil tipoPerfil, ETipoAcaoPerfil[] tipoAcoesPerfil, Empresa empresa)
        {
            Nome = nome;
            TipoPerfil = tipoPerfil;
            TipoAcoesPerfil = tipoAcoesPerfil;
            Ativo = true;
            DataCadastro = DateTime.Now;
            Empresa = empresa;
        }

        public void Atualizar(string nome, ETipoPerfil tipoPerfil, ETipoAcaoPerfil[] tipoAcoesPerfil, bool ativo)
        {
            Nome = nome;
            TipoPerfil = tipoPerfil;
            TipoAcoesPerfil = tipoAcoesPerfil;
            Ativo = ativo;
            DataAtualizacao = DateTime.Now;
        }
    }
}
