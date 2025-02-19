namespace LeiaJa.Domain.Entities;
public sealed class CategoryEntity : EntityBase, IAgregateRoot
{
    public string Category { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    
    [JsonIgnore]
    public ICollection<BookCategoryEntity> BookCategories { get; set; } = new List<BookCategoryEntity>();

    [JsonConstructor]
    private CategoryEntity(){}
    public CategoryEntity(int id, string category, string description)
    {
        DomainExceptionValidation.When(id <= 0, "Id da categoria não pode ser menor ou igual à zero.");
        Id = id;
        ValidationDomain( category,  description);
    }
    public CategoryEntity(string category, string description)
    {
        ValidationDomain( category,  description);
    }
    public void Update(string category, string description)
    {
        ValidationDomain( category,  description);
    }
    public void ValidationDomain(string category, string description)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(category), "Categoria Inválido");
        DomainExceptionValidation.When(category.Length > 50, "Categoria deve ter menos de 50 caracteres");

        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description), "Categoria Inválido");
        DomainExceptionValidation.When(description.Length > 200, "Categoria deve ter menos de 200 caracteres");

        Category = category;
        Description = description;
    }
}