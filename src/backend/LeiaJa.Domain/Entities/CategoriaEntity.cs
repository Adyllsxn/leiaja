namespace LeiaJa.Domain.Entities;
public sealed class CategoriaEntity : EntityBase
{
    public string Categoria { get; private set; } = null!;

    [JsonIgnore]
    public ICollection<LivroEntity> Livros { get; set; } = null!;

    [JsonConstructor]
    public CategoriaEntity(){}

    public CategoriaEntity(int id, string categoria)
    {
        DomainExceptionValidation.When(int.IsNegative(id), "O ID Da Categoria Não Pode Ser Negativo.");
        DomainExceptionValidation.When(id <= 0, "O ID Da Categoria Deve Ser Maior Que Zero.");
        Id = id;
        ValidationDomain(categoria);
    }

    public CategoriaEntity(string categoria)
    {
        ValidationDomain(categoria);
    }

    public void Update(string categoria)
    {
        ValidationDomain(categoria);
    }

    public void ValidationDomain(string categoria)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(categoria),"A Categoria É Obrigatório.");
        DomainExceptionValidation.When(categoria.Length > 50, "A Categoria Não Pode Ter Mais De 50 Caracteres.");

        Categoria = categoria;
    }
}
