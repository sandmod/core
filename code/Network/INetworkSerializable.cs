using System.IO;

namespace Sandmod.Core.Network;

public interface INetworkSerializable
{
    ulong NetworkIdent { get; set; }

    bool IsDirty { get; set; }

    delegate void MarkedDirty();

    event MarkedDirty OnMarkedDirty;

    void NetWrite(BinaryWriter writer);

    void NetRead(BinaryReader reader);
}