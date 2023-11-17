using TarefasAPI.Models;

namespace TarefasAPI.Repositorios.Interfaces
{
    public interface ITarefa
    {
        Task<List<TarefaModel>> BuscarTarefas();
        Task<TarefaModel> BuscarPorId(int id);
        Task<TarefaModel> Adicionar(TarefaModel tarefa);
        Task<TarefaModel> Atualizar(TarefaModel tarefa, int id);
        Task<bool> Apagar(int id);
    }
}
