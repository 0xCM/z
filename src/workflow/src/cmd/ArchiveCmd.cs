//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    sealed class ArchiveCmd : WfAppCmd<ArchiveCmd>
    {
        [CmdOp("symlink")]
        void Link(CmdArgs args)
            => ArchiveCommands.symlink(Channel, args);

        [CmdOp("files/zip")]
        void Zip(CmdArgs args)
            => ArchiveCommands.zip(Channel, args);

        [CmdOp("files/copy")]
        void Copy(CmdArgs args)
            => ArchiveCommands.copy(Channel, args).Wait();

        [CmdOp("nuget/index")]
        void NugetFiles(CmdArgs args)
            => PkgArchives.nupkg(Channel, FS.dir(args[0])).Wait();

        [CmdOp("nuget/download")]
        void NugetDownload(CmdArgs args)
        {
            var name = args[0].Value;
            var version = args[1].Value;
            var id = $"{name}.{version}";
            var dst = AppSettings.PkgRoot().Scoped("downloads").Path(id, FS.ext("nupkg"));
            var src = new Uri($"https://www.nuget.org/api/v2/package/{name}/{version}");
            var service = Channel.Channeled<Downloader>();
            service.DownloadFile(src, dst);            
        }

        [CmdOp("devpacks/stage")]
        void DevPack(CmdArgs args)
            => DevPacks.stage(Channel, PackageKind.Nuget, FS.dir(arg(args,0)));

        [CmdOp("files/index")]
        void FileQueryCmd(CmdArgs args)
            => ArchiveCommands.index(Channel, FileIndexKind.Files, args).Wait();

        [CmdOp("folders/index")]
        void Folders(CmdArgs args)
            => ArchiveCommands.index(Channel, FileIndexKind.Folders, args).Wait();
    }
}