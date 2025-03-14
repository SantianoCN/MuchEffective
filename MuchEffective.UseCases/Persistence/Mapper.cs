
namespace MuchEffective.UseCases.Persistence;

public class Mapper
{
    private static Dictionary<Guid, long> _map = new();
    private static Dictionary<long, Guid> _remap = new();
    public static Guid GetGuidById(long id)
    {
        if (_remap.ContainsKey(id))
        {
            return _remap[id];
        } else
        {
            var guid = Guid.NewGuid();
            _map[guid] = id;
            _remap[id] = guid;
            return guid;
        }
    }
    public static long GetIdByGuid(Guid guid)
    {
        if (_map.ContainsKey(guid))
        {
            return _map[guid];
        } else return -1;
    }
}