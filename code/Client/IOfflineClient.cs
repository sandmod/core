using Sandbox.Internal;

namespace Sandmod.Core.Client;

#nullable enable

public interface IOfflineClient : INetworkTable
{
    public long SteamId { get; }

    public string? Name { get; }
}