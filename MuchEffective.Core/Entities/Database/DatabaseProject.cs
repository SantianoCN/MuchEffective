
namespace MuchEffective.Core.Entities;

public class DatabaseProject {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long ExecutorId { get; set; }
    public DatabaseUser Executor { get; set; }
    public long GroupId { get; set; }
    public DatabaseGroup Group { get; set; }
    public ICollection<DatabaseUser> Watchers { get; set; }
    public ProjectState State { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime Deadline { get; set; }
}