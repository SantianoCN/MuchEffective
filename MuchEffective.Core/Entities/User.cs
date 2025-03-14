
namespace MuchEffective.Core.Entities;

public class User {
    public User(string login, string name, string surname) {
        Login = login;
        Name = name;
        Surname = surname;
    }
    public Guid Guid { get; set; }
    public string Login { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}