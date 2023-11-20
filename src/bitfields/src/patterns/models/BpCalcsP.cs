//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using api = BitPatterns;

public readonly struct BpCalcs<P>
    where P : unmanaged, IBitPattern<P>
{
    public readonly BpDef<P> Def;

    [MethodImpl(Inline)]
    public BpCalcs(in BpDef<P> def)
    {
        Def = def;
    }

    public BpCalcs Untyped
    {
        [MethodImpl(Inline)]
        get => new (Def.Untyped);
    }

    /// <summary>
    /// The width of the data represented by the pattern
    /// </summary>
    [MethodImpl(Inline)]
    public uint BitWidth()
        => Untyped.BitWidth();

    [MethodImpl(Inline)]
    public DataSize Size()
        => Untyped.Size();

    /// <summary>
    /// The minimum amount of storage required to store the represented data
    /// </summary>
    [MethodImpl(Inline)]
    public NativeSize MinSize()
        => Untyped.MinSize();

    /// <summary>
    /// A data type with size of <see cref='MinSize'/> or greater
    /// </summary>
    [MethodImpl(Inline)]
    public Type DataType()
        => Untyped.DataType();

    /// <summary>
    /// The segments in the field
    /// </summary>
    [MethodImpl(Inline)]
    public Seq<BfSegDef> Segments()
        => Untyped.Segments();

    [MethodImpl(Inline)]
    public BfDef Model()
        => Untyped.Model();

    [MethodImpl(Inline)]
    public Seq<byte> SegWidths()
        => Untyped.SegWidths();

    [MethodImpl(Inline)]
    public ReadOnlySeq<string> Symbols()
        => Untyped.Symbols();

    /// <summary>
    /// A semantic identifier
    /// </summary>
    [MethodImpl(Inline)]
    public string Descriptor()
        => Untyped.Descriptor();

    [MethodImpl(Inline)]
    public string BitString<T>(T value)
        where T : unmanaged
            => api.bitstring(Def.Pattern, value);

    [MethodImpl(Inline)]
    public static implicit operator BpCalcs(BpCalcs<P> src)
        => src.Untyped;

    [MethodImpl(Inline)]
    public static implicit operator BpCalcs<P>(P src)
        => new (new BpDef<P>(src.Name, src.Pattern));
}
