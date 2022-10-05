//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly record struct DbArchive : IDbArchive
    {
        public readonly FolderPath Root;

        [MethodImpl(Inline)]
        public DbArchive(FolderPath root)
        {
            Root = root;
        }

        [MethodImpl(Inline)]
        public DbArchive(FolderPath root, string scope)
        {
            Root = root + FS.folder(scope);
        }

        public bool Exists
        {
            [MethodImpl(Inline)]
            get => Root.Exists;
        }

        FolderPath IRootedArchive.Root 
            => Root;

        public DbArchive Delete()
        {
            Root.Delete();
            return this;
        }

        public DbArchive Clear()
        {
            Root.Clear();
            return this;
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

        public string Format()
            => Root.Format();

        public override string ToString()
            => Format();

        public DbArchive Scoped(string scope)
            => Datasets.archive(new DbArchive(Root + FS.folder(scope)));

        public DbArchive Logs()
            => Targets("logs");

        public FilePath Log(string name, FileKind kind)
            => Logs().Path(name,kind);

        public int CompareTo(DbArchive src)
            => Root.CompareTo(src.Root);

        public DbArchive Targets()
            => Root;

        public DbArchive Targets(string scope)
            => Datasets.archive((new DbTargets(Root, scope)).Root);

        public DbArchive Sources()
            => Root;

        public DbArchive Sources(string scope)
            => Root + FS.folder(scope);

        public FolderPaths Folders(bool recurse = false)
            => Root.Folders(recurse);

        public FolderPath Folder(string match)
            => Root.Folder(match);

        public Files Files()
            => Root.Files(true);

        public Files Files(bool recursive)
            => Root.Files(recursive);

        public Files Files(string scope, bool recursive)
            => Root.Files(recursive);

        public Files Files(string scope, bool recurse, FileKind kind)
            => Root.Files(scope, recurse, kind);

        public Files Files(bool recurse, params FileKind[] kinds)
            => Root.Files(recurse, kinds);

        public Files Files(string scope, bool recurse, params FileKind[] kinds)
            => Root.Files(scope, recurse, kinds);

        public Files Files(FileKind kind, bool recurse = true)
            => Root.Files(kind.Ext(), recurse);

        public Files Files(FileExt ext, bool recurse = true)
            => Root.Files(ext, recurse);

        public Deferred<FilePath> Enumerate(bool recursive = true)
            => Root.EnumerateFiles(recursive);

        public FileName File(string name, FileKind kind)
            => FS.file(name, kind.Ext());

        public FileName File(string @class, string name, FileKind kind)
            => FS.file(string.Format("{0}.{1}", @class, name), kind.Ext());

        public FilePath Path(string name, FileKind kind)
            => Root + FS.file(name, kind.Ext());

        public FilePath Path(string @class, string name, FileKind kind)
            => new DbSources(Root, @class).Root + File(@class, name,kind);

        public FilePath Path(FileName file)
            => Root + file;

        public FilePath Table<T>()
            where T : struct
                => Root + Tables.filename<T>();

        public FilePath Table<T>(ProjectId id)
            where T : struct
                => Root + Tables.filename<T>(id.Format());

        public FilePath PrefixedTable<T>(string prefix)
            where T : struct
                => Root + Tables.filename<T>(prefix);

        public static FileName file(string @class, string name, FileKind kind)
            => FS.file(string.Format("{0}.{1}", @class, name), kind.Ext());

        [Op]
        public static Outcome<FileEmission> emissions(Files src, bool uri, FilePath dst)
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

        [MethodImpl(Inline)]
        public static implicit operator DbArchive(FolderPath src)
            => new DbArchive(src);

        [MethodImpl(Inline)]
        public static implicit operator FolderPath(DbArchive src)
            => src.Root;
    }
}