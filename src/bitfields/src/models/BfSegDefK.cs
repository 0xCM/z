//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using api = Bitfields;

[StructLayout(LayoutKind.Sequential, Pack=1)]
public readonly struct BfSegDef<K>
    where K : unmanaged
{
    /// <summary>
    /// The segment field
    /// </summary>
    public readonly K Field;

    /// <summary>
    /// The segment name
    /// </summary>
    public readonly string SegName;

    /// <summary>
    /// The index of the first bit in the segment
    /// </summary>
    public readonly uint MinPos;

    /// <summary>
    /// The index of the last bit in the segment
    /// </summary>
    public readonly uint MaxPos;

    /// <summary>
    /// The segment width
    /// </summary>
    public readonly byte Width;

    /// <summary>
    /// The segment mask
    /// </summary>
    public readonly BitMask Mask;

    [MethodImpl(Inline)]
    public BfSegDef(K field, uint min, uint max, BitMask mask)
    {
        Field = field;
        SegName = field.ToString();
        MinPos = min;
        MaxPos = max;
        Width = (byte)bits.segwidth(MinPos,MaxPos);
        Mask = mask;
    }

    public BfInterval Interval
    {
        [MethodImpl(Inline)]
        get => new BfInterval(MinPos,Width);
    }

    public string Format()
        => api.format(this);

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator BfSegDef(BfSegDef<K> src)
        => new (src.SegName, src.MinPos, src.MaxPos, src.Mask);
}
