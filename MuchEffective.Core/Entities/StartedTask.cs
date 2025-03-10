
using MuchEffective.Core.Contracts;

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
            // ... creating and publishing result(comment)
            return new CompletedTask(Name, Description, Deadline, Comments, Executor, Employer, DateTime.Now, new Comment() /*  */);
        }
    }

    public override ExpiredTask Expire()
    {
        
    }
}