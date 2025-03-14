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
    Task<IDictionary<Guid, Guid>> GetProjectsList(Guid userId);
    Task<Project> GetProject(Guid userId, Guid projectId);
    Task<Group> GetGroup(Guid userId, Guid projectId);
    Task<IDictionary<Guid, Guid>> GetGroupMembers(Guid userId, Guid projectId);
    Task<IDictionary<Guid, Guid>> GetProjectTasksList(Guid userId, Guid projectId);
    Task<Permission> GetProjectPermissions(Guid userId, Guid projectId);
    Task<string> CreateProject(Guid userId, Project project);
    Task<string> UpdateProject(Guid userId, Guid projectId, Project project);
    Task<string> DeleteProject(Guid userId, Guid projectId);
    Task<string> UpdatePermission(Guid userId, Guid userId1, Guid projectId, Permission permission);
    Task<string> CreateTaskForProjectMember(Guid userId, Guid userId1, Guid pojectId, Entities.Task task);
    Task<string> UpdateTaskForProjectMember(Guid userId, Guid taskId, Entities.Task task);
    Task<string> DeleteTaskForProjectMember(Guid userId, Guid taskId);
}