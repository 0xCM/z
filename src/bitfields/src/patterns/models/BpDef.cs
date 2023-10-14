//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using api = BitPatterns;

[StructLayout(StructLayout,Pack=1), Record(TableId)]
public readonly record struct BpDef : IBitPattern
{
    const string TableId = "bits.patterns.defs";

    /// <summary>
    /// The name of the pattern source
    /// </summary>
    [Render(32)]
    public readonly BfOrigin Origin;

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
    public BpDef(string name, BpExpr pattern, BfOrigin origin)
    {
        Name = name;
        Pattern = pattern;
        Origin = origin;
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
        => api.packedsize(Pattern);

    /// <summary>
    /// The segments in the field
    /// </summary>
    [MethodImpl(Inline)]
    public Seq<BfSegModel> Segments()
        => api.segs(Pattern);

    [MethodImpl(Inline)]
    public Seq<byte> SegWidths()
        => api.segwidths(Pattern);

    [MethodImpl(Inline)]
    public ReadOnlySeq<string> Symbols()
        => api.symbols(Pattern);

    [MethodImpl(Inline)]
    public BpInfo Description()
        => api.describe(Name, Pattern, Origin);

    [MethodImpl(Inline)]
    public BfModel Model()
        => api.model(Name, Pattern, Origin);

    [MethodImpl(Inline)]
    public string BitString(ulong value)
        => api.bitstring(Pattern, value);

    [MethodImpl(Inline)]
    public string BitString<T>(T value)
        where T : unmanaged
        => api.bitstring(Pattern, value);

    public void Symbolic(ITextEmitter dst)
        => api.symbolic(this,dst);
        
    public string Symbolic()
        => api.symbolic(this);

    public string Format()
        => api.format(this);

    public override string ToString()
        => Format();

    string IBitPattern.Name
        => Name;

    BpExpr IBitPattern.Pattern
        => Pattern;

    BfOrigin IBitPattern.Origin
        => Origin;
}
