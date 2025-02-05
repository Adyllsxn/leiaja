namespace LeiaJa.Presentation.Features.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookService _service) : ControllerBase
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

    #region <GetId>
            [HttpGet("GetBookById"), EndpointSummary("Get Book By Id")]
            public async Task<ActionResult> GetBookById(int bookId)
            {
                if(bookId <= 0)
                {
                    return BadRequest("Não Deve Ser Negativa ou Zero");
                }
                var book= await _service.GetBookByIdAsync(bookId);

                if(book == null)
                {
                    return NotFound("Não Foi Encontrado");
                }
                return Ok(book);
            }
        #endregion </GetId>

    #region <Create>
            [HttpPost("CreateBook"), EndpointSummary("Create Books On Database")]
            public async Task<ActionResult> CreateBook(BookPostModel book)
            {
                try
                {
                    if(book == null)
                        return BadRequest("Não deve ser vazia");

                    var autor = await _service.CreateBookAsync(book.Book, book.CategoriaId, book.AthorId);
                    return Ok(autor);
                }
                catch
                {
                    return Problem("Ocorreu um erro ao salvar. Tente novamente mais tarde.");
                }
            }
        #endregion </Create> 


}
