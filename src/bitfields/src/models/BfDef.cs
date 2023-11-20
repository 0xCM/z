//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(StructLayout,Pack=1), Doc("Describes a bitfield")]
public readonly record struct BfDef
{
    /// <summary>
    /// The number of defined segments
    /// </summary>
    public readonly uint SegCount;

    /// <summary>
    /// The bitfield size
    /// </summary>
    public readonly DataSize Size;

    readonly Seq<BfSegDef> Data;

    [MethodImpl(Inline)]
    public BfDef(Seq<BfSegDef> segs, DataSize size)
    {        
        Size = size;
        SegCount = segs.Count;
        Data = segs;
    }

    public bool IsBitvector
    {
        [MethodImpl(Inline)]
        get => SegCount == Size.Packed;
    }

    public Span<BfSegDef> Segments
    {
        [MethodImpl(Inline)]
        get => Data.Edit;
    }

    [MethodImpl(Inline)]
    public ref BfSegDef Seg(uint i)
        => ref Data[i];

    public ref BfSegDef this[uint i]
    {
        [MethodImpl(Inline)]
        get => ref Seg(i);
    }

    [MethodImpl(Inline)]
    public uint SegWidth(uint i)
        => Seg(i).Width;

    [MethodImpl(Inline)]
    public uint SegStart(uint i)
        => Seg(i).MinPos;

    [MethodImpl(Inline)]
    public uint SegEnd(uint i)
        => Seg(i).Width;

    public string Format()
        => Bitfields.format(this);

    public override string ToString()
        => Format();
}
