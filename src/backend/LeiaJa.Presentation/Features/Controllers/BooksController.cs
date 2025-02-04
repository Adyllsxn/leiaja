using LeiaJa.Domain.Entities;

namespace LeiaJa.Presentation.Features.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookRepository _service) : ControllerBase
{
    #region <Get>
        [HttpGet("GetBooks"), EndpointSummary("Get All Books")]
        public async Task<ActionResult> GetBooks()
        {
            try
            {
                var books = await _service.GetBooksAsync();
                if(books == null)
            {
                return NotFound("Não Foram Encontrados Nenhum Livro");
            }
                return Ok(books);
            }
            catch
            {
                return Problem("Ocorreu um erro ao processar a solicitação. Tente novamente mais tarde.");
            }
        }
    #endregion </Get>

    #region <Create>
            [HttpPost("CreateBook"), EndpointSummary("Create Books On Database")]
            public async Task<ActionResult> CreateBook([FromBody] BookEntity book, [FromQuery]List<int> categoryId, [FromQuery]List<int> athorId )
            {
                try
                {
                    if(book == null)
                        return BadRequest("Não deve ser vazia");

                    var autor = await _service.CreateBookAsync(book, categoryId, athorId);
                    return Ok(autor);
                }
                catch
                {
                    return Problem("Ocorreu um erro ao salvar. Tente novamente mais tarde.");
                }
            }
        #endregion </Create> 


}
