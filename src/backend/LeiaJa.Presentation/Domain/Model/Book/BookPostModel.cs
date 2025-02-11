namespace LeiaJa.Presentation.Domain.Model.Book;
public class BookPostModel
{
    [FromBody]  public BookPostDTO Book { get; set; } = null!;
    [FromQuery] public List<int> CategoriaId { get; set; } = null!;
    [FromQuery] public List<int> AthorId { get; set; } = null!;
}
