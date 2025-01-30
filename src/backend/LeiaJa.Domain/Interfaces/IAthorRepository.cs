namespace LeiaJa.Domain.Interfaces;
public interface IAthorRepository : Interface<AthorEntity>
{
    Task<List<AthorEntity>> GetAthorsAsync();
    Task<List<AthorEntity>> CreateAthorAsync(AthorEntity athor);
}
