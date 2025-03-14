using MuchEffective.Core.Contracts;
using MuchEffective.Core.Entities;

namespace MuchEffective.UseCases.Persistence;

public class UserRepository : IRepository<User>
{
    private readonly DataContext _context;
    private string _userId;
    public UserRepository(DataContext context, string userId)
    {
        _context = context;
        _userId = userId;
    }
    public Task<long> Add(User value)
    {
        
    }

    public Task<List<User>> GetAll()
    {
        
    }

    public Task<User> GetById(long id)
    {
        
    }

    public System.Threading.Tasks.Task Remove(long id)
    {
        throw new NotImplementedException();
    }

    public System.Threading.Tasks.Task Update<V>(long id, V value) where V : TaskState
    {
        throw new NotImplementedException();
    }
}