using System.ComponentModel;

namespace TarefasAPI.Enum
{
    public enum TarefasEnum
    {
        [Description("A Fazer")]
        AFazer = 1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Concluído")]
        Concluido = 3
    }
}
