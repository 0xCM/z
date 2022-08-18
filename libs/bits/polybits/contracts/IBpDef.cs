//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBpDef
    {
        /// <summary>
        /// The pattern name
        /// </summary>
        asci32 Name {get;}

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

        NativeSize MinSize()
            => Calcs.MinSize();

        Type DataType()
            => Calcs.DataType();

        Index<BfSegModel> Segments()
            => Calcs.Segments();

        BfModel Model()
            => Calcs.Model();

        Index<byte> SegWidths()
            => Calcs.SegWidths();

        Index<string> Indicators()
            => Calcs.Indicators();

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
        new BfOrigin<P> Origin {get;}

        BfOrigin IBpDef.Origin
            => Origin;

        new BpCalcs<P> Calcs
            => new BpCalcs<P>(new BpDef<P>(Name, Pattern, Origin.Value));

        BpCalcs IBpDef.Calcs
            => Calcs;
    }

    public interface IBpDef<D,P> : IBpDef<P>
        where P : unmanaged, IBpDef<P>

    {

    }
}