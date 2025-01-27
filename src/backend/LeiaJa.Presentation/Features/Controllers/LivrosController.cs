namespace LeiaJa.Presentation.Features.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController(ILivroService _service) : ControllerBase
    {
        #region <Create>
            [HttpPost("CreateLivro")]
            public async Task<ActionResult> CreateLivro(LivroPostDTO livroPostDTO)
            {
                try
                {
                    if(livroPostDTO == null)
                        return BadRequest("Não deve ser vazia");

                    var livro = await _service.CreateLivroAsync(livroPostDTO);
                    return Ok(livro);
                }
                catch
                {
                    return Problem("Ocorreu um erro ao salvar. Tente novamente mais tarde.");
                }
            }
        #endregion </Create>
    
        #region <Delete> 
            [HttpDelete("DeleteLivro")]
            public async Task<ActionResult> DeleteLivro(int livroId)
            {
                try
                {
                    if(livroId <= 0)
                        return BadRequest("Não deve ser nulo ou Negativa");
                        
                    var livro = await _service.DeleteLivroAsync(livroId);
                    return Ok(livro);
                }
                catch
                {
                    return Problem("Ocorreu um erro ao deletar. Tente novamente mais tarde.");
                }
            }
        #endregion </Delete>

        #region <Get>
            [HttpGet("GetLivros")]
            public async Task<ActionResult> GetLivros([FromQuery]PaginationParams paginationParams)
            {
                try
                {
                    var livros = await _service.GetAllLivrosAsync(paginationParams.PageNumber, paginationParams.PageSize);
                    if(livros == null || livros.Data == null)
                    {
                        return NotFound("Não Foram Encontrados Nenhum Livro");
                    }
                    Response.AddPaginationHeader(new PaginationHeader(livros.Data.CurrentPage, livros.Data.PageSize, livros.Data.TotalCount, livros.Data.TotalPages));
                    return Ok(livros);
                }
                catch
                {
                    return Problem("Ocorreu um erro ao processar a solicitação. Tente novamente mais tarde.");
                }
            }
        #endregion </Get>

        #region <GetId>
        [HttpGet("GetLivroByID")]
            public async Task<ActionResult> GetLivroByID(int livroId)
            {
                try
                {
                    if(livroId <= 0)
                    {
                        return BadRequest("Não Deve Ser Negativa ou Zero");
                    }
                    var livro = await _service.GetLivroByIdAsync(livroId);

                    if(livro == null)
                    {
                        return NotFound("Não Foi Encontrado");
                    }
                    return Ok(livro);
                }
                catch 
                {
                    return Problem("Ocorreu um erro ao processar a solicitação. Tente novamente mais tarde.");
                }
                
            }
        #endregion </GetId>

        #region <Update>
            [HttpPut("UpdateAutor")]
            public async Task<ActionResult> UpdateAutor(LivroDTO livroDTO)
            {
                try
                {
                    if(livroDTO == null)
                        return BadRequest("Não deve ser nulo");

                    var livro = await _service.UpdateLivroAsync(livroDTO);
                    return Ok(livro);
                }
                catch
                {
                    return Problem("Ocorreu um erro ao aditar. Tente novamente mais tarde.");
                }
            }
        #endregion </Update>
    }
}