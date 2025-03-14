
using MuchEffective.Core.Contracts;

namespace MuchEffective.Core.Entities;

public class CompletedTask : TaskState
{
    public Guid Guid { get; set; }
    public CompletedTask(string name, string description, DateTime deadline, ICollection<Comment> comments,
        User executor, User employer, DateTime completeDate, Comment result) : base(name, description, deadline, comments, executor, employer) {
            completeDate = completeDate;
            Result = result;
        }
    public DateTime StartDate { get; set; }
    public DateTime ColmpleteDate { get; set; }
    public bool IsChecked { get; set; }
    public Comment Result { get; set; }
    public override StartedTask Start(User user)
    {
        throw new InvalidOperationException("Операция не доступна");
    }
    public override CompletedTask Complete(User user, Comment result)
    {
        return this;
    }
    public override ExpiredTask Expire()
    {
        throw new InvalidOperationException("Операция не доступна");
    }
}