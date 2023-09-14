using Sandbox;

namespace Sandmod.Core.Client;

#nullable enable

public sealed partial class OfflineClient : BaseNetworkable, IOfflineClient
{
    [Net] public long SteamId { get; private set; }

    [Net] public string? Name { get; private set; }

    public OfflineClient()
    {
    }

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
}