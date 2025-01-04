namespace LeiaJa.Domain.Entities;
public sealed class TipoUsuarioEntity : EntityBase
{
    public string TipoUsuario { get; set; } = null!;
    
    [JsonIgnore]
    public ICollection<UsuarioEntity> Usuarios{ get; set; } = null!;

    [JsonConstructor]
    public TipoUsuarioEntity(){}
    public TipoUsuarioEntity(int id, string tipoUsuario)
    {
        DomainExceptionValidation.When(int.IsNegative(id), "O ID Do Tipo De Usuário Não Deve Ser Negativo.");
        DomainExceptionValidation.When(id <= 0, "O ID Do Tipo De Usuário Deve Ser Maior Que Zero.");
        Id = id;
        ValidationDomain(tipoUsuario);
    }
    public TipoUsuarioEntity(string tipoUsuario)
    {
        ValidationDomain(tipoUsuario);
    }
    public void Update(string tipoUsuario)
    {
        ValidationDomain(tipoUsuario);
    }
    public void ValidationDomain(string tipoUsuario)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(tipoUsuario), "O Tipo De Usuário É Obrigatório.");
        DomainExceptionValidation.When(tipoUsuario.Length > 30, "O Tipo De Usuário Não Pode Ter Mais De 30 Caracteres.");

        TipoUsuario = tipoUsuario;
    }
}
