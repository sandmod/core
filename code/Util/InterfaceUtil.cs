using System;
using System.Linq;
using Sandbox;

namespace Sandmod.Core.Util;

public static class InterfaceUtil
{
    /// <summary>
    /// Gets an <see cref="IComponent"/> from the client that is of the provided <b><typeparamref name="TComponent"/></b> type
    /// and implements the provided <b><typeparamref name="TInterface"/></b>.
    /// </summary>
    /// <typeparam name="TComponent">The component type</typeparam>
    /// <typeparam name="TInterface">The implemented interface</typeparam>
    /// <returns>The component as the <b><typeparamref name="TInterface"/></b></returns>
    public static TInterface GetComponentInterface<TComponent, TInterface>(this IEntity self)
        where TComponent : IComponent where TInterface : class
    {
        return self.Components.GetAll<TComponent>().FirstOrDefault(component => component is TInterface) as TInterface;
    }
}