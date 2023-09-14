using System;

namespace Sandmod.Core.Provider;

/// <summary>
/// Used on providers to mark them as default providers for auto-injection.<br/>
/// They are meant to be replaced by actual providers marked with the <see cref="ProviderAttribute"/> or by higher priority default providers.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class DefaultProviderAttribute : Attribute
{
    public ProviderPriority Priority { get; } = ProviderPriority.Medium;

    public DefaultProviderAttribute()
    {
    }

    public DefaultProviderAttribute(ProviderPriority priority)
    {
        Priority = priority;
    }
}