using System.ComponentModel;

namespace SmartMaint.Compartilhado.Enums
{
    public enum ETipoPerfil
    {
        [Description("Master")]
        MASTER = 1,
        [Description("Administrador")]
        ADMINISTRADOR = 2,
        [Description("Comum")]
        COMUM = 3
    }
}
