
namespace MuchEffective.Core.Entities;

public class Note {
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public DateTime CreationDate { get; set; }
}