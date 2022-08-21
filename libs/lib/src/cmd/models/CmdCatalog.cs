//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdCatalog
    {
        readonly ReadOnlySeq<CmdCatalogEntry> Data;

        public ref readonly ReadOnlySeq<CmdCatalogEntry> Entries
        {
            [MethodImpl(Inline)]
            get => ref Data;
        }

        public CmdCatalog(ReadOnlySeq<CmdCatalogEntry> src)
        {
            Data = src;
        }
    }
}