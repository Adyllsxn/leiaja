namespace Testes.Domain.Entities;
public abstract class Entity 
{
    public Guid Id { get; } = Guid.NewGuid();
}
