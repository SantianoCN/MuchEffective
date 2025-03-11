
namespace MuchEffective.Core.Entities;

public abstract class TaskState {
    public TaskState(string name, string description, DateTime deadline, ICollection<Comment> comments,
        User executor, User employer) {
        Name = name;
        Description = description;
        Deadline = deadline;
        Comments = comments;
        Executor = executor;
        Employer = employer;
    }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public User Executor { get; set; }
    public User Employer { get; set; }
    public abstract StartedTask Start(User user);
    public abstract CompletedTask Complete(User user, Comment result);
    public abstract ExpiredTask Expire();
}