
namespace MuchEffective.Core.Entities;

public class Group {
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public User Creator { get; set; }
    public ICollection<User> Members { get; set; }
}