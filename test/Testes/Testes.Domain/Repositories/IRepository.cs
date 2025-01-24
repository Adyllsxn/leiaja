using Testes.Domain.Abstractions;
namespace Testes.Domain.Repositories;
public interface IRepository<T>  where T : IAgregateRoot;
