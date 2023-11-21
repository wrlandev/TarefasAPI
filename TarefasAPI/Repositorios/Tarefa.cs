using Microsoft.EntityFrameworkCore;
using TarefasAPI.Data;
using TarefasAPI.Models;
using TarefasAPI.Repositorios.Interfaces;

namespace TarefasAPI.Repositorios
{
    public class Tarefa : ITarefa
    {
        private readonly TarefasDBContext _context;
        public Tarefa(TarefasDBContext context)
        {
            _context = context;
        }
        public async Task<TarefaModel> Adicionar(TarefaModel tarefa) { 
            await _context.Tarefas.AddAsync(tarefa);
            _context.SaveChanges();

            return tarefa;
        }

        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception("Tarefa não foi encontrado");
            }

            _context.Tarefas.Remove(tarefaPorId);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception("Tarefa não foi encontrada");
            }

            tarefaPorId.Nome = tarefa.Nome;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;


            _context.Tarefas.Update(tarefaPorId);
            await _context.SaveChangesAsync();

            return tarefaPorId;
        }

        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _context.Tarefas.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> BuscarTarefas()
        {
            return await _context.Tarefas.Include(x => x.Usuario).ToListAsync();
        }
    }
}
