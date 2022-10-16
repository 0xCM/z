//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class CmdCatalog
    {

                
        public static CmdCatalog load(IAppCmdDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var count = defs.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = defs[i].Uri;
            return new CmdCatalog(entries(dst));
        }

        static ReadOnlySeq<CmdCatalogEntry> entries(CmdUriSeq src)    
        {
            var entries = alloc<CmdCatalogEntry>(src.Count);
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var uri = ref src[i];
                ref var entry = ref seek(entries,i);
                entry.Uri = uri;
                entry.Hash = uri.Hash;
                entry.Name = uri.Name;
            }
            return entries.Sort().Resequence();        
        }        
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