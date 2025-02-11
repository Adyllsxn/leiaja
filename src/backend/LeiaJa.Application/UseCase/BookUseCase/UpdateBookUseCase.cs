namespace LeiaJa.Application.UseCase.BookUseCase;
public class UpdateBookUseCase(IBookRepository _repository, IMapper _mapper)
{
        public async Task<ResponseModel<BookDto>> UpdateAthorAsync(BookDto bookDto,List<int> categoryId, List<int> athorId)
        {
            ResponseModel<BookDto> response = new();
            try
            {   
                if(bookDto == null)
                {
                    response.Message = "Os Parâmetros Não Devem Ser Nulos Ou Vazios.";
                    response.StatusCode = 400;
                    return response;
                }
                var book = _mapper.Map<BookEntity>(bookDto);
                var updateBook = await _repository.UpdateBookAsync(book, categoryId, athorId);
                if(updateBook == null)
                {
                    response.Message = $"Não Exite Esse livro Com ID {book.Id}";
                    response.StatusCode = 404;
                    return response;
                }
                response.Data = _mapper.Map<BookDto>(updateBook);
                response.Message = "Livro Editada Com Sucesso!";
                response.StatusCode = 200;
                return response;
            }
            catch(Exception ex)
            {
                response.Message = $"Falha Ao Editar O Autor. Erro: {ex.Message}";
                response.StatusCode = 500;
                return response;
            }
        }
}
