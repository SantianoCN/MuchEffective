
using Microsoft.Extensions.Configuration.UserSecrets;
using MuchEffective.Core.Entities;

namespace MuchEffective.Core.Contracts;

public interface ITaskService {
    /// <summary>
    /// Интерфейс сервиса для работы с индивидуальными задачами
    /// </summary>
    /// <param name="userId">Уникальный идентификатор пользователя</param>
    /// <param name="taskId">Уникальный идентификатор задачи</param>
    /// <param name="noteId">Уникальный идентификатор заметки</param>
    /// 
    /// <returns>Возвращает объект DTO или словарь, где ключ: uuid, значение: имя пользователя или название задачи/заметки/проекта</returns>
    Task<IDictionary<Guid, Guid>> GetClientNotesList(Guid userId);
    Task<Entities.Note> GetNote(Guid userId, Guid noteId);
    Task<IDictionary<Guid, Guid>> GetClientTasksList(Guid userId);
    Task<Entities.Task> GetTask(Guid userId, Guid taskId);
    System.Threading.Tasks.Task CreateTask(Guid userId, Guid taskId, Entities.Task task);
    System.Threading.Tasks.Task UpdateTask(Guid userId, Guid taskId, Entities.Task task);
    System.Threading.Tasks.Task DeleteTask(Guid userId, Guid taskId);
}