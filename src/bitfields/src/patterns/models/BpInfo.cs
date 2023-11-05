//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public class BpInfo
{
    /// <summary>
    /// The pattern definition
    /// </summary>
    public readonly BpDef Def;

    /// <summary>
    /// The width of the data represented by the pattern
    /// </summary>
    public readonly uint DataWidth;

    /// <summary>
    /// The minimum amount of storage required to store the represented data
    /// </summary>
    public readonly NativeSize PackedSize;

    /// <summary>
    /// A data type with size of <see cref='PackedSize'/> or greater
    /// </summary>
    public readonly Type DataType;

    /// <summary>
    /// The segments in the field
    /// </summary>
    public readonly ReadOnlySeq<BfSegDef> Segs;

    /// <summary>
    /// A semantic identifier
    /// </summary>
    public readonly string Descriptor;

    /// <summary>
    /// An elaborated definition
    /// </summary>
    public readonly BpSpec Spec;

    internal BpInfo(in BpDef def, uint width, Type datatype, NativeSize minsize, ReadOnlySeq<BfSegDef> segs, string descriptor)
    {
        Def = def;
        DataWidth = width;
        DataType = datatype;
        PackedSize = minsize;
        Segs = segs;
        Descriptor = descriptor;
        Spec = BitPatterns.spec(this);
    }

    /// <summary>
    /// The number of bitfield segments
    /// </summary>
    public uint SegCount
    {
        [MethodImpl(Inline)]
        get => Segs.Count;
    }

    public ref readonly BfSegDef this[uint i]
    {
        [MethodImpl(Inline)]
        get => ref Segs[i];
    }

    public ref readonly BfSegDef this[int i]
    {
        [MethodImpl(Inline)]
        get => ref Segs[i];
    }

    /// <summary>
    /// The pattern specification
    /// </summary>
    public ref readonly BpExpr Expr
    {
        [MethodImpl(Inline)]
        get => ref Def.Expr;
    }

    /// <summary>
    /// The pattern name
    /// </summary>
    public ref readonly string Name
    {
        [MethodImpl(Inline)]
        get => ref Def.Name;
    }

    public string Format()
        => Descriptor;

    public override string ToString()
        => Format();
}
