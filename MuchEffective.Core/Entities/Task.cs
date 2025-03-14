using MuchEffective.Core.Contracts;

namespace MuchEffective.Core.Entities;

public class Task {
    public Task(TaskState state) {
        State = state;
    }
    public Guid Guid { get; set; }
    public TaskState State { get; private set; }
    public StartedTask Start(User user) => State.Start(user);
    public CompletedTask Complete(User user, Comment result) => State.Complete(user, result);
    public ExpiredTask Expire() => State.Expire();
}