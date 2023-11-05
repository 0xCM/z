//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public readonly record struct BfDef<T>
    where T : unmanaged
{
    /// <summary>
    /// The model name
    /// </summary>
    public readonly string Name;

    /// <summary>
    /// The number of defined segments
    /// </summary>
    public readonly uint SegCount;

    /// <summary>
    /// The bitfield size
    /// </summary>
    public readonly DataSize Size;

    readonly Index<BfSegDef<T>> Data;

    [MethodImpl(Inline)]
    public BfDef(string name, Index<BfSegDef<T>> segments, DataSize size)
    {
        Name = name;
        SegCount = segments.Count;
        Data = segments;
        Size = size;
    }

    public ref BfSegDef<T> this[uint i]
    {
        [MethodImpl(Inline)]
        get => ref Data[i];
    }

    public Span<BfSegDef<T>> Segments
    {
        [MethodImpl(Inline)]
        get => Data.Edit;
    }

    [MethodImpl(Inline)]
    public uint Width(int index)
        => Seg(index).Width;

    [MethodImpl(Inline)]
    public uint Position(int index)
        => bw32(Seg(index).MinPos);

    [MethodImpl(Inline)]
    public ref BfSegDef<T> Seg(int index)
        => ref Data[index];
}
