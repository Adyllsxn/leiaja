namespace LeiaJa.Application.DTOs.BookDTO;
public class BookPostDTO
{
    [Required(ErrorMessage = "Title É Obrigatório")]
    [MaxLength(200, ErrorMessage = "Title Não Pode Ter Mais De 200 Caracteres.")]
    [MinLength(1, ErrorMessage = "FirstName Não Pode Ser Vazio.")]
    public string Title { get;  set; } = null!;

    [Required(ErrorMessage = "Image É Obrigatório")]
    public string Image { get;  set; } = null!;

    [Required(ErrorMessage = "Document É Obrigatório")]
    public string Document { get;  set; } = null!;

    [Required(ErrorMessage = "Edition É Obrigatório")]
    [MaxLength(50, ErrorMessage = "Edition Não Pode Ter Mais De 50 Caracteres.")]
    public string Edition { get;  set; } = null!;

    [Required(ErrorMessage = "DataCreateBook É Obrigatório")]
    [DataType(DataType.Date, ErrorMessage = "A data informada não é válida.")]
    public DateTime DataCreateBook { get;  set; }

}
