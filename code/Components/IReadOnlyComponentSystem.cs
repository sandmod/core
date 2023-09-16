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
public interface IReadOnlyComponentSystem<in TComponent> where TComponent : IComponent
{
    /// <summary>
    /// Get a component by type, if it exists.
    /// </summary>
    T Get<T>(bool includeDisabled = false) where T : TComponent;

    /// <summary>
    /// Returns true if component was found, else false,
    /// </summary>
    bool TryGet<T>(out T component, bool includeDisabled = false) where T : TComponent;

    /// <summary>
    /// Get all components by type, if any exist
    /// </summary>
    IEnumerable<T> GetAll<T>(bool includeDisabled = false) where T : TComponent;

    /// <summary>
    /// The amount of components, including disabled
    /// </summary>
    int Count { get; }
}