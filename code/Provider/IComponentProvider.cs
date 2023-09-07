using System.Collections.Generic;
using Sandbox;

namespace Sandmod.Core.Provider;

/// <summary>
/// Provider type for providing components.
/// </summary>
/// <typeparam name="TComponent">Component type</typeparam>
public interface IComponentProvider<out TComponent> where TComponent : IComponent
{
    /// <summary>
    /// Provides components for a <see cref="IClient"/>
    /// </summary>
    /// <param name="client">Client to provide components for</param>
    /// <returns>Provided components</returns>
    IReadOnlyCollection<TComponent> ProvideComponents(IClient client);
}