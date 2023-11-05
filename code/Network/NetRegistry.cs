using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Sandbox;

namespace Sandmod.Core.Network;

public sealed class NetRegistry<T> : IReadOnlyDictionary<ulong, T> where T : class, INetworkSerializable
{
    private Dictionary<ulong, T> Networked { get; } = new();

    private ulong LastNetworkIdent { get; set; } = 1;
    private ulong NextNetworkIdent => LastNetworkIdent++;

    private readonly Action<BinaryWriter, T> _identWriter;

    private readonly Func<BinaryReader, ulong, T> _identReader;

    public NetRegistry(Action<BinaryWriter, T> identWriter, Func<BinaryReader, ulong, T> identReader)
    {
        _identWriter = identWriter;
        _identReader = identReader;
    }

    public void Write(BinaryWriter writer, T networked)
    {
        RegisterServer(networked);

        writer.Write(networked.NetworkIdent);
        _identWriter(writer, networked);

        using var stream = new MemoryStream();
        using var networkedWriter = new BinaryWriter(stream);
        networked.NetWrite(networkedWriter);
        var data = stream.ToArray();
        writer.Write(data.Length);
        writer.Write(data);
    }

    public T Read(BinaryReader reader)
    {
        var networkIdent = reader.ReadUInt64();
        var networked = _identReader(reader, networkIdent);
        RegisterClient(networked, networkIdent);

        var totalBytes = reader.ReadInt32();
        var data = reader.ReadBytes(totalBytes);
        using var stream = new MemoryStream(data);
        using var networkedReader = new BinaryReader(stream);
        networked.NetRead(networkedReader);
        return networked;
    }

    private void RegisterServer(T networked)
    {
        if (!Game.IsServer) return;

        if (TryGetValue(networked.NetworkIdent, out var foundNetworked))
        {
            if (networked == foundNetworked) return;
            // Should only happen if someone messes with the NetworkIdent
            networked.NetworkIdent = NextNetworkIdent;
            Networked.Add(networked.NetworkIdent, networked);
        }
        else
        {
            // Container was not networked yet
            networked.NetworkIdent = NextNetworkIdent;
            Networked.Add(networked.NetworkIdent, networked);
        }
    }

    private void RegisterClient(T networked, ulong networkIdent)
    {
        if (!Game.IsClient) return;

        networked.NetworkIdent = networkIdent;
        if (!ContainsKey(networked.NetworkIdent))
        {
            Networked.Add(networked.NetworkIdent, networked);
        }
    }
    
    // Implement IReadOnlyDictionary

    public T this[ulong key] => Networked[key];
    public IEnumerable<ulong> Keys => Networked.Keys;
    public IEnumerable<T> Values => Networked.Values;
    public int Count => Networked.Count;
    
    public bool ContainsKey(ulong key)
    {
        return Networked.ContainsKey(key);
    }

    public bool TryGetValue(ulong key, out T value)
    {
        return Networked.TryGetValue(key, out value);
    }

    public IEnumerator<KeyValuePair<ulong, T>> GetEnumerator()
    {
        return Networked.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}