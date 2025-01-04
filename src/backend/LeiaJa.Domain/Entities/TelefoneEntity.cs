namespace LeiaJa.Domain.Entities;
public sealed class TelefoneEntity : EntityBase
{
    public string Telefone { get; private set; } = null!;
    public int UsuarioId { get; private set; }
    public int TipoTelefoneId { get; private set; }
    
    [JsonIgnore]
    public TipoTelefoneEntity TipoTelefone{ get; set; } = null!;

    [JsonIgnore]
    public UsuarioEntity Usuario { get; set; } = null!;

    [JsonConstructor]
    public TelefoneEntity(){}
    public TelefoneEntity(int id,string telefone , int usuarioId, int tipoTelefoneId)
    {
        DomainExceptionValidation.When(int.IsNegative(id), "O ID do Telefone Não Deve Ser Negativo.");
        DomainExceptionValidation.When(id <= 0, "O ID do Telefone Deve Ser Maior Que Zero.");
        Id = id;
        ValidationDomain(telefone,usuarioId,tipoTelefoneId);
    }
    public TelefoneEntity(string telefone,int usuarioId, int tipoTelefoneId)
    {
        ValidationDomain(telefone,usuarioId, tipoTelefoneId);
    }
    public void Update(string telefone,int usuarioId, int tipoTelefoneId)
    {
        ValidationDomain(telefone,usuarioId, tipoTelefoneId);
    }
    public void ValidationDomain(string telefone,int usuarioId, int tipoTelefoneId)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(telefone), "O Número De Telefone É Obrigatório.");
        DomainExceptionValidation.When(telefone.Length != 9, "O Número De Telefone Deve Ter 9 Caracteres.");

        DomainExceptionValidation.When(int.IsNegative(usuarioId), "O ID Do Usuário Não Deve Ser Negativo.");
        DomainExceptionValidation.When(usuarioId <= 0, "O ID Do Usuário Deve Ser Maior Que Zero.");

        DomainExceptionValidation.When(int.IsNegative(tipoTelefoneId), "O ID Do Tipo De Usuário Não Deve Ser Negativo.");
        DomainExceptionValidation.When(tipoTelefoneId <= 0, "O ID Do Tipo De Usuário Deve Ser Maior Que Zero.");

        Telefone = telefone;
        UsuarioId = usuarioId;
        TipoTelefoneId = tipoTelefoneId;
    }
}
