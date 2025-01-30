namespace LeiaJa.Application.DTOs.AthorDTO;
public class AthorDTO
{
    [Range(1, int.MaxValue, ErrorMessage = "O ID Deve Ser Maior Que Zero.")]
    public int Id { get; set; }

    [Required(ErrorMessage = "FirstName É Obrigatório")]
    [MaxLength(50, ErrorMessage = "FirstName Não Pode Ter Mais De 50 Caracteres.")]
    [MinLength(1, ErrorMessage = "FirstName Não Pode Ser Vazio.")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "LastName É Obrigatório")]
    [MaxLength(50, ErrorMessage = "LastName Não Pode Ter Mais De 50 Caracteres.")]
    [MinLength(1, ErrorMessage = "LastName Não Pode Ser Vazio.")]
    public string LastName { get; set;} = null!;

    [Required(ErrorMessage = "Photo É Obrigatório")]
    [MinLength(1, ErrorMessage = "Photo Não Pode Ser Vazio.")]
    public string Photo { get; set; } = null!;
}
