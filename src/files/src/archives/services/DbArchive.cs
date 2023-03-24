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
            => new DbArchive(Root + FS.folder(scope));

        public DbArchive Scoped(ReadOnlySeq<string> src)
            => Scoped(text.join(Chars.FSlash, src));

        public DbArchive Nested(FolderPath src)
            => Scoped(FS.components(src));

        public DbArchive Nested(string scope, FolderPath src)
            => Scoped(scope).Scoped(FS.components(src));

        public DbArchive Logs()
            => Targets("logs");

        public FilePath Log(string name, FileKind kind)
            => Logs().Path(name,kind);

        public int CompareTo(DbArchive src)
            => Root.CompareTo(src.Root);

        public DbArchive Targets()
            => Root;

        public IEnumerable<RelativeFilePath> Relative(IEnumerable<FilePath> src)
            => FS.relative(Root,src);

        public DbArchive Targets(string scope)
            => (new DbArchive(Root, scope)).Root;

        public DbArchive Sources()
            => Root;

        public DbArchive Sources(string scope)
            => Root + FS.folder(scope);

        public IEnumerable<FolderPath> Folders(bool recurse = false)
            => Root.Folders(recurse);

        public FolderPath Folder(string match)
            => Root.Folder(match);

        public IEnumerable<FilePath> Files()
            => Root.Files(true);

        public IEnumerable<FilePath> Files(bool recursive)
            => Root.Files(recursive);

        public IEnumerable<FilePath> Files(string scope, bool recursive)
            => Root.Files(recursive);

        public IEnumerable<FilePath> Files(string scope, bool recurse, FileKind kind)
            => Root.Files(scope, recurse, kind);

        public IEnumerable<FilePath> Files(bool recurse, params FileKind[] kinds)
            => Root.Files(recurse, kinds);

        public IEnumerable<FilePath> Files(string scope, bool recurse, params FileKind[] kinds)
            => Root.Files(scope, recurse, kinds);

        public IEnumerable<FilePath> Files(FileKind kind, bool recurse = true)
            => Root.Files(kind.Ext(), recurse);

        public IEnumerable<FilePath> Files(FileExt ext, bool recurse = true)
            => Root.Files(ext, recurse);

        public IEnumerable<FilePath> Enumerate(bool recursive, string pattern)
            => FS.enumerate(Root, pattern, recursive);

        public IEnumerable<FilePath> Enumerate(bool recurse, params FileKind[] kinds)
            => FS.enumerate(Root, recurse, kinds);

        public IEnumerable<FilePath> Enumerate(bool recurse, params FileExt[] ext)
            => FS.enumerate(Root, recurse, ext);

        public IEnumerable<FilePath> Files(bool recurse, params FileExt[] ext)
            => FS.enumerate(Root, recurse, ext);

        public FileName File(string name, FileKind kind)
            => FS.file(name, kind.Ext());

        public FileName File(string @class, string name, FileKind kind)
            => FS.file(string.Format("{0}.{1}", @class, name), kind.Ext());

        public FilePath Path(string name, FileKind kind)
            => Root + FS.file(name, kind.Ext());

        public FilePath Path(string name, FileExt ext)
            => Root + FS.file(name, ext);

        public FilePath Path(string @class, string name, FileKind kind)
            => new DbArchive(Root, @class).Root + File(@class, name,kind);

        public FilePath Path(FileName file)
            => Root + file;

        public static FileName filename(TableId id)
            => FS.file(id.Format(), FS.Csv);

        public static FileName filename(TableId id, FileExt ext)
            => FS.file(id.Format(), ext);

        public static FileName filename<T>()
                => filename<T>(FS.Csv);

        public static FileName filename<T>(FileExt ext)
            => filename(TableId.identify<T>());

        public static FileName filename<T>(string prefix)
            => FS.file(string.Format("{0}.{1}", prefix, TableId.identify<T>()), FS.Csv);
        public FilePath Table<T>()
                => Root + filename<T>();

        public FilePath Table<T>(ProjectId id)
                => Root + filename<T>(id.Format());

        public FilePath PrefixedTable<T>(string prefix)
            => Root + filename<T>(prefix);

        public static FileName file(string @class, string name, FileKind kind)
            => FS.file(string.Format("{0}.{1}", @class, name), kind.Ext());

        [MethodImpl(Inline)]
        public static implicit operator DbArchive(FolderPath src)
            => new DbArchive(src);

        [MethodImpl(Inline)]
        public static implicit operator FolderPath(DbArchive src)
            => src.Root;

        public static DbArchive Empty => new (FolderPath.Empty);
    }
}