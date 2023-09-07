using System;

namespace Sandmod.Core.Provider;

/// <summary>
/// Used on providers to mark them for auto-injection.<br/>
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class ProviderAttribute : Attribute
{
}