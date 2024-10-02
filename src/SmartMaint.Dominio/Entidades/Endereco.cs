namespace SmartMaint.Dominio.Entidades
{
    public class Endereco : EntidadeBase
    {
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Localidade { get; private set; }
        public string Uf { get; private set; }
        public List<Empresa> Empresas { get; set; }

        protected Endereco()
        {
            Empresas = new List<Empresa>();
        }

        public Endereco(string cep, string logradouro, string bairro, string localidade, string uf)
        {
            Cep = cep;
            Logradouro = logradouro;
            Bairro = bairro;
            Localidade = localidade;
            Uf = uf;
        }
    }
}
