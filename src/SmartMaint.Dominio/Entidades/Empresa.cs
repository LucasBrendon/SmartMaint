namespace SmartMaint.Dominio.Entidades
{
    public class Empresa : EntidadeBase
    {
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public string Cpf { get; private set; }
        public string Telefone { get; private set; }
        public string Celular { get; private set; }
        public string Email { get; private set; }
        public bool Ativa { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }
        public string NumeroEndereco { get; private set; }
        public string ComplementoEndereco { get; private set; }
        public long EnderecoId { get; private set; }
        public Endereco Endereco { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public List<Perfil> Perfis { get; set; }

        protected Empresa()
        {
            Usuarios = new List<Usuario>();
            Perfis = new List<Perfil>();
        }

        public Empresa(string nome,
                       string cnpj,
                       string cpf,
                       string telefone,
                       string celular,
                       string email,
                       string numeroEndereco,
                       string complementoEndereco,
                       Endereco endereco)
        {
            Nome = nome;
            Cnpj = cnpj;
            Cpf = cpf;
            Telefone = telefone;
            Celular = celular;
            Email = email;
            Ativa = true;
            DataCadastro = DateTime.Now;
            NumeroEndereco = numeroEndereco;
            ComplementoEndereco = complementoEndereco;
            Endereco = endereco;
            Usuarios = new List<Usuario>();
        }

        public void VincularUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }

        public void Atualizar(string nome, string cnpj, string cpf, string telefone, string celular, string email, bool ativa)
        {
            Nome = nome;
            Cnpj = cnpj;
            Cpf = cpf;
            Telefone = telefone;
            Celular = celular;
            Email = email;
            Ativa = ativa;
            DataAtualizacao = DateTime.Now;
        }

        public void Ativar()
        {
            Ativa = true;
            DataAtualizacao = DateTime.Now;
        }

        public void Desativar()
        {
            Ativa = false;
            DataAtualizacao = DateTime.Now;
        }
    }
}
