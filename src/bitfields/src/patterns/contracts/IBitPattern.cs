//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using api = BitPatterns;

public interface IBitPattern
{
    /// <summary>
    /// The pattern name
    /// </summary>
    string Name {get;}

    /// <summary>
    /// The pattern content
    /// </summary>
    BpExpr Pattern {get;}


    DataSize Size
        => api.size(Pattern);

    NativeSize PackedSize()
        => api.packedsize(Pattern);

    Seq<BfSegDef> Segments()
        => api.segdefs(Pattern);

    BfDef Model()
        => api.bitfield(Name, Pattern);

    Seq<byte> SegWidths()
        => api.segwidths(Pattern);

    string Symbolic()
        => api.symbolic(this);

    void Symbolic(ITextEmitter dst)
        => api.symbolic(this, dst);

    ReadOnlySeq<string> Symbols()
        => api.symbols(Pattern);

    BpInfo Description()
        => api.describe(Name, Pattern);

    string Descriptor()
        => api.descriptor(Pattern);

    string BitString(ulong value)
        => api.bitstring(Pattern, value);

    string BitString<T>(T value)
        where T : unmanaged
            => api.bitstring(Pattern, value);
}

public interface IBitPattern<P> : IBitPattern
    where P : unmanaged, IBitPattern<P>
{
    BpExpr IBitPattern.Pattern
        => typeof(P).GetCustomAttribute<BitPatternAttribute>()?.Symbols ?? EmptyString;
        
    string IBitPattern.Name
        => typeof(P).Name;

}
