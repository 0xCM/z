//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(LayoutKind.Sequential,Pack=1)]
public readonly record struct BfInterval : IComparable<BfInterval>
{
    /// <summary>
    /// The index of the first bit in the segment
    /// </summary>
    [Render(8)]
    public readonly uint MinPos;

    /// <summary>
    /// The segment width
    /// </summary>
    [Render(8)]
    public readonly byte Width;

    [MethodImpl(Inline)]
    public BfInterval(uint offset, byte width)
    {
        MinPos = offset;
        Width = width;
    }

    public BfSegExpr Expr
    {
        [MethodImpl(Inline)]
        get => Bitfields.expr(this);
    }

    /// <summary>
    /// The index of the last bit in the segment
    /// </summary>
    public readonly byte MaxPos
    {
        [MethodImpl(Inline)]
        get => (byte)Bitfields.endpos(MinPos,Width);
    }

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => (uint)MinPos  | (uint)Width << 16;
    }

    [MethodImpl(Inline)]
    public int CompareTo(BfInterval src)
        => MinPos.CompareTo(src.MinPos);

    public override int GetHashCode()
        => Hash;

    public string Format()
        => BitPatterns.format(Expr);

    public override string ToString()
        => Format();
}
