using System;
using System.Collections;
using System.Collections.Generic;
using Sandbox;

namespace Sandmod.Core.Components;

/// <summary>
/// <b>WARNING!</b>
/// <br/><br/>
/// Work in progress, use at own risk as this might change drastically.
/// </summary>
public interface IComponentSystem<in TComponent>
{
    /// <summary>
    /// Create the component.
    /// </summary>
    T Create<T>(bool startEnabled = true) where T : class, TComponent, new();

    /// <summary>
    /// Get the component, create if it doesn't exist.
    /// Will include disabled components in search.
    /// </summary>
    T GetOrCreate<T>(bool startEnabled = true) where T : class, TComponent, new();

    /// <summary>
    /// Get a component by type, if it exists.
    /// </summary>
    T Get<T>(bool includeDisabled = false) where T : class, TComponent;

    /// <summary>
    /// Returns true if component was found, else false,
    /// </summary>
    bool TryGet<T>(out T component, bool includeDisabled = false) where T : class, TComponent;

    /// <summary>
    /// Get all components by type, if any exist
    /// </summary>
    IEnumerable<T> GetAll<T>(bool includeDisabled = false) where T : class, TComponent;

    /// <summary>
    /// Add component to this system.
    /// </summary>
    bool Add(TComponent component);

    /// <summary>
    /// Remove given component from this system.
    /// </summary>
    bool Remove(TComponent component);

    /// <summary>
    /// Remove all components of given type.
    /// </summary>
    bool RemoveAny(Type type);

    /// <summary>
    /// Remove all components of given type
    /// </summary>
    bool RemoveAny<T>() where T : TComponent;

    /// <summary>
    /// Remove all components to this entity
    /// </summary>
    void RemoveAll();

    /// <summary>
    /// The amount of components, including disabled
    /// </summary>
    int Count { get; }
}