//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class FileCatalog
    {
        public static Hex32 docid(FS.FilePath src)
            => (Hex32)hash(src.ToUri().Format());

        public static FileCatalog load(SortedReadOnlySpan<FS.FilePath> src)
        {
            var dst = new FileCatalog();
            for(var i=0u; i<src.Count; i++)
            {
                ref readonly var path = ref src[i];
                var file = new FileRef(i, docid(path), FileTypes.kind(path), path);
                dst.IdMap.Include(dst.PathMap.Include(file, _ => file.DocId), file);
                dst.PathRefs.Include(path, file);
            }

            return dst;
        }

        readonly PllMap<uint,FileRef> IdMap;

        readonly PllMap<FileRef,uint> PathMap;

        readonly PllMap<FS.FilePath,FileRef> PathRefs;

        FileCatalog()
        {
            IdMap = new();
            PathMap = new();
            PathRefs = new();
        }

        public Index<FileRef> Docs(string match)
            => PathRefs.Values.Array().Where(x => x.Path.Contains(match));

        public Index<FileRef> Docs(FileKind kind)
            => Docs().Where(e => e.Kind == kind);

        public Index<FileRef> Docs(FileKind k0, FileKind k1)
            => Docs().Where(e => e.Kind == k0 || e.Kind == k1);

        public Index<FileRef> Docs(FileKind k0, FileKind k1, FileKind k2)
            => Docs().Where(e => e.Kind == k0 || e.Kind == k1 || e.Kind == k2);

        public Index<FileRef> Docs()
            => map(IdMap.Keys, k => Doc(k)).Sort().Resequence();

        public FileRef Doc(FS.FilePath path)
        {
            PathRefs.Find(path, out var fref);
            return fref;
        }

        public FileRef Doc(Hex32 id)
        {
            IdMap.Find(id, out var fref);
            return fref;
        }

        public FileRef this[FS.FilePath path]
        {
            [MethodImpl(Inline)]
            get => Doc(path);
        }

        public FileRef this[Hex32 id]
        {
            [MethodImpl(Inline)]
            get => Doc(id);
        }
    }
}