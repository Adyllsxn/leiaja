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

    #region <GetId>
        [HttpGet("GetAthorById"), EndpointSummary("Get Athor By Id")]
        public async Task<ActionResult> GetAthorById(int athorId)
        {
            if(athorId <= 0)
            {
                return BadRequest("Não Deve Ser Negativa ou Zero");
            }
            var athor = await _service.GetAthorByIdAsync(athorId);

            if(athor == null)
            {
                return NotFound("Não Foi Encontrado");
            }
            return Ok(athor);
        }
    #endregion </GetId>

    #region <Search>
        [HttpGet("SearchAthors"), EndpointSummary("Search Athors")]
        public async Task<ActionResult> SearchAthors(string firstName)
        {
            try
            {
                var athors = await _service.SearchAthorsAsync(firstName);
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
    #endregion </Search>

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
                        subPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
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

    #region <Update>
        [HttpPut("UpdateCategory"), EndpointSummary("Update Category On Database")]
        public async Task<ActionResult> UpdateAthor([FromForm]AthorDTO athorDTO, IFormFile? arquivo)
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
                        subPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
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
                    athorDTO.Photo = $"/{Path.GetFileName(subPasta)}/{arquivo.FileName}";
                }
                if(athorDTO == null)
                    return BadRequest("Não deve ser nulo");

                var athor = await _service.UpdateAthorAsync(athorDTO);
                return Ok(athor);
            }
            catch
            {
                return Problem("Ocorreu um erro ao aditar. Tente novamente mais tarde.");
            }
        }
    #endregion </Update>

    #region <Delete>
        [HttpDelete("DeleteAthor"), EndpointSummary("Delete Athor On Database")]
        public async Task<ActionResult> DeleteAthor(int athorId)
        {
            try
            {
                if(athorId <= 0)
                    return BadRequest("Não deve ser nulo ou Negativa");
                    
                var athor = await _service.DeleteAthorAsync(athorId);
                return Ok(athor);
            }
            catch
            {
                return Problem("Ocorreu um erro ao deletar. Tente novamente mais tarde.");
            }
        }
    #endregion </Delete>

}
