namespace LeiaJa.Presentation.Features.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AthorsController(IAthorService _service) : ControllerBase
{
    #region <Get>
        [HttpGet("GetAthors"), EndpointSummary("Get All Athors")]
        public async Task<ActionResult> GetAthors()
        {
            try
            {
                var athors = await _service.GetAthorsAsync();
                if(athors == null)
            {
                return NotFound("Não Foram Encontrados Nenhuma Categorias");
            }
                return Ok(athors);
            }
            catch
            {
                return Problem("Ocorreu um erro ao processar a solicitação. Tente novamente mais tarde.");
            }
        }
    #endregion </Get>
    
    #region <Create>
        [HttpPost("CreateAthor"), EndpointSummary("Create Athor On Database")]
        public async Task<ActionResult> CreateAthor([FromForm]AthorPostDTO athorPostDTO, IFormFile? arquivo)
        {
            try
            {
                if (arquivo != null && arquivo.Length > 0)
                {
                    // Obtém o tipo MIME do arquivo
                    var mimeType = arquivo.ContentType;

                    // Define a pasta base para uploads
                    string subPasta;

                    if (mimeType.StartsWith("image"))
                    {
                        subPasta = Path.Combine(Directory.GetCurrentDirectory(), "Infrastructure/wwwroot", "images");
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
                    athorPostDTO.Photo = $"/{Path.GetFileName(subPasta)}/{arquivo.FileName}";
                }
                
                if(athorPostDTO == null)
                    return BadRequest("Não deve ser vazia");

                var autor = await _service.CreateAthorAsync(athorPostDTO);
                return Ok(autor);
            }
            catch
            {
                return Problem("Ocorreu um erro ao salvar. Tente novamente mais tarde.");
            }
        }
    #endregion </Create>
}
