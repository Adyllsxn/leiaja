namespace Save.API.Model;
public class Usuario
{
    public int Id { get; set; } // Identificador único para o usuário
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Foto { get; set; } = null!;// Para armazenar o caminho ou URL da foto
    public string Telefone { get; set; } = null!;
}
