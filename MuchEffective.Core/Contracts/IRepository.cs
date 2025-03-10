
namespace MuchEffective.Core.Contracts;

public interface IRepository<T> {
    Task<T> GetById(long id);
    Task<List<T>> GetAll();
    Task Update<V>(long id, V value);
    Task Update<V, K>(K key, V value);
    Task Remove(long id);
    Task Remove<K>(K key);
}