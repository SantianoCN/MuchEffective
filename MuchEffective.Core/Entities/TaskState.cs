
namespace MuchEffective.Core.Entities;

public abstract class TaskState : Note {
    public TaskState(string name, string description, DateTime deadline, ICollection<Comment> comments,
        User executor, User employer) {
        Name = name;
        Description = description;
        Deadline = deadline;
        Comments = comments;
        Executor = executor;
        Employer = employer;
    }
    public string Description { get => Text; set { Text = value; }}
    public DateTime Deadline { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public User Executor { get; set; }
    public User Employer { get; set; }
    public abstract StartedTask Start(User user);
    public abstract CompletedTask Complete(User user, Comment result);
    public abstract ExpiredTask Expire();
}