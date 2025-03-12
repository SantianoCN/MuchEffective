using Microsoft.Extensions.Configuration.UserSecrets;
using MuchEffective.Core.Entities;

namespace MuchEffective.Core.Contracts;

public interface IProjectService {
    /// <summary>
    /// Интерфейс сервиса для работы с проектом
    /// </summary>
    /// <param name="userId">Уникальный идентификатор пользователя</param>
    /// <param name="projectId">Уникальный идентификатор пользователя</param>
    /// <returns></returns>
    Task<IDictionary<string, string>> GetProjectsList(string userId);
    Task<Project> GetProject(string userId, string projectId);
    Task<Group> GetGroup(string userId, string projectId);
    Task<IDictionary<string, string>> GetGroupMembers(string userId, string projectId);
    Task<IDictionary<string, string>> GetProjectTasksList(string userId, string projectId);
    Task<Permission> GetProjectPermissions(string userId, string projectId);
    Task<string> CreateProject(string userId, Project project);
    Task<string> UpdateProject(string userId, string projectId, Project project);
    Task<string> DeleteProject(string userId, string projectId);
    Task<string> UpdatePermission(string userId, string userId1, string projectId, Permission permission);
    Task<string> CreateTaskForProjectMember(string userId, string userId1, string pojectId, Entities.Task task);
    Task<string> UpdateTaskForProjectMember(string userId, string taskId, Entities.Task task);
    Task<string> DeleteTaskForProjectMember(string userId, string taskId);
}