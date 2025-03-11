
using Microsoft.Extensions.Configuration.UserSecrets;
using MuchEffective.Core.Entities;

namespace MuchEffective.Core.Contracts;

public interface ITaskService {
    /// <summary>
    /// Методы бизнес логики приложения
    /// </summary>
    /// <param name="userId">Уникальный идентификатор пользователя</param>
    /// <param name="taskId">Уникальный идентификатор задачи</param>
    /// <param name="projectId">Уникальный идентификатор проекта</param>
    /// 
    /// <returns>Возвращает объект DTO или словарь, где ключ: uuid, значение: имя пользователя или название задачи/заметки/проекта</returns>
    Task<IDictionary<string, string>> GetClientNotesList(string userId);
    Task<Entities.Note> GetNote(string userId, string noteId);
    Task<IDictionary<string, string>> GetClientTasksList(string userId);
    Task<Entities.Task> GetTask(string userId, string taskId);
    Task<IDictionary<string, string>> GetProjectsList(string userId);
    Task<Project> GetProject(string userId, string projectId);
    Task<Group> GetGroup(string userId, string projectId);
    Task<IDictionary<string, string>> GetGroupMembers(string userId, string projectId);
    Task<User> GetUser(string userId, string uuid);
    Task<IDictionary<string, string>> GetProjectTasksList(string userId, string projectId);
    Task<Permission> GetProjectPermissions(string userId, string projectId);
    // . . .
}