using System.Linq;
using Sandbox;

namespace Sandmod.Core.Client;

public static class ClientExtensions
{
    /// <summary>
    /// Gets the offline representation of the <see cref="IClient"/>.
    /// </summary>
    /// <returns>The offline representation of the <see cref="IClient"/></returns>
    public static OfflineClient Offline(this IClient self)
    {
        return OfflineClient.From(self);
    }

    /// <summary>
    /// Tries to get the online <see cref="IClient"/> for the <see cref="IOfflineClient"/>.
    /// </summary>
    /// <param name="client">Output of the <see cref="IClient"/> if the method was successful</param>
    /// <returns>If the method was successful</returns>
    public static bool TryGetOnline(this IOfflineClient self, out IClient? client)
    {
        if (Entity.All.FirstOrDefault(entity => entity is IClient c && c.SteamId == self.SteamId) is not IClient
            onlineClient)
        {
            client = null;
            return false;
        }

        client = onlineClient;
        return true;
    }
}