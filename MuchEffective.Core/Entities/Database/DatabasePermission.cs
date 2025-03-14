
namespace MuchEffective.Core.Entities.Database;

public class DatabasePermission {
    public long Id { get; set; }
    public bool WatchProject { get; set; }
    public bool ChangeProject { get; set; }
    public bool InviteUsers { get; set; }
    public bool ExcludeUsers { get; set; }
    public bool CreateTasks { get; set; }
    public bool ChangeTasks { get; set; }
    public bool RemoveTasks { get; set; }
    public bool ExecuteTasks { get; set; }
    public long UserId { get; set; }
    public DatabaseUser User { get; set; } 
}