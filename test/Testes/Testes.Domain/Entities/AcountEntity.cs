using Testes.Domain.Abstractions;
using Testes.Domain.ValueObjects;

namespace Testes.Domain.Entities;
public class AcountEntity : Entity, IAgregateRoot
{
    public AcountEntity(string name, string email, string document)
    {
        Name = name;
        Email = email;
        Document = document;
        VerificationCode =  Guid.NewGuid().ToString()[..6];
    }
    public Name Name { get; }
    public Email Email { get; }
    public Document Document { get;  }
    public string VerificationCode { get; }
    public DateTime? VerifiedAt { get; }

    public void Verify(string code)
    {
        if(code != VerificationCode)
            throw new Exception("Código de verificação inválido!");
    }
}
