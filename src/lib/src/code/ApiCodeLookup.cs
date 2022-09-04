//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiCodeLookup : ConcurrentDictionary<_OpUri,ApiCodeBlock>
    {
        public static ApiCodeLookup Empty => new ApiCodeLookup();
    }
}