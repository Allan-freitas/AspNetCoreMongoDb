using Angular.Aplicacao.DTO.Usuarios;
using Angular.Dominio.Entidades.Usuarios;
using Angular.Dominio.Interfaces.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Angular.Servico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        readonly IServicoUsuario _servicoUsuario;

        public UsuarioController(IServicoUsuario servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }

        [HttpGet]
        [Route("Usuarios")]
        public IActionResult Usuarios()
        {
            return Ok(_servicoUsuario.AsQueryable());
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
                return StatusCode(StatusCodes.Status406NotAcceptable);
            else
            {
                _servicoUsuario.InsertOne(new Usuario(usuarioDTO.Id, usuarioDTO.Nome, usuarioDTO.SobreNome, usuarioDTO.Email));
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
                _servicoUsuario.ReplaceOne(new Usuario(usuarioDTO.Id, usuarioDTO.Nome, usuarioDTO.SobreNome, usuarioDTO.Email));
                return StatusCode(StatusCodes.Status201Created);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                _servicoUsuario.DeleteByIdAsync(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            else
                return StatusCode(StatusCodes.Status406NotAcceptable);
        }
    }
}