
using System.Runtime.InteropServices.Marshalling;

namespace MuchEffective.Core.Entities.Database;

public class DatabaseComment{
    public long Id { get; set; }
    public long UserId { get; set; }
    public DatabaseUser User { get; set; }
    public DateTime PublishDate { get; set; }
    public string Text { get; set; }
    public long TaskId { get; set; }
    public DatabaseTask Task { get; set; }
    public Comment ToDomainComment(){
        return new Comment(User.ToDomainUser(), PublishDate, Text);
    }
}