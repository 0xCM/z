//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using Commands;

    public sealed class ArchiveFlows : WfAppCmd<ArchiveFlows>
    {
        public static ExecToken symlink(IWfChannel channel, CmdArgs args)
            => Archives.symlink(channel, args);

        public static Task<ExecToken> copy(IWfChannel channel, CmdArgs args)
            => copy(channel, FS.archive(args[0]), FS.archive(args[1]));
        
        public static Task<ExecToken> copy(IWfChannel channel, IDbArchive src, IDbArchive dst)
            => ToolExec.run(channel, FS.path("robocopy.exe"), Cmd.args(src.Root.Format(PathSeparator.FS, true), dst.Root.Format(PathSeparator.FS, true), "/e"));
        
        public static Task<ExecToken> zip(IWfChannel channel, CmdArgs args)
            => PkgArchives.zip(channel, FS.dir(args[0]), FS.path(args[1]));

        public static Task<ExecToken> catalog(IWfChannel channel, CmdArgs args)
        {
            ExecToken Run()
            {
                bind(args, out CatalogFiles cmd);
                return exec(channel, cmd);
            }
            return sys.start(Run);
        }

        public static Outcome bind(CmdArgs src, out CatalogFiles dst)
        {
            dst = new();
            dst.Target = AppSettings.EnvDb().Scoped("files");
            var count = src.Count;
            try
            {
                if(count >= 1)
                    dst.Source = FS.dir(src[0]);
                
                if(count >= 2)
                    switch(src[1].Value)
                    {
                        case "--ext":
                        dst.Match = sys.map(text.split(src[2].Value, Chars.Semicolon), x => FS.ext(x));
                        break;
                    }
            }
            catch(Exception e)
            {
                return e;
            }
        
            return true;
        }   

        public static Task<ExecToken> index(IWfChannel channel, FileIndexKind kind, CmdArgs args)
        {
            var root = FS.dir(args[0]);
            switch(kind)
            {
                case FileIndexKind.Files:
                    return sys.start(() => index(channel, FileQuery.create(root), EnvDb.Nested("indices", root)));
                case FileIndexKind.Folders:
                    return sys.start(() => index(channel, FolderQuery.create(root), EnvDb.Nested("indices", root)));
            }

            return sys.start(() => ExecToken.Empty);            
        }

        static ExecToken exec(IWfChannel channel, CatalogFiles cmd)
            => index(channel, FileQuery.create(cmd.Source, cmd.Match), cmd.Target.DbArchive());

        static FilePath IndexPath(IDbArchive src, FileIndexKind kind, IDbArchive dst)
            => dst.Path(FS.file(Archives.name(kind), FileKind.Csv));

        static ExecToken index(IWfChannel channel, FolderQuery q, IDbArchive dst)
        {
            var index = Archives.index(channel,q);
            var target = IndexPath(q.Root.DbArchive(), FileIndexKind.Folders, dst);
            return channel.TableEmit(index.Sorted(), target);
        }

        static ExecToken index(IWfChannel channel, FileQuery q, IDbArchive dst)
        {
            var index = Archives.index(channel,q);
            return channel.TableEmit(index.Sorted(), IndexPath(q.Root.DbArchive(), FileIndexKind.Files, dst));
        }

        [CmdOp("symlink")]
        void Link(CmdArgs args)
            => symlink(Channel, args);

        [CmdOp("files/zip")]
        void Zip(CmdArgs args)
            => zip(Channel, args);

        [CmdOp("files/copy")]
        void Copy(CmdArgs args)
            => copy(Channel, args);

        [CmdOp("files/catalog")]
        void CatalogFiles(CmdArgs args)
            => catalog(Channel, args);

        [CmdOp("nuget/index")]
        void NugetFiles(CmdArgs args)
            => PkgArchives.nupkg(Channel, FS.dir(args[0]));

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
            => index(Channel, FileIndexKind.Files, args);

        [CmdOp("folders/index")]
        void Folders(CmdArgs args)
            => index(Channel, FileIndexKind.Folders, args);
    }
}