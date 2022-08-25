//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    //using static EnvFolders;
    using static ApiAtomic;

    public readonly struct SymbolArchives : ISymbolArchives
    {
        public static SymbolArchives create(FS.FolderPath src)
            => new SymbolArchives(src);

        public FS.FolderPath Root {get;}

        public SymbolArchives(FS.FolderPath root)
        {
            Root = root;
        }


        public DbArchive DotNet()
            => Root + FS.folder(dotnet);

        public DbArchive DotNet(string name)
            => DotNet().Scoped(name);

        public DbArchive DotNet(byte major, byte minor, byte revision)
            => DotNet(FolderName.version(major, minor, revision).Format());

        public FS.FolderPath SymbolCacheRoot()
            => Root;

        public FS.FolderPath DefaultSymbolCache()
            => SymbolCacheRoot() + FS.folder(@default);

        public IDbSources DotNetSymSources()
            => new DbSources(SymbolCacheRoot(), dotnet);

        public IDbSources DotNetSymbolSource(string name)
            => DotNetSymSources().Sources(name);

        public IDbSources DotNetSymbolSource(byte major, byte minor, byte revision)
            => DotNetSymbolSource(FolderName.version(major, minor, revision).Format());
    }
}