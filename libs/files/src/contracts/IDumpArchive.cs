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

        FilePath Table<T>(ProcDumpName id)
            where T : struct
                => Root + Tables.filename<T>(id.Format());

        FilePath Table<T>(string name, Timestamp ts)
            where T : struct
                => Root + Tables.filename<T>(ProcDumpName.create(name,ts).Format());
    }
}