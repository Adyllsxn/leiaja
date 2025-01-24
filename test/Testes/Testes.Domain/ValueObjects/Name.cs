namespace Testes.Domain.ValueObjects;
public sealed record Name : ValueObject
{
    private const short MinLenght = 3;
    public Name(string firstname)
    {
        if(string.IsNullOrWhiteSpace(firstname))
            throw new Exception("Name inválido");

        if(firstname.Length < MinLenght)
            throw new Exception("Nome Inválido");
        FirstName = firstname;
    } 
    public string FirstName { get;}
    public static implicit operator string(Name name) => name.FirstName;
    public static implicit operator Name(string firstname) => new Name(firstname);
}
