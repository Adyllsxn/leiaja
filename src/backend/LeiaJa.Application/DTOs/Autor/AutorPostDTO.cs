namespace LeiaJa.Application.DTOs.Autor;
public class AutorPostDTO
{
    [Required(ErrorMessage = "O Nome É Obrigatório")]
    [MaxLength(50, ErrorMessage = "O Nome Não Pode Ter Mais De 50 Caracteres.")]
    [MinLength(1, ErrorMessage = "O Nome Não Pode Ser Vazio.")]
    [NonEmptyString(ErrorMessage = "O Nome Não Pode Ser Vazio ou Apenas Espaços")]
    public string Nome { get; set; } = null!;

    [Required(ErrorMessage = "O Sobrenome É Obrigatório")]
    [MaxLength(50, ErrorMessage = "O Sobrenome Não Pode Ter Mais De 50 Caracteres.")]
    [MinLength(1, ErrorMessage = "O Sobrenome Não Pode Ser Vazio.")]
    [NonEmptyString(ErrorMessage = "O SobreNome Não Pode Ser Vazio ou Apenas Espaços")]
    public string SobreNome { get; set; } = null!;
}
