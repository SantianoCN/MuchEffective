
namespace MuchEffective.Core.Entities;

public class Comment{
    public Comment(User user, DateTime date, string text, Entities.Task task = null){
        User = user;
        PublishDate = date;
        Text = text;
        Task = task;
    }
    public User User { get; set; }
    public DateTime PublishDate { get; set; }
    public string Text { get; set; }
    public Task Task { get; set; }
}