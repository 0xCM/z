//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(StructLayout,Pack=1), Record(TableId)]
public record struct BpSeg : IComparable<BpSeg>
{
    const string TableId = "segs";

    /// <summary>
    /// The name of the pattern source
    /// </summary>
    [Render(16)]
    public string PatternName;

    /// <summary>
    /// The segment name
    /// </summary>
    [Render(16), Doc("The segment name")]
    public string SegmentName;

    /// <summary>
    /// The segment-relative index
    /// </summary>
    [Render(12), Doc("The segment-relative index")]
    public uint Index;

    /// <summary>
    /// The position of the first bit in the segment
    /// </summary>
    [Render(8), Doc("The position of the first bit in the segment")]
    public uint MinPos;

    /// <summary>
    /// The index of the last bit in the segment
    /// </summary>
    [Render(8), Doc("The index of the last bit in the segment")]
    public uint MaxPos;

    /// <summary>
    /// The segment width
    /// </summary>
    [Render(8), Doc("The segment width")]
    public byte Width;

    /// <summary>
    /// Specifies the segment def expression
    /// </summary>
    [Render(32), Doc("Specifies the segment def expression")]
    public string Expr;

    /// <summary>
    /// The segment mask
    /// </summary>
    [Render(1), Doc("The segment mask")]
    public BitMask Mask;

    public int CompareTo(BpSeg src)
    {
        var result = PatternName.CompareTo(src.PatternName);
        if(result == 0)
            result = src.Index.CompareTo(Index);
        return result;
    }

    public static BpSpec Empty => default;
}
