namespace LeiaJa.Domain.Entities;
public sealed class TipoTelefoneEntity : EntityBase
{
    public string TipoTelefone { get; private set; } = null!;

    [JsonIgnore]
    public ICollection<TelefoneEntity> Telefones { get; set; } = null!;

    [JsonConstructor]
    public TipoTelefoneEntity(){}

    public TipoTelefoneEntity(int id, string tipoTelefone)
    {
        DomainExceptionValidation.When(int.IsNegative(id), "O ID Do Tipo De Telefone  Não Deve Ser Negativo.");
        DomainExceptionValidation.When(id <= 0, "O ID Do Tipo De Telefone Deve Ser Maior Que Zero.");
        Id = id;
        ValidationDomain(tipoTelefone);
    }
    public TipoTelefoneEntity(string tipoTelefone)
    {
        ValidationDomain(tipoTelefone);
    }
    public void Update(string tipoTelefone)
    {
        ValidationDomain(tipoTelefone);
    }
    public void ValidationDomain(string tipoTelefone)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(tipoTelefone), "O Tipo De Usuário É Obrigatório.");
        DomainExceptionValidation.When(tipoTelefone.Length > 8, "O Tipo De Telefone Não Pode Ter Mais De 8 Caracteres.");
        
        TipoTelefone = tipoTelefone;
    }
}
