//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ApiCmdCatalog : ConstLookup<@string,ApiCmdInfo>
    {                
        public ApiCmdCatalog(ReadOnlySeq<ApiCmdInfo> src)
            : base(src.Select(x => (x.Name,x)).ToDictionary())
        {
            Commands = src.Sort();
        }

        public readonly ReadOnlySeq<ApiCmdInfo> Commands;
    }
}