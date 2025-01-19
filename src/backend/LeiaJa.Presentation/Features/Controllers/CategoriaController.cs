namespace LeiaJa.Presentation.Features.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    #region <Configuration>
        private readonly ICategoriaService _service;
        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }
    #endregion </Configuration>

    #region <Get>
        [HttpGet("GetCategorias")]
        public async Task<ActionResult> GetCategorias([FromQuery]PaginationParams paginationParams)
        {
            try
            {
                var categorias = await _service.GetAllCategoriasAsync(paginationParams.PageNumber, paginationParams.PageSize);
                if(categorias == null || categorias.Data == null)
                {
                    return NotFound("Não Foram Encontrados Nenhuma Categorias");
                }
                Response.AddPaginationHeader(new PaginationHeader(categorias.Data.CurrentPage, categorias.Data.PageSize, categorias.Data.TotalCount, categorias.Data.TotalPages));
                return Ok(categorias);
            }
            catch
            {
                return Problem("Ocorreu um erro ao processar a solicitação. Tente novamente mais tarde.");
            }
        }
    #endregion </Get>

    #region <GetId>
        [HttpGet("GetCategoriaById")]
        public async Task<ActionResult> GetCategoriaById(int categoriaId)
        {
            try
            {
                if(categoriaId <= 0)
                {
                    return BadRequest("Não Deve Ser Negativa ou Zero");
                }
                var categoria = await _service.GetCategoriaByIdAsync(categoriaId);

                if(categoria == null)
                {
                    return NotFound("Não Foi Encontrado");
                }
                return Ok(categoria);
            }
            catch 
            {
                return Problem("Ocorreu um erro ao processar a solicitação. Tente novamente mais tarde.");
            }
            
        }
    #endregion </GetId>

    #region <Create>
        [HttpPost("CreateCategoria")]
        public async Task<ActionResult> CreateCategoria(CategoriaPostDTO categoriaPostDTO)
        {
            try
            {
                if(categoriaPostDTO == null)
                    return BadRequest("Não deve ser vazia");

                var autor = await _service.CreateCategoriaAsync(categoriaPostDTO);
                return Ok(autor);
            }
            catch
            {
                return Problem("Ocorreu um erro ao salvar. Tente novamente mais tarde.");
            }
        }
    #endregion </Create>

    #region <Update>
        [HttpPut("UpdateAutor")]
        public async Task<ActionResult> UpdateCategoria(CategoriaDTO categoriaDTO)
        {
            try
            {
                if(categoriaDTO == null)
                    return BadRequest("Não deve ser nulo");

                var categoria = await _service.UpdateCategoriaAsync(categoriaDTO);
                return Ok(categoria);
            }
            catch
            {
                return Problem("Ocorreu um erro ao aditar. Tente novamente mais tarde.");
            }
        }
    #endregion </Update>

    #region <Delete>
        [HttpDelete("DeleteAutor")]
        public async Task<ActionResult> DeleteCategoria(int categoriaId)
        {
            try
            {
                if(categoriaId <= 0)
                    return BadRequest("Não deve ser nulo ou Negativa");
                    
                var categoria = await _service.DeleteCategoriaAsync(categoriaId);
                return Ok(categoria);
            }
            catch
            {
                return Problem("Ocorreu um erro ao deletar. Tente novamente mais tarde.");
            }
        }
    #endregion </Delete>

}
