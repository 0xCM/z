//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ApiCmdCatalog : ConstLookup<@string,ApiCmdInfo>
    {                
        readonly ReadOnlySeq<ApiCmdInfo> Data;

        public ApiCmdCatalog(ReadOnlySeq<ApiCmdInfo> src)
            : base(src.Select(x => (x.Name,x)).ToDictionary())
        {
            Data = src;
        }
    }
}