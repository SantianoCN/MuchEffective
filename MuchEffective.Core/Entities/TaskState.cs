using MuchEffective.Core.Entities;

namespace MuchEffective.Core.Contracts;

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
    public abstract CompletedTask Complete(User user);
    public abstract ExpiredTask Expire();
}