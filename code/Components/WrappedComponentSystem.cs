using System;
using System.Collections.Generic;
using Sandbox;

namespace Sandmod.Core.Components;

/// <summary>
/// <b>WARNING!</b>
/// <br/><br/>
/// Work in progress, use at own risk as this might change drastically.
/// </summary>
public class WrappedComponentSystem<TComponent> : IComponentSystem<TComponent> where TComponent : IComponent
{
    private readonly IComponentSystem ComponentSystem;

    public WrappedComponentSystem(IComponentSystem componentSystem)
    {
        ComponentSystem = componentSystem;
    }

    public bool Remove(TComponent component)
    {
        return ComponentSystem.Remove(component);
    }

    public bool Add(TComponent component)
    {
        return ComponentSystem.Add(component);
    }

    public T Get<T>(bool includeDisabled = false) where T : class, TComponent
    {
        return ComponentSystem.Get<T>(includeDisabled);
    }

    public bool TryGet<T>(out T component, bool includeDisabled = false) where T : class, TComponent
    {
        return ComponentSystem.TryGet(out component, includeDisabled);
    }

    public T Create<T>(bool startEnabled = true) where T : class, TComponent, new()
    {
        return ComponentSystem.Create<T>(startEnabled);
    }

    public T GetOrCreate<T>(bool startEnabled = true) where T : class, TComponent, new()
    {
        return ComponentSystem.GetOrCreate<T>(startEnabled);
    }

    public bool RemoveAny(Type type)
    {
        return ComponentSystem.RemoveAny(type);
    }

    public bool RemoveAny<T>() where T : TComponent
    {
        return ComponentSystem.RemoveAny<T>();
    }

    public IEnumerable<T> GetAll<T>(bool includeDisabled = false) where T : class, TComponent
    {
        return ComponentSystem.GetAll<T>(includeDisabled);
    }

    public void RemoveAll()
    {
        ComponentSystem.RemoveAll();
    }

    public int Count => ComponentSystem.Count;

    public IReadOnlyComponentSystem<TComponent> AsReadOnly()
    {
        return new WrappedReadOnlyComponentSystem<TComponent>(ComponentSystem);
    }
}