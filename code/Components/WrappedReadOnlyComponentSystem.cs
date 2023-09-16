using System.Collections.Generic;
using Sandbox;

namespace Sandmod.Core.Components;

/// <summary>
/// <b>WARNING!</b>
/// <br/><br/>
/// Work in progress, use at own risk as this might change drastically.
/// </summary>
public class WrappedReadOnlyComponentSystem<TComponent> : IReadOnlyComponentSystem<TComponent>
    where TComponent : IComponent
{
    private readonly IComponentSystem ComponentSystem;

    public WrappedReadOnlyComponentSystem(IComponentSystem componentSystem)
    {
        ComponentSystem = componentSystem;
    }

    public T Get<T>(bool includeDisabled = false) where T : TComponent
    {
        return ComponentSystem.Get<T>(includeDisabled);
    }

    public bool TryGet<T>(out T component, bool includeDisabled = false) where T : TComponent
    {
        return ComponentSystem.TryGet(out component, includeDisabled);
    }

    public IEnumerable<T> GetAll<T>(bool includeDisabled = false) where T : TComponent
    {
        return ComponentSystem.GetAll<T>(includeDisabled);
    }

    public int Count => ComponentSystem.Count;
}