//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;

    public readonly struct SymbolArchives : IRootedArchive
    {
        public static SymbolArchives create(FolderPath src)
            => new SymbolArchives(src);

        public FolderPath Root {get;}

        public SymbolArchives(FolderPath root)
        {
            Root = root;
        }


        public DbArchive DotNet()
            => Root + FS.folder(dotnet);

        public DbArchive DotNet(string name)
            => DotNet().Scoped(name);

        public DbArchive DotNet(byte major, byte minor, byte revision)
            => DotNet(FolderName.version(major, minor, revision).Format());

        public FolderPath SymbolCacheRoot()
            => Root;

        public FolderPath DefaultSymbolCache()
            => SymbolCacheRoot() + FS.folder(@default);

        public IDbArchive DotNetSymSources()
            => new DbArchive(SymbolCacheRoot(), dotnet);

        public DbArchive DotNetSymbolSource(string name)
            => DotNetSymSources().Sources(name);

        public DbArchive DotNetSymbolSource(byte major, byte minor, byte revision)
            => DotNetSymbolSource(FolderName.version(major, minor, revision).Format());
    }
}