//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    public readonly struct SymbolArchives : ISymbolArchives
    {
        public static SymbolArchives create(IDbArchive src)
            => new SymbolArchives(src.Root);

        public FS.FolderPath Root {get;}

        public SymbolArchives(FS.FolderPath root)
        {
            Root = root;
        }

        public FS.FolderPath SymbolCacheRoot()
            => Root;

        public FS.FolderPath DefaultSymbolCache()
            => SymbolCacheRoot() + FS.folder(@default);

        public IDbSources DotNetSymSources()
            => new DbSources(SymbolCacheRoot(), dotnet);

        public IDbSources DotNetSymbolSource(string name)
            => DotNetSymSources().Sources(name);

        public IDbSources DotNetSymbolSource(byte major, byte minor, byte revision)
            => DotNetSymbolSource(FS.FolderName.version(major, minor, revision).Format());
    }
}