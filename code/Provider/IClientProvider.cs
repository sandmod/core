using Sandbox;

namespace Sandmod.Core.Provider;

/// <summary>
/// Provider type for providing components.
/// </summary>
/// <typeparam name="TProvided">Provided type</typeparam>
public interface IClientProvider<out TProvided>
{
    /// <summary>
    /// Provides components for a <see cref="IClient" />
    /// </summary>
    /// <param name="client">Client to provide components for</param>
    /// <returns>Provided components</returns>
    TProvided Provide(IClient client);
}