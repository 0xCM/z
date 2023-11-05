//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly struct BfIntervals
{
    readonly Index<BfInterval> Data;

    public readonly uint Width;

    [MethodImpl(Inline)]
    public BfIntervals(BfInterval[] src)
    {
        Data = src;
        Width = src.Select(x => x.Width).Sum();
    }

    public uint Count
    {
        [MethodImpl(Inline)]
        get => Data.Count;
    }

    public ref BfInterval this[int i]
    {
        [MethodImpl(Inline)]
        get => ref Data[i];
    }

    public ref BfInterval this[uint i]
    {
        [MethodImpl(Inline)]
        get => ref Data[i];
    }

    public BfInterval[] Storage
    {
        [MethodImpl(Inline)]
        get => Data;
    }

    public ReadOnlySpan<BfInterval> View
    {
        [MethodImpl(Inline)]
        get => Data.View;
    }

    public ReadOnlySpan<BfInterval> Edit
    {
        [MethodImpl(Inline)]
        get => Data.Edit;
    }

    public string Format()
        => Bitfields.format(View);

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator BfIntervals(BfInterval[] src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator BfIntervals(Index<BfInterval> src)
        => new (src.Storage);

    [MethodImpl(Inline)]
    public static implicit operator BfInterval[](BfIntervals src)
        => src.Storage;
}
