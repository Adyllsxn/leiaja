namespace LeiaJa.Domain.Entities;
public sealed class BookAthorEntity
{
    public int BookId { get; set; }
    public int AthorId { get; set; }
    
    [JsonIgnore]
    public BookEntity Book { get; set; } = null!;
    
    [JsonIgnore]
    public AthorEntity Athor { get; set; } = null!;

    [JsonConstructor]
    public BookAthorEntity(){}

    public BookAthorEntity(int bookId, int athorId)
    {
        ValidationDomain( bookId,  athorId);
    }
    public void Update(int bookId, int athorId)
    {
        ValidationDomain( bookId,  athorId);
    }
    public void ValidationDomain(int bookId, int athorId)
    {
        DomainExceptionValidation.When(bookId <= 0, "BookId não poder ser menor ou igual à zero!");
        DomainExceptionValidation.When(athorId <= 0, "AthorId não poder ser menor ou igual à zero!");

        BookId = bookId;
        AthorId = athorId;
    }
}
