
namespace MuchEffective.Core.Entities;

public class Comment{
    public User User { get; set; }
    public DateTime PublishDate { get; set; }
    public string Text { get; set; }
    public Task Task { get; set; }
}