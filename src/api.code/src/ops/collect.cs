//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCode
    {
        // [Op]
        // public static ReadOnlySeq<ApiEncoded> collect(IWfChannel channel, Assembly src, ICompositeDispenser symbols)
        //     => gather(channel, entries(ClrJit.jit(ApiCatalog.catalog(src), channel)), symbols);

        // [Op]
        // public static ReadOnlySeq<ApiEncoded> collect(IWfChannel channel, IPart src, ICompositeDispenser symbols)
        //     => collect(channel, src.Owner, symbols);
    }
}