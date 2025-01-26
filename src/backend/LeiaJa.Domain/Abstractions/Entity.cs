namespace LeiaJa.Domain.Abstractions;
public abstract class Entity : IAgregateRoot
{
    public int Id { get; protected set; }

}
