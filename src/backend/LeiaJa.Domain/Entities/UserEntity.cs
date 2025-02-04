namespace LeiaJa.Domain.Entities;
public sealed class UserEntity: EntityBase, IAgregateRoot
{
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public EUsuario EUsuario { get; private set; }
    public string Photo { get; private set; } = null!;
    public byte[] PasswordHash { get; private set; } = null!;
    public byte[] PasswordSalt { get; private set; } = null!;

    [JsonConstructor]
    public UserEntity(){}

    public UserEntity(int id, string firstName, string lastName, string email, string photo)
    {
        DomainExceptionValidation.When(id <= 0, "O Id do autor não poder ser menor ou igual à zero!");
        Id = id;
        ValidationDomain( firstName,  lastName,  email,  photo);
    }
    public UserEntity(string firstName, string lastName, string email, string photo)
    {
        ValidationDomain( firstName,  lastName,  email,  photo);
    }
    public void Update(string firstName, string lastName, string email, string photo)
    {
        ValidationDomain( firstName,  lastName,  email,  photo);
    }
    public void SetAdmin(EUsuario isAdminOrLeitor)
    {
        EUsuario = isAdminOrLeitor;
    }
    public void UpdatePassword(byte[] passwordHash, byte[] passwordSalt)
    {
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
    public void ValidationDomain(string firstName, string lastName, string email, string photo)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(firstName), "FirstName Inválido");
        DomainExceptionValidation.When(firstName.Length > 50, "O FirstName deve ter menos de 50 caracteres.");

        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(lastName), "LastName Inválido");
        DomainExceptionValidation.When(lastName.Length > 50, "O LastName deve ter menos de 50 caracteres.");

        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(email), "Email Inválido");
        DomainExceptionValidation.When(email.Length > 250, "Email deve ter menos de 250 caracteres.");

        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(photo), "Photo Inválido");
        DomainExceptionValidation.When(photo.Length < 1, "A Photo deve ter pelo menos 1 caracteres.");
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Photo = photo;
    }
}
