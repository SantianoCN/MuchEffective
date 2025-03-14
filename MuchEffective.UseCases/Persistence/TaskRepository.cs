
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using MuchEffective.Core.Contracts;
using MuchEffective.Core.Entities;
using MuchEffective.Core.Entities.Database;

namespace MuchEffective.UseCases.Persistence;

public class TaskRepository : IRepository<Core.Entities.Task>
{
    /// <summary>
    /// Реализация интерфейса ITaskRepository
    /// </summary>
    private readonly DataContext _context;
    private string _userId;
    public TaskRepository(DataContext context, string userId)
    {
        _context = context;
        _userId = userId;
    }

    public async Task<long> Add(Core.Entities.Task value)
    {
        switch (value.State)
        {
            case PlannedTask:
                {
                    DatabaseTask entity = new DatabaseTask
                    {
                        State = TaskStates.Planned,
                        Name = value.State.Name,
                        Description = value.State.Description,
                        CreationDate = value.State.CreationDate,
                        Deadline = value.State.Deadline,
                        ExecutorId = Mapper.GetIdByGuid(value.State.Executor.Guid),
                        EmployerId = Mapper.GetIdByGuid(value.State.Employer.Guid)
                    };
                    _context.Tasks.Add(entity);
                    _context.SaveChanges();
                    return entity.Id;
                }
            case StartedTask:
                {
                    StartedTask state = (value.State as StartedTask)!;
                    DatabaseTask entity = new DatabaseTask
                    {
                        State = TaskStates.Started,
                        Name = value.State.Name,
                        Description = value.State.Description,
                        CreationDate = value.State.CreationDate,
                        Deadline = value.State.Deadline,
                        ExecutorId = Mapper.GetIdByGuid(value.State.Executor.Guid),
                        EmployerId = Mapper.GetIdByGuid(value.State.Employer.Guid),
                        StartDate = state.StartDate
                    };
                    _context.Tasks.Add(entity);
                    _context.SaveChanges();
                    return entity.Id;
                }
            case CompletedTask:
                {
                    CompletedTask state = (value.State as CompletedTask)!;
                    DatabaseTask entity = new DatabaseTask
                    {
                        State = TaskStates.Started,
                        Name = value.State.Name,
                        Description = value.State.Description,
                        CreationDate = value.State.CreationDate,
                        Deadline = value.State.Deadline,
                        ExecutorId = Mapper.GetIdByGuid(value.State.Executor.Guid),
                        EmployerId = Mapper.GetIdByGuid(value.State.Employer.Guid),
                        StartDate = state.StartDate,
                        ColmpleteDate = state.ColmpleteDate,
                        IsChecked = state.IsChecked,
                        ResultCommentId = Mapper.GetIdByGuid(state.Result.Guid)
                    };
                    break;
                }
            case ExpiredTask:
                {
                    ExpiredTask state = (value.State as ExpiredTask)!;
                    DatabaseTask entity = new DatabaseTask
                    {
                        State = TaskStates.Started,
                        Name = value.State.Name,
                        Description = value.State.Description,
                        CreationDate = value.State.CreationDate,
                        Deadline = value.State.Deadline,
                        ExecutorId = Mapper.GetIdByGuid(value.State.Executor.Guid),
                        EmployerId = Mapper.GetIdByGuid(value.State.Employer.Guid),
                        StartDate = state.StartDate,
                        TimeoutD = (short)state.Timeout.Days,
                        TimeoutH = (short)state.Timeout.Hours,
                        TimeoutM = (short)state.Timeout.Minutes,
                        IsCompleted = state.IsCompleted
                    };
                    _context.Tasks.Add(entity);
                    _context.SaveChanges();
                    return entity.Id;
                }
        }
        return default;
    }

    public async Task<List<Core.Entities.Task>> GetAll()
    {
        return _context.Tasks.Select(t => new Core.Entities.Task(t.ToDomainTask())).ToList();
    }

    public async Task<Core.Entities.Task> GetById(long id)
    {
        var state = _context.Tasks.FirstOrDefault(t => t.Id == id)!.ToDomainTask();
        if (state == null) {
            return null;
        }
        return new Core.Entities.Task(state);
    }

    public async System.Threading.Tasks.Task Remove(long id)
    {
        var state = _context.Tasks.FirstOrDefault(t => t.Id == id);
        if (state == null) {
            throw new InvalidOperationException("Объект не найден в таблице");
        }
        _context.Tasks.Remove(state);
        _context.SaveChanges();
    }

    public async System.Threading.Tasks.Task Update<V>(long id, V value) where V : TaskState
    {
        var state = _context.Tasks.FirstOrDefault(t => t.Id == id);
        if (state == null) {
            throw new InvalidOperationException("Объект не найден в таблице");
        }
        _context.Tasks.Remove(state);
        await Add(new Core.Entities.Task(value));
    }
}