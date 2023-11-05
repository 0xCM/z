//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(LayoutKind.Sequential,Pack=1)]
public readonly record struct BfInterval<F> : IComparable<BfInterval>
    where F : unmanaged
{
    /// <summary>
    /// The field for which the interval is defined
    /// </summary>
    [Render(16)]
    public readonly F Field;

    /// <summary>
    /// The index of the first bit in the segment
    /// </summary>
    [Render(8)]
    public readonly uint Offset;

    /// <summary>
    /// The segment width
    /// </summary>
    [Render(8)]
    public readonly byte Width;

    [MethodImpl(Inline)]
    public BfInterval(F field, uint offset, byte width)
    {
        Field = field;
        Offset = offset;
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
        get => (byte)Bitfields.endpos(Offset,Width);
    }

    [MethodImpl(Inline)]
    public BfInterval Untype()
        => new BfInterval(Offset,Width);

    [MethodImpl(Inline)]
    public int CompareTo(BfInterval src)
        => Offset.CompareTo(src.Offset);

    public string Format()
        => Expr.Format();

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator BfInterval(BfInterval<F> src)
        => src.Untype();
}
