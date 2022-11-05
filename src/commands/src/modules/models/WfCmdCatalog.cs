//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class WfCmdCatalog : ConstLookup<Name,WfCmdInfo>
    {                
        readonly ReadOnlySeq<WfCmdInfo> Data;

        public WfCmdCatalog(ReadOnlySeq<WfCmdInfo> src)
            : base(src.Select(x => (x.Name,x)).ToDictionary())
        {
            Data = src;
        }

        public static Symbols<CmdKind> kinds()
            => Symbols.index<CmdKind>();
    }
}