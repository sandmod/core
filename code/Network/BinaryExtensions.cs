using System;
using System.Collections.Generic;
using System.IO;
using Sandbox;

namespace Sandmod.Core.Network;

public static class BinaryExtensions
{
    public static void Write(this BinaryWriter self, Type type)
    {
        // IEntity isn't available in the TypeLibrary
        self.Write(type == typeof(IEntity) ? -1 : TypeLibrary.GetType(type).Identity);
        var isGeneric = type.IsGenericType;
        self.Write(isGeneric);
        if (!isGeneric) return;
        var genericArguments = TypeLibrary.GetGenericArguments(type);
        self.Write(genericArguments.Length);
        foreach (var genericArgument in genericArguments)
        {
            self.Write(genericArgument);
        }
    }

    public static Type ReadType(this BinaryReader self)
    {
        var typeIdentity = self.ReadInt32();
        // IEntity isn't available in the TypeLibrary
        var type = typeIdentity == -1 ? typeof(IEntity) : TypeLibrary.GetTypeByIdent(typeIdentity).TargetType;
        var isGeneric = self.ReadBoolean();
        if (!isGeneric) return type;
        var count = self.ReadInt32();
        var genericArguments = new List<Type>();
        for (var i = 0; i < count; i++)
        {
            genericArguments.Add(self.ReadType());
        }

        return TypeLibrary.GetType(type).MakeGenericType(genericArguments.ToArray());
    }
}