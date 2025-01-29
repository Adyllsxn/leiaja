namespace LeiaJa.Application.DTOs.CategoryDTO;
public class CategoryPostDTO
{
    [Required(ErrorMessage = "Categoria É Obrigatório")]
    [MaxLength(50, ErrorMessage = "Categoria Não Pode Ter Mais De 50 Caracteres.")]
    [MinLength(1, ErrorMessage = "Categoria Não Pode Ser Vazio.")]
    public string Category { get; set; } = null!;

    [Required(ErrorMessage = "Descrição É Obrigatório")]
    [MaxLength(50, ErrorMessage = "Descrição Não Pode Ter Mais De 50 Caracteres.")]
    [MinLength(1, ErrorMessage = "Descrição Não Pode Ser Vazio.")]
    public string Description { get; set; } = null!;
}
