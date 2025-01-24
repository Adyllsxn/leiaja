namespace Testes.Domain.ValueObjects;
public record Email : ValueObject
{
    public string Address { get; }
    public Email(string address)
    {
        if(string.IsNullOrWhiteSpace(address))
            throw new Exception("Email inválido");
        Address = address;
    }

    public static implicit operator Email(string address) => new Email(address);
    public static implicit operator string(Email email) => email.Address;
}
