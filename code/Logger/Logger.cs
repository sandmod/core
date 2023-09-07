namespace Sandmod.Core.Logger;

/// <summary>
/// Sandmod logger.
/// </summary>
public class SandmodLogger : Sandbox.Diagnostics.Logger
{
    public SandmodLogger(string module) : base($"Sandmod/{module}") {}
}