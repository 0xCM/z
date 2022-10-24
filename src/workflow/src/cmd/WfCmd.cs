//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    using static sys;

    public class WfCmd : WfAppCmd<WfCmd>
    {
        WsRegistry WsRegistry => Wf.WsRegistry();

        ProjectScripts ProjectScripts => Wf.ProjectScripts();

        DevPacks Devpacks => Wf.DevPacks();

        Tooling Tooling => Wf.Tooling();

        Dev Dev => Dev.create(Wf);

        EnvSvc EnvSvc => Wf.EnvSvc();

        [CmdOp("zip")]
        void Zip(CmdArgs args)
        {
            var folder = arg(args,0).Value;
            var i = text.index(folder, Chars.FSlash,Chars.BSlash);
            var scope = "default";
            if(i > 0)
                scope = text.left(folder,i);
            var src = AppSettings.DbRoot().Scoped(folder).Root;
            var name = src.FolderName.Format();
            var file = FS.file($"{scope}.{name}", FileKind.Zip);
            Db.zip(Channel, src, AppDb.Archive(scope).Path(file));
        }

        [CmdOp("robocopy")]
        void Copy(CmdArgs args)
        {
            var src = FS.dir(arg(args,0).Value);
            var dst = FS.dir(arg(args,1).Value);
            Db.robocopy(Channel, src, dst);
        }

        [CmdOp("env/include")]
        void EnvInclude()
            => Channel.Row(Env.paths(EnvTokens.Include, EnvVarKind.Process).Delimit(Chars.NL));

        [CmdOp("env/path")]
        void EnvPath()
            => Channel.Row(Env.paths(EnvTokens.Path, EnvVarKind.Process).Delimit(Chars.NL));

        [CmdOp("env/lib")]
        void EnvLib()
            => Channel.Row(Env.paths(EnvTokens.Lib, EnvVarKind.Process).Delimit(Chars.NL));

        [CmdOp("archives")]        
        void ListArchives(CmdArgs args)
            => Emitter.Row(AppDb.Archives().Folders().Delimit(Eol));

        [CmdOp("archives/list")]        
        void ArchiveFiles(CmdArgs args)
        {
            var src = AppDb.Archive(arg(args,0).Value);
            iter(src.Files(true), file => Write(file.ToUri()));
        }

        [CmdOp("symlink")]
        void Symlink(CmdArgs args)
        {
            var src = FS.dir(args[0]);
            var dst = FS.dir(args[1]);
            var result = FS.symlink(src,dst,true);
            Channel.Status($"symlink:{src} -> {dst}");
        }

        static Files search(CmdArgs args)
        {
            var src = FS.dir(arg(args,0));
            if(args.Count > 1)
            {
                var kinds = args.Values().Span().Slice(1).Select(x => FS.kind(FS.ext(x))).Where(x => x!=0);
                iter(kinds, kind => term.babble(kind));
                var query = FS.query(src,true,kinds); 
                return query.Compute().Storage;
            }
            else
            {
                return src.Files(true);
            }            
        }

        [CmdOp("files")]
        void CatalogFiles(CmdArgs args)
        {
            var src = FS.dir(args[0].Value);            
            var files = ListedFiles.listing(search(args));
            var name = Archives.identifier(src);
            var table = FilePath.Empty;
            var list = FilePath.Empty;
            if(args.Count >=2)    
            {
                table = FS.dir(args[1]) + Tables.filename<ListedFile>(name);
                list = FS.dir(args[1]) + FS.file(name,FileKind.List);
            }
            else
            {
                table = AppDb.Catalogs("files").Table<ListedFile>(name);
                list = AppDb.Catalogs("files").Path(name, FileKind.List);
            }

            Emitter.TableEmit(files, table);            
            var flow = Emitter.EmittingFile(list);
            using var writer = list.Utf8Writer();
            var counter = 0u;
            foreach(var file in files)
            {
                writer.AppendLine(file.Path);
                counter++;
            }
            Emitter.EmittedFile(flow,counter);

        }

        [CmdOp("env/process/paths")]
        void ProcPaths()
        {
            var src = Env.process().ToLookup();
            var names = src.Keys;
            var dst = text.emitter();
            iter(names, name => {
                dst.AppendLine(src[name]);
            });

            Channel.Row(dst.Emit());
            //iter(src, var => Channel.Row(var));
        }

        void CalcRelativePaths()
        {
            var @base = FS.dir("dir1");
            var files = FS.dir("dir2").AllFiles;
            var links = Markdown.links(@base,files);
            iter(links, r=> Write(r.Format()));
        }

        [CmdOp("scripts")]
        void Scripts(CmdArgs args)
            => iter(ProjectScripts.List(args), path => Emitter.Write(path.ToUri()));

        [CmdOp("scripts/cmd")]
        void Script(CmdArgs args)
            => ProjectScripts.Start(args);

        [CmdOp("jobs/types")]
        void ListJobTypes()
        {
            var db = AppSettings.DbRoot();
            Write(db.Root);
            Write(RpOps.PageBreak80);
            var jobs = db.Sources("jobs");
            Write($"Jobs: {jobs.Root}");

            jobs.Root.Folders(true).Iter(f => Write(f.Format()));
        }

        [CmdOp("env/thread")]
        void ShowThread()
            => Write(string.Format("ThreadId:{0}", Kernel32.GetCurrentThreadId()));

        [CmdOp("app/deploy")]
        void Deploy()
        {
            var dst = AppDb.Tools("z0/cmd").Targets().Root;
            var src = ExecutingPart.Assembly.Path().FolderPath;
            Db.robocopy(Channel, src, dst);
        }

        static Files launchers()
            => FilteredArchive.match(AppSettings.Control("launch").Root, FileKind.Cmd, FileKind.Ps1);

        [CmdOp("shell")]
        void LaunchDevshell()
            => ProcessControl.start(Channel, CmdArgs.create($"{AppSettings.EnvRoot()}/shell.cmd"));

        [CmdOp("launchers")]
        void Launchers(CmdArgs args)
        {
            var src = launchers();
            var emitter = text.emitter();
            iter(src, file => emitter.AppendLine(file.ToUri()));
            var data = emitter.Emit();
            Emitter.Row(data);
            Emitter.FileEmit(data, AppDb.AppData().Path("launchers", FileKind.List));
        }
        
        [CmdOp("launch")]
        void LaunchTargets(CmdArgs args)
        {
            var src = launchers().Map(x => (x.FileName,x)).ToDictionary();
            foreach(var arg in args)
            {
                var file = FS.file(arg.Value, FileKind.Cmd);
                var path = FilePath.Empty;
                if(src.TryGetValue(file, out path))
                {
                    ProcessControl.start(ProcessControl.cmdline(path));
                    Status($"Script {path.ToUri()} executing", FlairKind.Ran);
                }
                else
                {
                    Warn($"Launcher for {file} not found");
                }
            }
        }

        [CmdOp("settings")]
        void ReadSettings(CmdArgs args)
        {
            iter(AppSettings, setting => Write(setting.Format()));
        }

        [CmdOp("services")]
        void GetServices()
        {
            Write(ApiRuntime.services(ApiCatalog.Components));
        }

        [CmdOp("env/id")]
        void EvId(CmdArgs args)
        {
            var id = Env.EnvId;
            var msg = EmptyString;
            if(args.IsNonEmpty)
            {
                Env.EnvId = args.First.Value;
                if(id.IsNonEmpty)
                    msg = $"{id} -> {Env.EnvId}";
                else
                    msg = $"{Env.EnvId}";
            }
            else
            {
                if(id.IsNonEmpty)
                    msg = id;
            }
            if(nonempty(msg))
                Channel.Write(msg);            
        }

        [CmdOp("env/reports")]
        void EmitEnv(CmdArgs args)
            => EnvSvc.EmitReports(AppDb.AppData("env"));

        [CmdOp("env/machine")]
        void EmitMachineEnv()
            => EnvSvc.EmitReport(EnvVarKind.Machine, AppDb.AppData("env"));

        [CmdOp("env/user")]
        void EmitUserEnv()
            => EnvSvc.EmitReport(EnvVarKind.User, AppDb.AppData("env"));

        [CmdOp("env/process")]
        void EmitProcessEnv()
            => EnvSvc.EmitReport(EnvVarKind.Process, AppDb.AppData($"env/{Environment.ProcessId}"));

        [CmdOp("env/pid")]
        void ProcessId()
            => Write(Environment.ProcessId);

        [CmdOp("env/cpucore")]
        void ShowCurrentCore()
            => Emitter.Write(string.Format("Cpu:{0}", Kernel32.GetCurrentProcessorNumber()));

        [CmdOp("ws/register")]
        void RegisterWorkspace(CmdArgs args)
        {
            WsRegistry.Register(arg(args,0).Value, FS.dir(arg(args,1).Value));
            var entries = WsRegistry.Entries();            
        }

        void ShowMemory()
        {
            var info = WinMem.basic();
            var formatter = Tables.formatter<BasicMemoryInfo>(16,RecordFormatKind.KeyValuePairs);
            Wf.Data(formatter.Format(info));
        }

        [CmdOp("env/stack")]
        void Stack()
            => Write(Environment.StackTrace);

        [CmdOp("env/pagesize")]
        void PageSize()
            => Write(Environment.SystemPageSize);

        [CmdOp("env/ticks")]
        void Ticks()
            => Write(Environment.TickCount64);

        [CmdOp("env/mem-physical")]
        void WorkingSet()
            => Write(((ByteSize)Environment.WorkingSet));

        [CmdOp("env/args")]
        void CmdlLineArgs()
            => iter(Environment.GetCommandLineArgs(), arg => Write(arg));

        [CmdOp("env/cwd")]
        void Cwd()
            => Write(FS.dir(Environment.CurrentDirectory)); 

        [CmdOp("memory/query")]
        void QueryMemory(CmdArgs args)
        {            
            var @base = ExecutingPart.Process.Adapt().BaseAddress;
            if(args.Count != 0)
            {
                var result = DataParser.parse(args[0].Value, out @base);
                if(result.Fail)
                {
                    Error($"Could not parse ${args[0].Value} as an address");
                    return;
                }
            }

            var basic = default(MEMORY_BASIC_INFORMATION);
            WinMem.vquery(@base, ref basic);
            Write(basic.ToString());
        }

        [CmdOp("cd")]
        void Cd(CmdArgs args)
            => Channel.Row(Env.cd(args));

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
            Channel.Row(Env.cd());
        }

        void Where(CmdArgs args)
        {
            var search = args[0];

        }

        [CmdOp("dir")]
        void Dir(CmdArgs args)
        {
            var root = Env.cd();
            if(args.Count != 0)
            root = FS.dir(args[0]);
            var folders = root.Folders();
            iter(folders, f => Channel.Row(f));
            var files = root.Files(false);
            iter(files, f => Channel.Row(((FileUri)f)));
        }        

        void Ls(CmdArgs args)
            => Dir(args);

        [CmdOp("api/emit/impls")]
        void EmitImplMaps()
        {
            var src = Clr.impls(Parts.Lib.Assembly, Parts.Lib.Assembly);
            using var writer = AppDb.ApiTargets().Path("api.impl.maps", FileKind.Map).Utf8Writer();
            for(var i=0; i<src.Count; i++)
                src[i].Render(s => writer.WriteLine(s));
        }

        [CmdOp("run/script")]
        void RunAppScript(CmdArgs args)
        {
            RunAppScript(FS.path(arg(args,0)));
        }

        void RunAppScript(FilePath src)
        {
            if(src.Missing)
            {
                Channel.Error(AppMsg.FileMissing.Format(src));
            }
            else
            {
                var lines = src.ReadNumberedLines(true);
                var count = lines.Count;
                for(var i=0; i<count; i++)
                {
                    ref readonly var content = ref lines[i].Content;
                    if(AppCmd.parse(content, out AppCmdSpec spec))
                        RunCmd(spec);
                    else
                    {
                        Error($"ParseFailure:'{content}'");
                        break;
                    }
                }
            }
        }

        [CmdOp("develop")]
        void Develop(CmdArgs args)
        {
            var cd = Env.cd();
            var workspaces = cd.Files(FS.ext("code-workspace"));
            var preconditions = cd.Files(FileKind.Cmd).Where(p => p.FileName == FS.file("env", FileKind.Cmd));
            if(preconditions.IsNonEmpty)
            {

            }

            if(workspaces.IsNonEmpty)
                Dev.VsCode(cd + workspaces[0].FileName);
            else
                Dev.VsCode(cd);            
        }

        [CmdOp("devenv")]
        void DevEnv(CmdArgs args)
            => Dev.DevEnv(args[0].Value);

        [CmdOp("vscode")]
        void VsCode(CmdArgs args)
            => Dev.VsCode(args[0].Value);

        [CmdOp("cmd")]
        void RunCmd(CmdArgs args)
            => ProcessControl.start(Channel, args);

        [CmdOp("help")]
        void GetHelp(CmdArgs args)
        {
            var tool = args[0].Value;
            var dst = AppDb.DbTargets("tools/help").Path(FS.file(tool, FileKind.Help));        
            ProcessControl.run(Channel, tool, "--help", args, dst);
        }

        [CmdOp("tool")]
        void RunTool(CmdArgs args)
        {
            var tool = arg(args,0).Value;
            var script = arg(args,1).Value;
            var count = args.Count - 2;
            var path = AppDb.Toolbase($"{tool}/scripts").Path(FS.file(script,FileKind.Cmd));
            var emitter = text.emitter();
            var j=2;
            for(var i=0; i<count; i++, j++)
            {
                emitter.Append(Chars.Space);
                emitter.Append(args[i].Value);
            }
            
            ProcessControl.start(Channel, CmdTerm.cmd(path, CmdKind.Tool, emitter.Emit()));        
        }

        [CmdOp("tool/script")]
        Outcome ToolScript(CmdArgs args)
            => Tooling.RunScript(arg(args,0).Value, arg(args,1).Value);

        [CmdOp("tool/setup")]
        void ConfigureTool(CmdArgs args)
            => Tooling.Setup(Cmd.tool(args));

        [CmdOp("tool/docs")]
        void ToolDocs(CmdArgs args)
            => iter(Tooling.LoadDocs(arg(args,0).Value), doc => Write(doc));

        [CmdOp("symlink")]
        void Link(CmdArgs args)
        {
            const string Pattern = "mklink /D {0} {1}";
            var src = text.quote(FS.dir(arg(args,0).Value).Format(PathSeparator.BS));
            var dst = text.quote(FS.dir(arg(args,1).Value).Format(PathSeparator.BS));
            var cmd = CmdTerm.cmd(string.Format(Pattern,src,dst));
            ProcessControl.run(cmd);
        }

        [CmdOp("dev")]
        void LaunchCmdTerm(CmdArgs args)
        {
            var channel = Channel;
            void OnA(string msg)
            {
                channel.Row(msg, FlairKind.Data);
            }

            void OnB(string msg)
            {
                channel.Row(msg, FlairKind.StatusData);
            }
            
            if(args.Count == 0)
            {
                var wd = Env.cd();
                var options = $"-NoLogo -i -wd {text.dquote(Env.cd())}";
                ProcessControl.start(channel, new SysIO(OnA,OnB), CmdArgs.create("pwsh.exe", options), wd);
            }
        }

        [CmdOp("cmd/redirect")]
        void Redirect(CmdArgs args)
            => Dev.Redirect(args);
    }
}