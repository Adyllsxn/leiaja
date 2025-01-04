namespace LeiaJa.Domain.Entities;
public sealed class ProvinciaEntity : EntityBase
{
    public string Provincia { get; private set; } = null!;

    [JsonIgnore]
    public ICollection<MunicipioEntity> Municipios { get; set; } = null!;

    [JsonConstructor]
    public ProvinciaEntity(){}
    public ProvinciaEntity(int id, string provincia)
    {
        DomainExceptionValidation.When(int.IsNegative(id), "O ID Da Provincia Não Deve Ser Negativo.");
        DomainExceptionValidation.When(id <= 0, "O ID Da Provincia Deve Ser Maior Que Zero.");
        Id = id;
        ValidationDomain(provincia);
    }
    public ProvinciaEntity(string provincia)
    {
        ValidationDomain(provincia);
    }
    public void Update(string provincia)
    {
        ValidationDomain(provincia);
    }
    public void ValidationDomain(string provincia)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(provincia),"A Provincia É Obrigatório.");
        DomainExceptionValidation.When(provincia.Length > 30, "A Provincia Não Pode Ter Mais De 30 Caracteres.");
        Provincia = provincia;
    }
}
