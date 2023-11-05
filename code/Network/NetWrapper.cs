using System.IO;
using Sandbox;

namespace Sandmod.Core.Network;

public abstract class NetWrapper<T> : BaseNetworkable, INetworkSerializer where T : class, INetworkSerializable
{
    protected abstract NetRegistry<T> InternalRegistry { get; }

    public T Networked { get; private set; }

    private uint Version;

    protected NetWrapper()
    {
    }

    protected NetWrapper(T networked)
    {
        Game.AssertServer();

        Networked = networked;
        Networked.OnMarkedDirty += () =>
        {
            WriteNetworkData();
            Networked.IsDirty = false;
        };
    }

    public void Write(NetWrite write)
    {
        write.Write(++Version);

        using var stream = new MemoryStream();
        using var writer = new BinaryWriter(stream);
        InternalRegistry.Write(writer, Networked);

        var data = stream.ToArray();
        write.Write(data.Length);
        write.Write(data);
    }

    public void Read(ref NetRead read)
    {
        var version = read.Read<uint>();

        var totalBytes = read.Read<int>();
        var data = new byte[totalBytes];
        read.ReadUnmanagedArray(data);

        if (version == Version) return;
        Version = version;

        using var stream = new MemoryStream(data);
        using var reader = new BinaryReader(stream);
        Networked = InternalRegistry.Read(reader);
    }
}