namespace LeiaJa.Domain.Entities;
public sealed class BookEntity : EntityBase, IAgregateRoot
{
    public string Title { get; set; } = null!;
    public string Image { get; set; } = null!;
    public string Document { get; set; } = null!;
    public string Edition { get; set; } = null!;
    public DateTime DataCreateBook { get; set; }

    [JsonIgnore]
    public List<BookCategoryEntity> BookCategories { get; set; } = new();
    
    [JsonIgnore]
    public List<BookAthorEntity> BookAthors { get; set; } = new();

    /*[JsonIgnore]
    public List<FavoriteEntity> Favorites { get; set; } = new(); */
    [JsonConstructor]
    private BookEntity(){}

    public BookEntity(int id, string title, string image, string document, string edition, DateTime dataCreateBook)
    {
        DomainExceptionValidation.When(id <= 0, "O Id do autor não poder ser menor ou igual à zero!");
        Id = id;
        ValidationDomain( title,  image,  document,  edition,  dataCreateBook);
    }
    public BookEntity(string title, string image, string document, string edition, DateTime dataCreateBook)
    {
        ValidationDomain( title,  image,  document,  edition,  dataCreateBook);
    }
    public void Update(string title, string image, string document, string edition, DateTime dataCreateBook)
    {
        ValidationDomain( title,  image,  document,  edition,  dataCreateBook);
    }
    public void ValidationDomain(string title, string image, string document, string edition, DateTime dataCreateBook)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(title), "Title Inválido");
        DomainExceptionValidation.When(title.Length > 200, "Title deve ter menos de 50 caracteres.");

        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(image), "Image Inválido");
        DomainExceptionValidation.When(image.Length < 1, "Image deve ter pelo menos 1 caracteres.");

        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(document), "Document Inválido");
        DomainExceptionValidation.When(document.Length < 1, "Document deve ter pelo menos 1 caracteres.");

        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(edition), "Edition Inválido");
        DomainExceptionValidation.When(edition.Length > 50, "Edition deve ter menos de 50 caracteres.");

        Title = title;
        Image = image;
        Document = document;
        Edition = edition;
        DataCreateBook = dataCreateBook;
    }
}
