//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using api = BitPatterns;

[StructLayout(StructLayout,Pack=1), Record(TableId)]
public readonly record struct BpDef<P> : IBitPattern<P>
    where P : unmanaged, IBitPattern<P>
{
    const string TableId = "bits.patterns.defs";

    /// <summary>
    /// The pattern name
    /// </summary>
    [Render(32)]
    public readonly string Name;

    /// <summary>
    /// The pattern content
    /// </summary>
    [Render(1)]
    public readonly BpExpr Pattern;

    [MethodImpl(Inline)]
    public BpDef(string name, in BpExpr pattern)
    {
        Name = name;
        Pattern = pattern;
    }

    public BpDef Untyped
    {
        [MethodImpl(Inline)]
        get => new (Name, Pattern);
    }

    BpCalcs<P> Calcs
    {
        [MethodImpl(Inline)]
        get => default(P);
    }

    /// <summary>
    /// The width of the data represented by the pattern
    /// </summary>
    [MethodImpl(Inline)]
    public uint BitWidth()
        => api.bitwidth(Pattern);

    /// <summary>
    /// The total pattern size
    /// </summary>
    [MethodImpl(Inline)]
    public DataSize Size()
        => api.size(Pattern);

    /// <summary>
    /// The minimum amount of storage required to store the represented data
    /// </summary>
    [MethodImpl(Inline)]
    public NativeSize PackedSize()
        => api.nativesize(Pattern);

    /// <summary>
    /// The segments in the field
    /// </summary>
    [MethodImpl(Inline)]
    public Seq<BfSegDef> Segments()
        => api.segdefs(Pattern);

    [MethodImpl(Inline)]
    public Seq<byte> SegWidths()
        => api.segwidths(Pattern);

    [MethodImpl(Inline)]
    public ReadOnlySeq<string> Symbols()
        => api.symbols(Pattern);

    [MethodImpl(Inline)]
    public BpInfo Description()
        => api.describe(Pattern);

    [MethodImpl(Inline)]
    public BfDef Model()
        => api.bitfield(Name, Pattern);

    [MethodImpl(Inline)]
    public string BitString<T>(T value)
        where T : unmanaged
            => api.bitstring(Pattern, value);

    public string Format()
        => api.format(this);

    public void Symbolic(ITextEmitter dst)
        => api.symbolic(this,dst);
        
    public string Symbolic()
        => api.symbolic(this);
        
    public override string ToString()
        => Format();

    string IBitPattern.Name
        => Name;

    BpExpr IBitPattern.Pattern
        => Pattern;

    [MethodImpl(Inline)]
    public static implicit operator BpDef(BpDef<P> src)
        => src.Untyped;
}
