using MuchEffective.Core.Entities;

namespace MuchEffective.Core.Contracts;

public interface IRepository<T> {
    System.Threading.Tasks.Task<long> Add(T value);
    System.Threading.Tasks.Task<T> GetById(long id);
    System.Threading.Tasks.Task<List<T>> GetAll();
    System.Threading.Tasks.Task Update<V>(long id, V value) where V : TaskState;
    System.Threading.Tasks.Task Remove(long id);
}