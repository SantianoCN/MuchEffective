using MuchEffective.Core.Exceptions;

namespace MuchEffective.Core.Entities;

public class StartedTask : TaskState
{
    public StartedTask(string name, string description, DateTime deadline, ICollection<Comment> comments,
        User executor, User employer, DateTime startDate) : base(name, description, deadline, comments, executor, employer) {
            StartDate = startDate;
        }
    public DateTime StartDate { get; set; }
    public override StartedTask Start(User user)
    {
        return this;
    }
    public override CompletedTask Complete(User user, Comment result)
    {
        if (user == Executor) {
            return new CompletedTask(Name, Description, Deadline, Comments, Executor, Employer, DateTime.Now, result);
        } else throw new PermissionException("Не прав для выполненияя этой операции");
    }

    public override ExpiredTask Expire()
    {
        return new ExpiredTask(Name, Description, Deadline, Comments, Executor, Employer, DateTime.Now);
    }
}