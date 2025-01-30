namespace LeiaJa.Domain.Entities;
public sealed class AthorEntity : EntityBase, IAgregateRoot
{
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set;} = null!;
    public string Photo { get; private set; } = null!;
    
    [JsonConstructor]
    public AthorEntity(){}
    
    public AthorEntity(int id, string firstName, string lastName, string photo)
    {
        DomainExceptionValidation.When(id <= 0, "O Id do autor não poder ser menor ou igual à zero!");
        Id = id;
        ValidationDomain( firstName,  lastName,  photo);
    }
    public AthorEntity(string firstName, string lastName, string photo)
    {
        ValidationDomain( firstName,  lastName,  photo);
    }
    public void Update(string firstName, string lastName, string photo)
    {
        ValidationDomain( firstName,  lastName,  photo);
    }
    public void ValidationDomain(string firstName, string lastName, string photo)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(firstName), "FirstName Inválido");
        DomainExceptionValidation.When(firstName.Length > 50, "O FirstName deve ter menos de 50 caracteres.");

        DomainExceptionValidation.When(string.IsNullOrEmpty(lastName), "LastName Inválido");
        DomainExceptionValidation.When(lastName.Length > 50, "O LastName deve ter menos de 50 caracteres.");

        DomainExceptionValidation.When(string.IsNullOrEmpty(photo), "Photo Inválido");
        DomainExceptionValidation.When(photo.Length < 1, "A Photo deve ter pelo menos 1 caracteres.");

        FirstName = firstName;
        LastName = lastName;
        Photo = photo;
    }
}
