using Microsoft.AspNetCore.Authentication.OAuth;
using MuchEffective.Core.Contracts;
using MuchEffective.Core.Entities;
using MuchEffective.Core.Exceptions;
using MuchEffective.UseCases.Persistence;
using Npgsql.Replication;

namespace MuchEffective.UseCases.Services;

public class TaskService : ITaskService
{
    private readonly IConfiguration _conf;
    private readonly ILogger<TaskService> _logger;
    private readonly IRepository<Core.Entities.Task> _repository;
    public TaskService(IConfiguration configuration, ILogger<TaskService> logger, IRepository<Core.Entities.Task> repository, Mapper mapper) {
        _conf = configuration;
        _logger = logger;
        _repository = repository;
    }
    public async System.Threading.Tasks.Task CreateTask(Guid userId, Guid taskId, Core.Entities.Task task)
    {
        long id = await _repository.Add(task);
        Mapper.GetGuidById(id);
    }

    public System.Threading.Tasks.Task DeleteTask(Guid userId, Guid taskId)
    {
        throw new NotImplementedException();
    }

    public Task<IDictionary<Guid, Guid>> GetClientNotesList(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<IDictionary<Guid, Guid>> GetClientTasksList(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<Note> GetNote(Guid userId, Guid noteId)
    {
        throw new NotImplementedException();
    }

    public Task<Core.Entities.Task> GetTask(Guid userId, Guid taskId)
    {
        if (Mapper.GetIdByGuid(userId) < 0 && Mapper.GetIdByGuid(taskId) < 0) {
            throw new PermissionException("Нет доступа к данным");
        }
        _repository.GetById(Mapper.GetIdByGuid(taskId));
    }

    public System.Threading.Tasks.Task UpdateTask(Guid userId, Guid taskId, Core.Entities.Task task)
    {
        throw new NotImplementedException();
    }
}