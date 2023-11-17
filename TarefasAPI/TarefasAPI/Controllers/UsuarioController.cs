using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TarefasAPI.Models;
using TarefasAPI.Repositorios.Interfaces;

namespace TarefasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _iusuario;
        public UsuarioController(IUsuario iusuario)
        {
            _iusuario = iusuario;
        }


        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarUsuarios()
        {
            List<UsuarioModel> usuarios = await _iusuario.BuscarUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _iusuario.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _iusuario.Adicionar(usuarioModel);

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _iusuario.Atualizar(usuarioModel, id);

            return Ok(usuario);
        }

        [HttpDelete]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            bool apagado = await _iusuario.Apagar(id);

            return Ok(apagado);
        }
    }
}

