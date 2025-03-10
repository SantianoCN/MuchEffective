
using MuchEffective.Core.Contracts;

namespace MuchEffective.Core.Entities;

public class ExpiredTask : TaskState
{
    public TimeSpan Timeout { get; set; }
    public bool IsCompleted { get; set; }
    protected override StartedTask Start()
    {
        throw new NotImplementedException();
    }
    protected override CompletedTask Complete()
    {
        throw new NotImplementedException();
    }
    protected override ExpiredTask Expire()
    {
        throw new NotImplementedException();
    }
}