using Blog.API.Data.Models;
using Blog.API.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Gerenciamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GerenciamentoController : ControllerBase
    {
        private readonly ILogger<GerenciamentoController> _logger;
        private readonly INoticiaService _noticiaService;

        public GerenciamentoController(
            ILogger<GerenciamentoController> logger, 
            INoticiaService noticiaService
            )
        {
            _logger = logger;
            _noticiaService = noticiaService;
        }

        [HttpGet]
        [Route("Noticias")]
        [AllowAnonymous]
        public async Task<IEnumerable<Noticia>> ObterTodas()
        {
            return await _noticiaService.ObterTodas();
        }

        [HttpGet]
        [Route("Noticias/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> ObterPorId(int id)
        {
            //Retorna o registro solicitado ou NotFound caso não exista
            var noticia = await _noticiaService.ObterPorId(id);
            
            if (noticia != null)  
                return noticia;

            return NotFound(new { erro = "Registro não encontrado." });
        }

        [HttpPost]
        [Route("Noticias")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Adicionar([FromBody] Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                //Tenta adicionar o registro com as informações fornecidas e retorna mensagem de sucesso ou de falha
                var result = await _noticiaService.Adicionar(noticia);
                
                if (result > 0) 
                    return Ok(new { mensagem = "Registro adicionado com sucesso!" });
            }

            return BadRequest(new { erro = "Não foi possível adicionar o registro solicitado, verifique as informações e tente novamente.", noticia = noticia });
        }

        [HttpPut]
        [Route("Noticias")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Atualizar([FromBody] Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                var noticiaOriginal = await _noticiaService.ObterPorId(noticia.Id);

                if (noticiaOriginal != null)
                {
                    noticiaOriginal.Titulo = noticia.Titulo;
                    noticiaOriginal.Descricao = noticia.Descricao;
                    noticiaOriginal.Conteudo = noticia.Conteudo;
                    noticiaOriginal.DataPublicacao = noticia.DataPublicacao;
                    noticiaOriginal.Autor = noticia.Autor;

                    var result = await _noticiaService.Atualizar(noticiaOriginal);
                    
                    if (result > 0)
                        return Ok(new { mensagem = "Registro atualizado com sucesso!" });
                }
                else
                    return NotFound(new { erro = "Registro não encontrado." });
            }

            return BadRequest(new { erro = "Não foi possível adicionar o registro solicitado, verifique as informações e tente novamente.", noticia = noticia });
        }

        [HttpDelete]
        [Route("Noticias/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Remover(int id)
        {
            if (ModelState.IsValid)
            {
                var noticia = await _noticiaService.ObterPorId(id);

                if (noticia != null)
                {
                    var result = await _noticiaService.Remover(id);
                    
                    if (result > 0)                  
                        return Ok(new { mensagem = "Registro removido com sucesso!" });
                }
                else
                    return NotFound(new { erro = "Registro não encontrado." });
            }

            return BadRequest(new { erro = "Não foi possível remover o registro solicitado, verifique as informações e tente novamente." });
        }

    }
}
