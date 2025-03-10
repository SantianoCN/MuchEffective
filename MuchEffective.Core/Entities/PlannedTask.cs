
using MuchEffective.Core.Contracts;

namespace MuchEffective.Core.Entities;

public class PlannedTask : TaskState
{
    public PlannedTask(string name, string description, DateTime deadline, ICollection<Comment> comments,
        User executor, User employer) : base(name, description, deadline, comments, executor, employer) { }
    public override StartedTask Start(User user)
    {
        return new StartedTask(Name, Description, Deadline, Comments, Executor, Employer, DateTime.Now);   
    }
    public override CompletedTask Complete(User user, Comment result)
    {
        return new InvalidOperationException();
    }
    public override ExpiredTask Expire()
    {
        throw new NotImplementedException();
    }
}