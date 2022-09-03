//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCode
    {
        [Op]
        public static ReadOnlySeq<ApiEncoded> collect(ICompositeDispenser symbols, IPart src, WfEmit log)
            => gather(entries(ClrJit.jit(src, log)), symbols, log);
    }
}