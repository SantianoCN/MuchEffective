using MuchEffective.Core.Exceptions;

namespace MuchEffective.Core.Entities.Database;

public class DatabaseTask {
    public long Id { get; set; }
    public TaskStates State { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime Deadline { get; set; }
    public long ExecutorId { get; set; }
    public DatabaseUser Executor { get; set; }
    public long EmployerId { get; set; }
    public DatabaseUser Employer { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ColmpleteDate { get; set; }
    public bool IsChecked { get; set; }
    public long ResultCommentId { get; set; }
    public DatabaseComment ResultComment { get; set; }
    public short TimeoutD { get; set; }
    public short TimeoutH { get; set; }
    public short TimeoutM { get; set; }
    public bool IsCompleted { get; set; }
    public virtual ICollection<DatabaseComment> Comments { get; set; }
    public TaskState ToDomainTask() {
        switch (State) {
            case TaskStates.Planned:
                return new PlannedTask(Name, Description, Deadline, Comments
                    .Select(comm => comm.ToDomainComment())
                        .ToList(), Executor.ToDomainUser(), Employer.ToDomainUser());
            case TaskStates.Started:
                return new StartedTask(Name, Description, Deadline, Comments
                    .Select(comm => comm.ToDomainComment())
                        .ToList(), Executor.ToDomainUser(), Employer.ToDomainUser(), StartDate);
            case TaskStates.Completed:
                return new CompletedTask(Name, Description, Deadline, Comments
                    .Select(comm => comm.ToDomainComment())
                        .ToList(), Executor.ToDomainUser(), Employer.ToDomainUser(), StartDate, ResultComment.ToDomainComment());
            case TaskStates.Expired:
                return new ExpiredTask(Name, Description, Deadline, Comments
                    .Select(comm => comm.ToDomainComment())
                        .ToList(), Executor.ToDomainUser(), Employer.ToDomainUser(), StartDate); 
            case TaskStates.Deleted:
                return null;
            default:
                throw new UndefinedTypeException("Неопознанный тип задачи");
        }
    }
}