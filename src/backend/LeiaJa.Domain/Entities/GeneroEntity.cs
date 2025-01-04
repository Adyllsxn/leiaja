namespace LeiaJa.Domain.Entities;
public sealed class GeneroEntity : EntityBase
{
    public string Genero { get; private set; } = null!;

    [JsonIgnore]
    public ICollection<UsuarioEntity> Usuarios{ get; set; } = null!;

    [JsonConstructor]
    public GeneroEntity(){}
    public GeneroEntity(int id, string genero)
    {
        DomainExceptionValidation.When(int.IsNegative(id), "O ID Do Genero Não Deve Ser Negativo.");
        DomainExceptionValidation.When(id <= 0, "O ID Do Genero Deve Ser Maior Que Zero.");
        Id = id;
        ValidationDomain(genero);
    }
    public GeneroEntity(string genero)
    {
        ValidationDomain(genero);
    }
    public void Update(string genero)
    {
        ValidationDomain(genero);
    }
    public void ValidationDomain(string genero)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(genero),"O Genero É Obrigatório.");
        DomainExceptionValidation.When(genero.Length > 15, "O Genero Não Pode Ter Mais De 15 Caracteres.");

        Genero = genero;
    }
}
