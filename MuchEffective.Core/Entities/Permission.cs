
namespace MuchEffective.Core.Entities;

public class Permission {
    public Guid Guid { get; set; }
    public bool WatchProject { get; set; }
    public bool ChangeProject { get; set; }
    public bool InviteUsers { get; set; }
    public bool ExcludeUsers { get; set; }
    public bool CreateTasks { get; set; }
    public bool ChangeTasks { get; set; }
    public bool RemoveTasks { get; set; }
    public bool ExecuteTasks { get; set; }
}