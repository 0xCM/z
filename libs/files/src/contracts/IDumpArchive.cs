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

        FS.FolderPath DotNetTargets(byte major, byte minor, byte revision)
            => DotNetTargets().Targets(FS.FolderName.version(major, minor, revision).Format()).Root;

        FS.FilePath Table<T>(ProcDumpName id)
            where T : struct
                => Root + Tables.filename<T>(id.Format());

        FS.FilePath Table<T>(string name, Timestamp ts)
            where T : struct
                => Root + Tables.filename<T>(ProcDumpName.create(name,ts).Format());
    }
}