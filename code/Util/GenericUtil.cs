using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandmod.Core.Util;

public static class GenericUtil
{
    public static bool HasGenericInterface(Type type, Type interfaceType)
    {
        return GetGenericInterfaces(type, interfaceType).Any();
    }

    public static IReadOnlyCollection<Type> GetGenericInterfaceTypes(Type type, Type interfaceType,
        int genericIndex = 0)
    {
        return GetGenericInterfaces(type, interfaceType)
            .Select(iType => TypeLibrary.GetGenericArguments(iType)[genericIndex]).ToList();
    }

    public static bool AllowsGenericInterfaceType(Type checkType, Type interfaceType, Type genericType,
        int genericIndex = 0)
    {
        return GetGenericInterfaceTypes(checkType, interfaceType, genericIndex)
            .Any(iType => iType.IsAssignableFrom(genericType));
    }

    private static IEnumerable<Type> GetGenericInterfaces(Type type, Type interfaceType)
    {
        return type.GetInterfaces()
            // iType.GetGenericTypeDefinition() is not whitelisted and there is no alternative: https://github.com/sboxgame/issues/issues/4033
            .Where(iType => iType.IsGenericType && CompareGenericTypeDefinition(iType, interfaceType));
    }

    private static bool CompareGenericTypeDefinition(Type type, Type genericType)
    {
        return type.FullName!.Split("[")[0] == genericType.FullName;
    }
}