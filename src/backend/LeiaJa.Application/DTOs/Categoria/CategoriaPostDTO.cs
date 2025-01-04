namespace LeiaJa.Application.DTOs.Categoria;
public class CategoriaPostDTO
{

    [Required(ErrorMessage = "A Categoria É Obrigatório")]
    [MaxLength(50, ErrorMessage = "A Categoria Não Pode Ter Mais De 50 Caracteres.")]
    [MinLength(1, ErrorMessage = "A Categoria Não Pode Ser Vazio.")]
    [NonEmptyString(ErrorMessage = "A Categoria Não Pode Ser Vazio ou Apenas Espaços")]
    public string Categoria { get; set; } = null!;
}
