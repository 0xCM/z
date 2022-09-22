//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;


    public sealed class DevCmd : AppCmdService<DevCmd>
    {
        DevPacks Devpacks => Wf.DevPacks();

        public static FolderPath cd()
        {
            return new(text.ifempty(Environment.CurrentDirectory, AppDb.Control().Root.Format()));
        }

        public static FolderPath cd(CmdArgs args)
        {
            if(args.Length == 1)
                Environment.CurrentDirectory = args.First.Value;
            return cd();
        }

        [CmdOp("files/nuget")]
        void NugetFiles(CmdArgs args)
        {
            var src = FS.dir(arg(args,0));
            var packs = FilePacks.search(src, PackageKind.Nuget);
            iter(packs, p => Write(p));
        }

        [CmdOp("devpack/nuget")]
        void DevPack(CmdArgs args)
        {
            var src = FS.dir(arg(args,0));
            Devpacks.NugetStage(src);
        }

        [CmdOp("sln/root")]
        void SlnRoot(CmdArgs args)
        {
            if(args.Count == 1)
                Environment.CurrentDirectory = args.First.Value;
            Channel.Row(cd());
        }

        [CmdOp("cd")]
        void Cd(CmdArgs args)
        {
            Channel.Row(cd(args));
        }

        [CmdOp("dir")]
        void Dir(CmdArgs args)
        {
            if(args.Count == 0)
            {
                var folders = cd().Folders();
                iter(folders, f => Channel.Row(f));

                var files = cd().Files(false);
                iter(files, f => Channel.Row(((FileUri)f)));
            }
            else
            {
                
            }
        }
    }
}