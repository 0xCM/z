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

        public CmdCatalog(ReadOnlySeq<CmdUri> defs)
        {
            Index<CmdCatalogEntry> entries = sys.alloc<CmdCatalogEntry>(defs.Count);
            for(var i=0; i<defs.Count; i++)
            {
                ref readonly var uri = ref defs[i];
                ref var entry = ref entries[i];
                entry.Uri = uri;
                entry.Hash = uri.Hash;
                entry.Name = uri.Name;
            }
            Data = entries.Sort().Resequence();
        }
    }
}