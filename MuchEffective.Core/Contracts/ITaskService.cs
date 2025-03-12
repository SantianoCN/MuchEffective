
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
    Task<IDictionary<string, string>> GetClientNotesList(string userId);
    Task<Entities.Note> GetNote(string userId, string noteId);
    Task<IDictionary<string, string>> GetClientTasksList(string userId);
    Task<Entities.Task> GetTask(string userId, string taskId);
    System.Threading.Tasks.Task CreateTask(string userId, string taskId, Entities.Task task);
    System.Threading.Tasks.Task UpdateTask(string userId, string taskId, Entities.Task task);
    System.Threading.Tasks.Task DeleteTask(string userId, string taskId);
}