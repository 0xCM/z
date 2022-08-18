//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;

    public interface ISymbolArchives : IRootedArchive
    {
        IDbArchive DotNet()
            => Scoped(dotnet);

        IDbArchive DotNet(string name)
            => DotNet().Scoped(name);

        IDbArchive DotNet(byte major, byte minor, byte revision)
            => DotNet(FS.FolderName.version(major, minor, revision).Format());
    }
}