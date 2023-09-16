using System.Collections.Generic;
using System.Linq;
using Sandbox;
using Sandmod.Core.Logger;

namespace Sandmod.Core.Provider;

/// <summary>
/// Factory used for creating instances for auto-injection.
/// </summary>
public static class ProviderFactory
{
    /// <summary>
    /// Creates instances of the provided type <b><typeparamref name="T"/></b> based on the <see cref="ProviderAttribute"/> and <see cref="DefaultProviderAttribute"/>.
    /// </summary>
    /// <typeparam name="T">The type to provide</typeparam>
    /// <returns>the created instances</returns>
    public static IReadOnlyList<T> Provide<T>() where T : class
    {
        var typeName = typeof(T).Name;
        var log = new SandmodLogger($"Provider/{typeof(T).Name}");
        log.Info($"Providing instances for {typeName} ...");

        var types = TypeLibrary.GetTypes<T>().ToList();

        // Check for none default provides
        var provideTypes = types.Where(type => type.HasAttribute<ProviderAttribute>()).ToList();
        if (provideTypes.Any())
        {
            log.Info($"Providing {provideTypes.Count} instance(s)");
            return provideTypes.Select(type => TypeLibrary.Create<T>(type.TargetType)).ToList();
        }

        types = types.Except(provideTypes).ToList();

        // Check for default provides
        var defaultTypes = types
            .Select(type => new KeyValuePair<TypeDescription, DefaultProviderAttribute>(type,
                TypeLibrary.GetAttribute<DefaultProviderAttribute>(type.TargetType)))
            .Where(pair => pair.Value != null)
            .GroupBy(pair => pair.Value.Priority)
            .OrderByDescending(group => group.Key)
            .ToList();
        if (defaultTypes.Any())
        {
            var defaultPriority = defaultTypes.First();
            if (defaultPriority.Count() > 1)
            {
                log.Warning(
                    $"Multiple default types found for the highest priority, using the first found: {string.Join(", ", defaultPriority.Select(pair => pair.Key.FullName))}");
            }

            var defaultType = defaultPriority.First();
            log.Info($"Providing default type: {defaultType.Key.FullName}");
            return new List<T> {TypeLibrary.Create<T>(defaultType.Key.TargetType)};
        }

        // Should not be reachable, unless not used properly
        log.Warning("Nothing found to provide. Normally there should be at least an internal default type");
        return new List<T>();
    }
}
