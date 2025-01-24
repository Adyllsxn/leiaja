using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Save.API.Interfaces;
using Save.API.Model;

namespace Save.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        #region GET ID
        // GET: api/usuario/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
        }
        #endregion

        #region GET
        // GET: api/usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _usuarioRepository.GetAllAsync();
        }
        #endregion

        #region DELETE
        // DELETE: api/usuario/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var deleted = await _usuarioRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
        #endregion

        #region POST
        [HttpPost("cadastrar")]
        public async Task<ActionResult<Usuario>> CadastrarUsuario([FromForm] Usuario usuario, IFormFile arquivo)
        {
            if (arquivo != null && arquivo.Length > 0)
            {
                // Obtém o tipo MIME do arquivo
                var mimeType = arquivo.ContentType;

                // Define a pasta base para uploads
                string subPasta;

                if (mimeType.StartsWith("image"))
                {
                    subPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                }
                else if (mimeType == "application/pdf" || mimeType == "application/msword" || mimeType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
                {
                    subPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "docs");
                }
                else if (mimeType.StartsWith("audio"))
                {
                    subPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "audios");
                }
                else if (mimeType.StartsWith("video"))
                {
                    subPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "videos");
                }
                else
                {
                    return BadRequest("Tipo de arquivo não suportado.");
                }

                // Verifica se a subpasta existe, se não cria
                if (!Directory.Exists(subPasta))
                {
                    Directory.CreateDirectory(subPasta);
                }

                // Define o caminho completo para o arquivo
                var caminhoArquivo = Path.Combine(subPasta, arquivo.FileName);

                // Salva o arquivo na pasta correspondente
                using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                {
                    await arquivo.CopyToAsync(stream);
                }

                // Atribui o caminho do arquivo ao usuário
                usuario.Foto = $"/{Path.GetFileName(subPasta)}/{arquivo.FileName}";
            }

            var usuarioCriado = await _usuarioRepository.AddAsync(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuarioCriado.Id }, usuarioCriado);
        }
        #endregion

        #region PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromForm] Usuario usuario, IFormFile? arquivo)
        {
            if (arquivo != null && arquivo.Length > 0)
            {
                // Obtém o tipo MIME do arquivo
                var mimeType = arquivo.ContentType;

                // Define a pasta base para uploads
                string subPasta;

                if (mimeType.StartsWith("image"))
                {
                    subPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                }
                else if (mimeType == "application/pdf" || mimeType == "application/msword" || mimeType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
                {
                    subPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "docs");
                }
                else if (mimeType.StartsWith("audio"))
                {
                    subPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "audios");
                }
                else if (mimeType.StartsWith("video"))
                {
                    subPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "videos");
                }
                else
                {
                    return BadRequest("Tipo de arquivo não suportado.");
                }

                // Verifica se a subpasta existe, se não cria
                if (!Directory.Exists(subPasta))
                {
                    Directory.CreateDirectory(subPasta);
                }

                // Define o caminho completo para o arquivo
                var caminhoArquivo = Path.Combine(subPasta, arquivo.FileName);

                // Salva o arquivo na pasta correspondente
                using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                {
                    await arquivo.CopyToAsync(stream);
                }

                // Atribui o caminho do arquivo ao usuário
                usuario.Foto = $"/{Path.GetFileName(subPasta)}/{arquivo.FileName}";
            }

            var usuarioAtualizado = await _usuarioRepository.UpdateAsync(id, usuario);
            if (usuarioAtualizado == null)
            {
                return NotFound();
            }
            return Ok(usuarioAtualizado);
        }
        #endregion
    }
}