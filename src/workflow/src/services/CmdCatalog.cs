//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class CmdCatalog : ConstLookup<Name,CmdCatalogEntry>
    {                
        readonly ReadOnlySeq<CmdCatalogEntry> Data;

        public CmdCatalog(ReadOnlySeq<CmdCatalogEntry> src)
            : base(src.Select(x => (x.Name,x)).ToDictionary())
        {
            Data = src;
        }
    }
}