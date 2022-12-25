//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCode
    {
        [Op]
        public static ReadOnlySeq<ApiEncoded> collect(ICompositeDispenser symbols, IPart src, IWfChannel log)
            => gather(entries(ClrJit.jit(ApiCatalog.catalog(src.Owner), log)), symbols, log);
    }
}