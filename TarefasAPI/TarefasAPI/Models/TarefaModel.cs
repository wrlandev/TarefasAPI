using TarefasAPI.Enum;

namespace TarefasAPI.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public TarefasEnum Status { get; set; }
    }
}
