namespace LeiaJa.Domain.Entities;
public sealed class AutorEntity : EntityBase
{
    public string Nome { get; private set; } = null!;
    public string SobreNome { get; private set; } = null!;
    
    [JsonIgnore]
    public ICollection<LivroEntity> Livros { get; set; } = null!;

    [JsonConstructor]
    public AutorEntity(){}

    public AutorEntity(int id, string nome, string sobreNome)
    {
        DomainExceptionValidation.When(int.IsNegative(id), "O ID Do Autor Não Pode Ser Negativo.");
        DomainExceptionValidation.When(id <= 0, "O ID Do Autor Deve Ser Maior Que Zero.");
        Id = id;
        ValidationDomain(nome, sobreNome);
    }

    public AutorEntity(string nome, string sobreNome)
    {
        ValidationDomain(nome, sobreNome);
    }

    public void Update(string nome, string sobreNome)
    {
        ValidationDomain(nome, sobreNome);
    }

    public void ValidationDomain(string nome, string sobreNome)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome),"O Nome É Obrigatório.");
        DomainExceptionValidation.When(nome.Length > 50, "O Nome Não Pode Ter Mais De 50 Caracteres.");

        DomainExceptionValidation.When(string.IsNullOrEmpty(sobreNome),"O Sobrenome É Obrigatório.");
        DomainExceptionValidation.When(sobreNome.Length > 50, "O Sobrenome Não Pode Ter Mais De 50 Caracteres.");
        
        Nome = nome;
        SobreNome = sobreNome;
    }
}
