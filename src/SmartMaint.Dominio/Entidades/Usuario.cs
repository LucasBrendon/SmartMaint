namespace SmartMaint.Dominio.Entidades
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }
        public long PerfilId { get; private set; }
        public Perfil Perfil { get; set; }
        public List<Empresa> Empresas { get; set; }

        protected Usuario()
        {
            Empresas = new List<Empresa>();
        }

        public Usuario(string nome, string email, string senha, Perfil perfil)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Ativo = true;
            DataCadastro = DateTime.UtcNow;
            Perfil = perfil;
        }

        public void Atualizar(string nome, string email, string senha, bool ativo, Perfil perfil)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Ativo = ativo;
            Perfil = perfil;
            DataAtualizacao = DateTime.UtcNow;
        }
    }
}
