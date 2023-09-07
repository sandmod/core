namespace Sandmod.Core.Provider;

/// <summary>
/// Priorities for the <see cref="DefaultProviderAttribute"/>.
/// </summary>
public enum ProviderPriority
{
    /// <summary>
    /// Value used by Sandmod internal default implementations.
    /// </summary>
    /// <remarks>
    /// It's the actual lowest priority and should only be used for Sandmod internal definitions.
    /// </remarks>
    Internal = -1,
    Lowest = 0,
    Low = 1,
    Medium = 2,
    High = 3,
    Highest = 4
}