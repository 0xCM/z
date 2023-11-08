//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public readonly struct BfIntervals<F>
    where F : unmanaged
{
    public readonly uint Width;

    readonly Seq<BfInterval<F>> Data;

    [MethodImpl(Inline)]
    public BfIntervals(Seq<BfInterval<F>> src)
    {
        Data = src;
        Width = src.Map(x => x.Width).Sum();
    }

    public uint Count
    {
        [MethodImpl(Inline)]
        get => Data.Count;
    }

    public ref BfInterval<F> this[int i]
    {
        [MethodImpl(Inline)]
        get => ref Data[i];
    }

    public ref BfInterval<F> this[uint i]
    {
        [MethodImpl(Inline)]
        get => ref Data[i];
    }

    public BfInterval<F>[] Storage
    {
        [MethodImpl(Inline)]
        get => Data;
    }

    public ReadOnlySpan<BfInterval<F>> View
    {
        [MethodImpl(Inline)]
        get => Data.View;
    }

    public ReadOnlySpan<BfInterval<F>> Edit
    {
        [MethodImpl(Inline)]
        get => Data.Edit;
    }

    public BfIntervals Untype()
    {
        var dst = alloc<BfInterval>(Count);
        for(var i=0; i<Count; i++)
            seek(dst,i) = this[i];
        return dst;
    }

    public string Format()
        => Bitfields.format(View);

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator BfIntervals<F>(BfInterval<F>[] src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator BfIntervals<F>(Index<BfInterval<F>> src)
        => new (src.Storage);

    [MethodImpl(Inline)]
    public static implicit operator BfInterval<F>[](BfIntervals<F> src)
        => src.Storage;
}
