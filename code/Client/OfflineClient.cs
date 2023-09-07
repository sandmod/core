using System.Linq;
using Sandbox;

namespace Sandmod.Core.Client;

#nullable enable

public sealed partial class OfflineClient : BaseNetworkable
{
    [Net] public long SteamId { get; private set; }
    
    [Net] public string? Name { get; private set; }

    public OfflineClient() {}
    
    public OfflineClient(long steamId)
    {
        SteamId = steamId;
    }

    public OfflineClient(long steamId, string name)
    { 
        SteamId = steamId;
        Name = name;
    }

    public static OfflineClient From(IClient client)
    {
        return new OfflineClient(client.SteamId, client.Name);
    }
    
    public bool TryGetOnline(out IClient? client)
    {
        if (Entity.All.FirstOrDefault(entity => entity is IClient c && c.SteamId == SteamId) is not IClient onlineClient)
        {
            client = null;
            return false;
        }
        client = onlineClient;
        return true;
    } 
}