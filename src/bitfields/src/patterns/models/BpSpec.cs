//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(StructLayout,Pack=1), Record(TableId)]
public record struct BpSpec
{
    public const string TableId = "specs";

    /// <summary>
    /// The name of the pattern source
    /// </summary>
    [Render(16)]
    public string Origin;

    /// <summary>
    /// The pattern name
    /// </summary>
    [Render(16)]
    public string Name;

    /// <summary>
    /// The width of the data represented by the pattern
    /// </summary>
    [Render(12)]
    public uint DataWidth;

    /// <summary>
    /// The minimum amount of storage required to store the represented data
    /// </summary>
    [Render(12)]
    public NativeSize MinSize;

    /// <summary>
    /// A data type with size of <see cref='MinSize'/> or greater
    /// </summary>
    [Render(12)]
    public asci8 DataType;

    /// <summary>
    /// The pattern content
    /// </summary>
    [Render(32)]
    public BpExpr Content;

    /// <summary>
    /// The pattern content
    /// </summary>
    [Render(1)]
    public string Descriptor;

    public static BpSpec Empty => default;
}
