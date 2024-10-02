using System.ComponentModel;

namespace SmartMaint.Compartilhado.Enums
{
    public enum ETipoAcaoPerfil
    {
        [Description("Criar")]
        CRIAR = 1,
        [Description("Editar")]
        EDITAR = 2,
        [Description("Deletar")]
        DELETAR = 3,
        [Description("Visualizar")]
        VISUALIZAR = 4
    }
}
