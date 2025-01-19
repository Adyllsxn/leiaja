namespace LeiaJa.Presentation.Features.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AutoresController : ControllerBase
{   
    #region <Configuration>
        private readonly IAutorService _service;
        public AutoresController(IAutorService service)
        {
            _service = service;
        }
    #endregion </Configuration>

    #region <Create>
        [HttpPost("CreateAutor")]
        public async Task<ActionResult> CreateAutor(AutorPostDTO autorPostDTO)
        {
            try
            {
                if(autorPostDTO == null)
                    return BadRequest("Não deve ser vazia");

                var autor = await _service.CreateAutorAsync(autorPostDTO);
                return Ok(autor);
            }
            catch
            {
                return Problem("Ocorreu um erro ao salvar. Tente novamente mais tarde.");
            }
        }
    #endregion </Create>
    
    #region <Delete> 
        [HttpDelete("DeleteAutor")]
        public async Task<ActionResult> DeleteAutor(int autorId)
        {
            try
            {
                if(autorId <= 0)
                    return BadRequest("Não deve ser nulo ou Negativa");
                    
                var autor = await _service.DeleteAutorAsync(autorId);
                return Ok(autor);
            }
            catch
            {
                return Problem("Ocorreu um erro ao deletar. Tente novamente mais tarde.");
            }
        }
    #endregion </Delete>

    #region <Get>
        [HttpGet("GetAutores")]
        public async Task<ActionResult> GetAutores([FromQuery]PaginationParams paginationParams)
        {
            try
            {
                var autores = await _service.GetAllAutoresAsync(paginationParams.PageNumber, paginationParams.PageSize);
                if(autores == null || autores.Data == null)
                {
                    return NotFound("Não Foram Encontrados Nenhum Autor");
                }
                Response.AddPaginationHeader(new PaginationHeader(autores.Data.CurrentPage, autores.Data.PageSize, autores.Data.TotalCount, autores.Data.TotalPages));
                return Ok(autores);
            }
            catch
            {
                return Problem("Ocorreu um erro ao processar a solicitação. Tente novamente mais tarde.");
            }
        }
    #endregion </Get>

    #region <GetId>
        [HttpGet("GetAutorByID")]
        public async Task<ActionResult> GetAutorByID(int autorId)
        {
            try
            {
                if(autorId <= 0)
                {
                    return BadRequest("Não Deve Ser Negativa ou Zero");
                }
                var autor = await _service.GetAutorByIdAsync(autorId);

                if(autor == null)
                {
                    return NotFound("Não Foi Encontrado");
                }
                return Ok(autor);
            }
            catch 
            {
                return Problem("Ocorreu um erro ao processar a solicitação. Tente novamente mais tarde.");
            }
            
        }
    #endregion </GetId>

    #region <Update>
        [HttpPut("UpdateAutor")]
        public async Task<ActionResult> UpdateAutor(AutorDTO autorDTO)
        {
            try
            {
                if(autorDTO == null)
                    return BadRequest("Não deve ser nulo");

                var autor = await _service.UpdateAutorAsync(autorDTO);
                return Ok(autor);
            }
            catch
            {
                return Problem("Ocorreu um erro ao aditar. Tente novamente mais tarde.");
            }
        }
    #endregion </Update>
}
