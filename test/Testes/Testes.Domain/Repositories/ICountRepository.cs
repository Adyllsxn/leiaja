using Testes.Domain.Entities;

namespace Testes.Domain.Repositories;
public interface ICountRepository : IRepository<AcountEntity>
{
    Task SaveAsync(AcountEntity acount);
}
