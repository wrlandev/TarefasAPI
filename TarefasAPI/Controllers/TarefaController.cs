using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TarefasAPI.Models;
using TarefasAPI.Repositorios.Interfaces;

namespace TarefasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefa _itarefa;
        public TarefaController(ITarefa tareafa)
        {
            _itarefa = tareafa;
        }


        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> BuscarTarefas()
        {
            List<TarefaModel> tarefas = await _itarefa.BuscarTarefas();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarPorId(int id)
        {
            TarefaModel tarefas = await _itarefa.BuscarPorId(id);
            return Ok(tarefas);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefas = await _itarefa.Adicionar(tarefaModel);

            return Ok(tarefas);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id = id;
            TarefaModel tarefa = await _itarefa.Atualizar(tarefaModel, id);

            return Ok(tarefa);
        }

        [HttpDelete]
        public async Task<ActionResult<TarefaModel>> Apagar(int id)
        {
            bool apagado = await _itarefa.Apagar(id);

            return Ok(apagado);
        }
    }
}