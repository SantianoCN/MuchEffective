
namespace MuchEffective.Core.Entities.Database;

public class DatabaseGroup {
    public long Id { get; set; }
    public string Name { get; set; }
    public long CreatorId { get; set; }
    public DatabaseUser Creator { get; set; }
    public ICollection<DatabaseUser> Members { get; set; }
}