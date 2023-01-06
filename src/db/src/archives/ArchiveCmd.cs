//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    class ArchiveCmd : ApiService<ArchiveCmd>
    {
        FileArchives FileArchives => Wf.FileArchives();

        [CmdOp("symlink")]
        void Link(CmdArgs args)
            => Archives.symlink(Channel, args);

        [CmdOp("zip")]
        void Zip(CmdArgs args)
            => Archives.zip(Channel, args);

        [CmdOp("copy")]
        void Copy(CmdArgs args)
            => Archives.copy(Channel, args);

        [CmdOp("files")]
        void CatalogFiles(CmdArgs args)
            => Archives.catalog(Channel, args);

        [CmdOp("nuget/pkg")]
        void NugetFiles(CmdArgs args)
            => Archives.nupkg(Channel, args);

        [CmdOp("archives/injest")]
        void InjestFiles(CmdArgs args)
            => FileArchives.Injest(Archives.archive(FS.dir(args[0])), AppDb.Catalogs().Scoped("files"));

        [CmdOp("nuget/stage")]
        void DevPack(CmdArgs args)
            => DevPacks.stage(Channel, PackageKind.Nuget, FS.dir(arg(args,0)));
    }
}