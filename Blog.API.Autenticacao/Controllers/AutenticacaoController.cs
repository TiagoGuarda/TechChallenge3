using Blog.API.Data.Interfaces;
using Blog.API.Data.Models;
using Blog.API.Data.Repositories;
using Blog.API.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Autenticacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly ILogger<AutenticacaoController> _logger;
        private readonly IUsuarioService _usuarioService;
        private readonly ITokenService _tokenService;

        public AutenticacaoController(
            ILogger<AutenticacaoController> logger, 
            IUsuarioService usuarioService,
            ITokenService tokenService
            )
        {
            _logger = logger;
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<dynamic> Autenticar([FromBody] Credencial credencial)
        {
            var usuario = _usuarioService.Obter(credencial.Nome, credencial.Senha);

            if (usuario == null) return NotFound(new { erro = "Usuário e/ou senha inválidos, verifique as credenciais e tente novamente." });

            var token = _tokenService.GerarToken(usuario);

            usuario.Senha = "*";

            return new { usuario = usuario, token = token };
        }
    }
}
