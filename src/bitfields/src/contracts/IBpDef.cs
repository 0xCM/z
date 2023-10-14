//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public interface IBpDef
{
    /// <summary>
    /// The pattern name
    /// </summary>
    string Name {get;}

    /// <summary>
    /// The pattern content
    /// </summary>
    BitPattern Pattern {get;}

    /// <summary>
    /// The name of the pattern source
    /// </summary>
    BfOrigin Origin {get;}

    BpCalcs Calcs {get;}

    DataSize Size
        => Calcs.Size();

    NativeSize PackedSize()
        => Calcs.MinSize();

    Type DataType()
        => Calcs.DataType();

    Seq<BfSegModel> Segments()
        => Calcs.Segments();

    BfModel Model()
        => Calcs.Model();

    Index<byte> SegWidths()
        => Calcs.SegWidths();

    ReadOnlySeq<string> Symbols()
        => Calcs.Symbols();

    BpInfo Description()
        => Calcs.Description();

    string Descriptor()
        => Calcs.Descriptor();

    string BitString(ulong value)
        => Calcs.BitString(value);

    string BitString<T>(T value)
        where T : unmanaged
            => Calcs.BitString(value);
}

public interface IBpDef<P> : IBpDef
    where P : unmanaged, IBpDef<P>
{
    BitPattern IBpDef.Pattern
        => typeof(P).GetCustomAttribute<BitPatternAttribute>()?.Symbols ?? EmptyString;
        
    string IBpDef.Name
        => typeof(P).Name;

    new BfOrigin<P> Origin
        => default(P);

    BfOrigin IBpDef.Origin
        => Origin;

    new BpCalcs<P> Calcs
        => new (new BpDef<P>(Name, Pattern, Origin.Value));

    BpCalcs IBpDef.Calcs
        => Calcs;
}
