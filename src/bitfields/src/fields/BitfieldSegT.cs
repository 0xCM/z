//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(LayoutKind.Sequential,Pack=1)]
public readonly record struct BitfieldSeg<T>
    where T : unmanaged
{
    /// <summary>
    /// The segment value
    /// </summary>
    public readonly T Value;

    /// <summary>
    /// The index of the first bit in the segment
    /// </summary>
    public readonly byte Offset;

    /// <summary>
    /// The segment width
    /// </summary>
    public readonly byte Width;

    [MethodImpl(Inline)]
    public BitfieldSeg(T value, byte offset, byte width)
    {
        Value = value;
        Offset = offset;
        Width = width;
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Width == 0;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Width != 0;
    }

    public uint EndPos
    {
        [MethodImpl(Inline)]
        get => Bitfields.endpos(Offset, Width);
    }

    public string Format()
        => string.Format("{0,-8} {1}", EndPos, Offset, sys.bytes(Value).FormatBits());

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator T(BitfieldSeg<T> src)
        => src.Value;

    public static BitfieldSeg<T> Empty => default;
}
