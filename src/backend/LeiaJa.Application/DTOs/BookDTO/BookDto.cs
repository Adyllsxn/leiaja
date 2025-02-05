namespace LeiaJa.Application.DTOs.BookDTO;
public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Image { get; set; } = null!;
    public string Document { get; set; } = null!;
    public string Edition { get; set; } = null!;
    public DateTime DataCreateBook { get; set; }
    public List<AuthorDto> Authors { get; set; } = new();
    public List<CategoryDto> Categories { get; set; } = new();
}
