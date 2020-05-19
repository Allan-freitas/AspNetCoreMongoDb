using Angular.Aplicacao.DTO.Usuarios;
using Angular.Aplicacao.Interfaces.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Angular.Servico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        readonly IAplicacaoUsuario _aplicacaoUsuario;

        public UsuarioController(IAplicacaoUsuario aplicacaoUsuario)
        {
            _aplicacaoUsuario = aplicacaoUsuario;
        }

        [HttpGet]
        [Route("Usuarios")]
        public IActionResult Usuarios()
        {
            return Ok(_aplicacaoUsuario.AsQueryable());
        }

        [HttpGet("{id}")]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Ok(await _aplicacaoUsuario.GetUser(id));
            else
                return Ok("O parâmetro está faltando...");
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            return Ok(_aplicacaoUsuario.GetUsers());
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
                return StatusCode(StatusCodes.Status406NotAcceptable);
            else
            {
                _aplicacaoUsuario.InsertOne(usuarioDTO);
                return StatusCode(StatusCodes.Status201Created);
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
                return StatusCode(StatusCodes.Status406NotAcceptable);
            else
            {
                _aplicacaoUsuario.ReplaceOne(usuarioDTO);
                return StatusCode(StatusCodes.Status201Created);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                _aplicacaoUsuario.DeleteByIdAsync(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            else
                return StatusCode(StatusCodes.Status406NotAcceptable);
        }
    }
}