//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using Commands;
    using System.Linq;

    using static sys;

    public class ArchiveCommands : Stateless<ArchiveCommands>
    {
        public static ExecToken symlink(IWfChannel channel, CmdArgs args)
        {
            var a0 = args[0].Value;
            var a1 = args[1].Value;
            var result = Outcome.Failure;
            var isfile = (new FileInfo(a0)).Exists;
            var cmd = CreateSymLink.Empty;        
            if(isfile)
                cmd = new (FS.path(a0), FS.path(a1), true);
            else
                cmd = new (FS.dir(a0), FS.dir(a1), true);

            var running = channel.Running();
            if(cmd.Kind == Windows.SymLinkKind.File)
                result = FS.symlink((FilePath)cmd.Source, (FilePath)cmd.Target, cmd.Overwrite);
            else
                result = FS.symlink((FolderPath)cmd.Source, (FolderPath)cmd.Target, cmd.Overwrite);
            return channel.Ran(running);
        }

        public static Task<ExecToken> copy(IWfChannel channel, CmdArgs args)
            => copy(channel, FS.archive(args[0]), FS.archive(args[1]));
        
        public static Task<ExecToken> copy(IWfChannel channel, IDbArchive src, IDbArchive dst, ExclusionFilter? exclusions = null)
        {
            var args = list<CmdArg>();
            args.Add(src.Root.Format(PathSeparator.FS, true));
            args.Add(dst.Root.Format(PathSeparator.FS, true));
            args.Add("/e");
            if(exclusions != null)
            {
                var patterns = exclusions.Value.Patterns;
                for(var i=0; i<patterns.Count; i++)
                    args.Add($"/xf {patterns[i]}");
            }

            return Tooling.start(channel, FS.path("robocopy.exe"), args.Array());                    
        }
        
        public static Task<ExecToken> zip(IWfChannel channel, CmdArgs args)
            => PkgArchives.zip(channel, FS.dir(args[0]), FS.path(args[1]));

        public static Task<ExecToken> index(IWfChannel channel, FileIndexKind kind, CmdArgs args)
        {
            ExecToken Run()
            {
                var src = FS.archive(args[0]);
                var token = ExecToken.Empty;
                switch(kind)
                {
                    case FileIndexKind.Files:
                        token = Archives.index(channel, FileQuery.create(src), EnvDb.Nested("indices", src));
                        break;
                    case FileIndexKind.Folders:
                        token = Archives.index(channel, FolderQuery.create(src), EnvDb.Nested("indices", src));
                        break;
                }
                return token;
            }

            return sys.start(Run);
        }
    }

    public class Workflows : WfSvc<Workflows>
    {
        public static IEnumerable<IDbArchive> DotNetSdks(IDbArchive root)
            => from f in root.Folders(true, ".dotnet") select f.DbArchive();
            
        public static Task<ExecToken> sdkmerge(IWfChannel channel, CmdArgs args)
        {
            ExecToken Run()
            {
                var src = FS.archive(args[0]);
                var dotnet = src.Path("dotnet", FileKind.Exe);
                var token = ExecToken.Empty;
                if(!dotnet.Exists)
                {
                    channel.Error($"Not found:{dotnet}");
                }
                else
                {
                    token = ArchiveCommands.copy(channel, src, AppSettings.Publications("dotnet/root"), ExclusionFilter.create("dotnet.exe")).Result;
                }
                return token;
            }
            return sys.start(Run);
        }
        
        public static Task<ExecToken> catalog(IWfChannel channel, CmdArgs args)
        {
            ExecToken Run()
            {
                var token = ExecToken.Empty;
                if(bind(args, out CatalogFiles cmd))
                    token = Archives.index(channel, FileQuery.create(cmd.Source, cmd.Match), cmd.Target.DbArchive());
                return token;
            }
            return sys.start(Run);
        }

        static Outcome bind(CmdArgs src, out CatalogFiles dst)
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
    }
}