namespace LeiaJa.Domain.Interfaces;
public interface IAthorRepository : Interface<AthorEntity>
{
    Task<List<AthorEntity>> GetAthorsAsync();
    Task<List<AthorEntity>> CreateAthorAsync(AthorEntity athor);
    Task<AthorEntity?> DeleteAthorAsync(int athorId);
    Task<AthorEntity?> GetAthorByIdAsync(int athorId);
    Task<AthorEntity> UpdateAthorAsync(AthorEntity athor);
    Task<List<AthorEntity>>SearchAthorAsync(Expression<Func<AthorEntity, bool>> predicate);
}
