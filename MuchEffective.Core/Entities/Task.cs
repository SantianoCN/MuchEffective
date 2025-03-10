using MuchEffective.Core.Contracts;

namespace MuchEffective.Core.Entities;

public class Task {
    public Task(TaskState state) {
        State = state;
    }
    public TaskState State { get; set; }
    public StartedTask Start() => State.Start();
    public CompletedTask Complete() => State.Complete();
    public ExpiredTask Expire() => State.Expire();
}