namespace LeiaJa.Domain.Entities;
public sealed class BookCategoryEntity: EntityBase, IAgregateRoot
{
    public int BookId { get; set; }
    public int CategoryId { get; set; }
    
    [JsonIgnore]
    public BookEntity Book { get; set; } = null!;
    [JsonIgnore]
    public CategoryEntity Category { get; set; } = null!;

    [JsonConstructor]
    private BookCategoryEntity(){}

    public BookCategoryEntity(int id, int bookId, int categoryId)
    {
        DomainExceptionValidation.When(id <= 0, "bookcategoryId não poder ser menor ou igual à zero!");
        Id = id;
        ValidationDomain( bookId,  categoryId);
    }
    public BookCategoryEntity(int categoryId)
    {
        CategoryId = categoryId;
    }

    public BookCategoryEntity(int bookId, int categoryId)
    {
        ValidationDomain( bookId,  categoryId);
    }
    public void Update(int bookId, int categoryId)
    {
        ValidationDomain( bookId,  categoryId);
    }
    public void ValidationDomain(int bookId, int categoryId)
    {
        DomainExceptionValidation.When(bookId <= 0, "BookId não poder ser menor ou igual à zero!");
        DomainExceptionValidation.When(categoryId <= 0, "CategoryId não poder ser menor ou igual à zero!");

        BookId = bookId;
        CategoryId = categoryId;
    }
}
