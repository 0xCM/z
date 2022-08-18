//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public readonly record struct DbArchive : IDbArchive
    {
        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        public DbArchive(FS.FolderPath root)
        {
            Root = root;
        }

        [MethodImpl(Inline)]
        public DbArchive(IRootedArchive root)
        {
            Root = root.Root;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Root.Format());
        }

        public override int GetHashCode()
            => Hash;

        public bool Equals(DbArchive src)
            => Root == src.Root;

        public IDbArchive Scoped(string scope)
            => Datasets.archive(Root + FS.folder(scope));

        public string Format()
            => Root.Format();

        public override string ToString()
            => Format();

        public IDbTargets Logs()
            => Targets("logs");

        public FS.FilePath Log(string name, FileKind kind)
            => Logs().Path(name,kind);

        public int CompareTo(DbArchive src)
            => Root.CompareTo(src.Root);

        public IDbTargets Targets()
            => new DbTargets(Root);

        public IDbTargets Targets(string scope)
            => new DbTargets(Root, scope);

        public IDbSources Sources()
            => new DbSources(Root);

        public IDbSources Sources(string scope)
            => new DbSources(Root, scope);

        public FS.Files Files(bool recursive)
            => Root.Files(recursive);

        public FS.Files Files(string scope, bool recursive)
            => Root.Files(recursive);

        public FS.Files Files(string scope, bool recurse, FileKind kind)
            => Root.Files(scope, recurse, kind);

        public FS.Files Files(bool recurse, params FileKind[] kinds)
            => Root.Files(recurse, kinds);

        public FS.Files Files(string scope, bool recurse, params FileKind[] kinds)
            => Root.Files(scope, recurse, kinds);

        public FS.Files Files(FileKind kind, bool recurse = true)
            => Root.Files(kind.Ext(), recurse);

        public FS.Files Files(FS.FileExt ext, bool recurse = true)
            => Root.Files(ext, recurse);

        public Deferred<FS.FilePath> Enumerate(bool recursive = true)
            => Root.EnumerateFiles(recursive);

        public FS.FileName File(string name, FileKind kind)
            => FS.file(name, kind.Ext());

        public FS.FileName File(string @class, string name, FileKind kind)
            => FS.file(string.Format("{0}.{1}", @class, name), kind.Ext());

        public FS.FilePath Path(string name, FileKind kind)
            => Root + FS.file(name, kind.Ext());

        public FS.FilePath Path(string @class, string name, FileKind kind)
            => new DbSources(Root, @class).Root + File(@class, name,kind);

        public FS.FilePath Path(FS.FileName file)
            => Root + file;

        public FS.FilePath Table<T>()
            where T : struct
                => Root + Tables.filename<T>();

        public FS.FilePath Table<T>(ProjectId id)
            where T : struct
                => Root + Tables.filename<T>(id.Format());

        public FS.FilePath PrefixedTable<T>(string prefix)
            where T : struct
                => Root + Tables.filename<T>(prefix);

        public static FS.FileName file(string @class, string name, FileKind kind)
            => FS.file(string.Format("{0}.{1}", @class, name), kind.Ext());

        [Op]
        public static Outcome<FileEmission> emissions(FS.Files src, bool uri, FS.FilePath dst)
        {
            var counter  = 0;
            try
            {
                using var writer = dst.Writer();
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var file = ref src[i];
                    writer.WriteLine(uri ? file.ToUri().Format() : file.Format());
                    counter++;
                }

                return new FileEmission(dst, (int)counter);
            }
            catch(Exception e)
            {
                return e;
            }
        }

        [MethodImpl(Inline), Op]
        public static IFilteredArchive filter(FS.FolderPath src, string filter)
            => new FilteredArchive(src, filter);

        [MethodImpl(Inline), Op]
        public static IFilteredArchive filter(FS.FolderPath src, params FS.FileExt[] ext)
            => new FilteredArchive(src, ext);

        public static FS.Files search(FS.FolderPath src, FS.FileExt[] ext, uint limit = 0)
            => limit != 0 ? match(src, limit, ext) : match(src, ext);

        public static FS.Files match(FS.FolderPath src, uint max, params FS.FileExt[] ext)
        {
            var files = filter(src, ext).Files().Take(max).Array();
            Array.Sort(files);
            return files;
        }

        public static FS.Files match(FS.FolderPath src, params FS.FileExt[] ext)
        {
            var files = filter(src, ext).Files().Array();
            Array.Sort(files);
            return files;
        }

        [MethodImpl(Inline)]
        public static implicit operator DbArchive(FS.FolderPath src)
            => new DbArchive(src);

        [MethodImpl(Inline)]
        public static implicit operator FS.FolderPath(DbArchive src)
            => src.Root;
    }
}