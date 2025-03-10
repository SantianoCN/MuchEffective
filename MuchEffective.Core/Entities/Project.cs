
namespace MuchEffective.Core.Entities;

public enum ProjectState {
    Planning,
    Planned,
    Starting,
    Running,
    Ending,
    Completed
}
public class Project {
    public string Name { get; set; }
    public string Description { get; set; }
    public User Executor { get; set; }
    public Group Group { get; set; }
    public ICollection<User> Watchers { get; set; }
    public ICollection<Entities.Task> Tasks { get; set; }
    public ProjectState State { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime Deadline { get; set; }
}