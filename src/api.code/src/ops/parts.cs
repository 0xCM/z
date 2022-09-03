//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class ApiCode
    {
        [Op]
        public static ReadOnlySpan<ApiPartBlocks> parts(ReadOnlySpan<ApiHostBlocks> src)
            => src.ToArray().GroupBy(x => x.Part).Map(x => new ApiPartBlocks(x.Key, x.ToArray()));
    }
}