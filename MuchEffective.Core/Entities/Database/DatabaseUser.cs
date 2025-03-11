
namespace MuchEffective.Core.Entities.Database;

public class DatabaseUser {
    public long Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public ICollection<DatabaseGroup> Groups { get; set; }
    public ICollection<DatabaseProject> Projects { get; set; }
    public User ToDomainUser() => new User(Login, Name, Surname);
}