using Angular.Aplicacao.DTO.Usuarios;
using Angular.Aplicacao.Interfaces.Authorities;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Servico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IAplicacaoAuthorities _aplicacaoAuthorities;
        readonly IMapper _mapper;
        readonly IConfiguration _config;

        public AuthController(IAplicacaoAuthorities aplicacaoAuthorities, IMapper mapper, IConfiguration config)
        {
            _aplicacaoAuthorities = aplicacaoAuthorities;
            _mapper = mapper;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDTO userForRegisterDto)
        {
            try
            {
                userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

                ValidationResult validationResult = await _aplicacaoAuthorities.Validate(userForRegisterDto);
                if (!validationResult.IsValid)
                    return StatusCode(StatusCodes.Status500InternalServerError, validationResult.Errors);

                if (await _aplicacaoAuthorities.UserExists(userForRegisterDto.Username))
                    return BadRequest("Username already exists");

                UsuarioDTO userToCreate = _mapper.Map<UsuarioDTO>(userForRegisterDto);

                UsuarioDTO createdUser = await _aplicacaoAuthorities.Register(userToCreate, userForRegisterDto.Password);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserForRegisterDTO userForRegisterDto)
        {
            ValidationResult validationResult = await _aplicacaoAuthorities.Validate(userForRegisterDto);
            if (!validationResult.IsValid)
                return StatusCode(StatusCodes.Status500InternalServerError, validationResult.Errors);

            UsuarioDTO usuarioDTO = await _aplicacaoAuthorities.Login(userForRegisterDto.Username.ToLower(), userForRegisterDto.Password);

            if (usuarioDTO == null)
                return Unauthorized();

            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuarioDTO.Id.ToString()),
                new Claim(ClaimTypes.Name, usuarioDTO.Username)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            UserForRegisterDTO user = _mapper.Map<UserForRegisterDTO>(usuarioDTO);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                user
            });
        }
    }
}