using System;
using System.Linq;

namespace Sandmod.Core.Util;

public static class TypeUtil
{
    public static Type GetImplementingInterfaceType(Type type, Type interfaceType)
    {
        var typeDescription = TypeLibrary.GetType(type);
        while (true)
        {
            if (typeDescription.IsInterface && type.GetInterfaces().Contains(interfaceType)) return type;
            if (typeDescription.BaseType == null) return null;
            type = typeDescription.BaseType.GetType();
        }
    }
}