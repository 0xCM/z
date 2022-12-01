//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    public interface IDumpArchive : IRootedArchive
    {
        IDbTargets DumpTargets(string scope)
            => new DbTargets(Root, scope);

        IDbTargets DotNetTargets()
            => DumpTargets(dotnet);

        FolderPath DotNetTargets(byte major, byte minor, byte revision)
            => DotNetTargets().Targets(FolderName.version(major, minor, revision).Format()).Root;
    }
}