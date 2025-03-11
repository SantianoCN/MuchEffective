using MuchEffective.Core.Exceptions;

namespace MuchEffective.Core.Entities;

public class ExpiredTask : TaskState
{
     public ExpiredTask(string name, string description, DateTime deadline, ICollection<Comment> comments,
        User executor, User employer, DateTime startDate) : base(name, description, deadline, comments, executor, employer) { }
    public TimeSpan Timeout { get; set; }
    public bool IsCompleted { get; set; }
    public override StartedTask Start(User user)
    {
        throw new InvalidOperationException("Операция не доступна");
    }
    public override CompletedTask Complete(User user, Comment result)
    {
        if (user == Executor) {
            IsCompleted = true;
            return new CompletedTask(Name, Description, Deadline, Comments, Executor, Employer, DateTime.Now, result);
        } else throw new PermissionException("Не прав для выполненияя этой операции");
    }
    public override ExpiredTask Expire()
    {
        return this;
    }
}