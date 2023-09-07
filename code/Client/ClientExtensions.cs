using Sandbox;

namespace Sandmod.Core.Client;

public static class ClientExtensions
{
    /// <summary>
    /// Get the offline representation of the <see cref="IClient"/>.
    /// </summary>
    /// <returns>The offline representation of the <see cref="IClient"/></returns>
    public static OfflineClient Offline(this IClient self)
    {
        return OfflineClient.From(self);
    }
}