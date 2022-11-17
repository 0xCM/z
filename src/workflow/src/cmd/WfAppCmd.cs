//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    using static sys;

    public class WfAppCmd : WfAppCmd<WfAppCmd>
    {
        ArchiveRegistry ArchiveRegistry => Wf.ArchiveRegistry();

        ProjectScripts ProjectScripts => Wf.ProjectScripts();

        ProcessMemory ProcessMemory => Wf.ProcessMemory();

        Tooling Tooling => Wf.Tooling();

        ApiMd ApiMd => Wf.ApiMd();

        [CmdOp("sdk/catalog")]
        void Sdk(CmdArgs args)
        {
            var src = FS.dir(args[0]);
            var sdk = Sdks.sdk(src);
            var modules = sdk.Modules;
            iter(modules.Dll(), file => Write(file));
        }

        void EmitEcmaJobs()
        {
            var root = Env.var(EnvVarKind.Process, EnvTokens.DOTNET_ROOT, FS.dir).Value;
            var src = root.Files(FileKind.Dll).Map(x => new FileUri(x.Format())).ToSeq();
            var name = CmdId.identify<EmitEcmaDatasets>().Format();
            var ts = timestamp();
            var dst = AppDb.Jobs(CmdId.identify<EmitEcmaDatasets>().Format()).Path($"{name}.{ts}.jobs", FileKind.Json);
            var job = new EmitEcmaDatasets();
            job.JobId = ts;
            job.Sources = src;
            job.Targets = AppDb.DbTargets("tools/jobs").Folder(CmdId.identify<EmitEcmaDatasets>().Format());            
            var data = JsonData.serialize(job);
            FileEmit(data, dst);
        }

        [CmdOp("api/emit")]
        void ApiEmit()
            => ApiMd.Emitter().Emit(ApiMd.parts(), AppDb.ApiTargets());

        [CmdOp("api/types")]
        void EmitApiTypes()
            => ApiMd.Emitter().EmitApiTypes(ApiMd.parts(), AppDb.ApiTargets());

        [CmdOp("api/tables")]
        void EmitApiTables()
            => ApiMd.Emitter().EmitApiTables(ApiMd.parts(), AppDb.ApiTargets());

        [CmdOp("version")]
        void Version()
            => Channel.Row($"[z0.{ExecutingPart.Name}-v{ExecutingPart.Assembly.AssemblyVersion()}]({ExecutingPart.Assembly.Path().ToUri()})");

        [CmdOp("cmd/redirect")]
        void Redirect(CmdArgs args)
            => Cmd.redirect(Channel, args);

        [CmdOp("cmd")]
        void RunCmd(CmdArgs args)
            => ProcessControl.start(Channel, args);

        [CmdOp("help")]
        void GetHelp(CmdArgs args)
        {
            var tool = args[0].Value;
            var dst = AppDb.DbTargets("tools/help").Path(FS.file(tool, FileKind.Help));
            Cmd.run(Channel, tool, args.Length > 1 ? args[1].Value : "--help", dst);
        }

        [CmdOp("develop")]
        void Develop(CmdArgs args)
        {
            var cd = Env.cd();
            var launcher = cd + FS.file("develop", FileKind.Cmd);
            if(launcher.Exists)
                Cmd.start(Channel, Cmd.args(launcher)); 
            else
            {
                var workspaces = cd.Files(FS.ext("code-workspace"));
                if(workspaces.IsNonEmpty)
                    WfTools.vscode(Channel, cd + workspaces[0].FileName);
                else
                    WfTools.vscode(Channel, cd); 
            }
        }

        [CmdOp("devenv")]
        void DevEnv(CmdArgs args)
            => WfTools.devenv(Channel, args[0].Value);

        [CmdOp("vscode")]
        void VsCode(CmdArgs args)
            => WfTools.vscode(Channel, args[0].Value);

        [CmdOp("zip")]
        void Zip(CmdArgs args)
            => Archives.zip(Channel,args);

        [CmdOp("copy")]
        void Copy(CmdArgs args)
            => Archives.copy(Channel,args);

        [CmdOp("env/include")]
        void EnvInclude()
            => Channel.Row(Env.paths(EnvTokens.INCLUDE, EnvVarKind.Process).Delimit(Chars.NL));

        [CmdOp("env/path")]
        void EnvPath()
            => Channel.Row(Env.paths(EnvTokens.PATH, EnvVarKind.Process).Delimit(Chars.NL));

        [CmdOp("env/lib")]
        void EnvLib()
            => Channel.Row(Env.paths(EnvTokens.LIB, EnvVarKind.Process).Delimit(Chars.NL));

        [CmdOp("archives")]        
        void ListArchives(CmdArgs args)
            => Emitter.Row(AppDb.Archives().Folders().Delimit(Eol));

        [CmdOp("process/modules")]
        void ListModules()
        {
            var src = ImageMemory.modules(ExecutingPart.Process);
            var dst = AppDb.AppData().Targets(ApiAtomic.tables).Path($"process.modules.{timestamp()}", FileKind.Csv);
            var formatter = CsvChannels.formatter<ProcessModuleRow>();
            for(var i=0; i<src.Length; i++)
                Row(formatter.Format(src[i]));
            Channel.TableEmit(src, dst);
        }

        [CmdOp("archives/list")]        
        void ArchiveFiles(CmdArgs args)
        {
            var src = AppDb.Archive(arg(args,0).Value);
            iter(src.Files(true), file => Write(file.ToUri()));
        }

        [CmdOp("files")]
        void CatalogFiles(CmdArgs args)
            => Archives.catalog(Channel, args);
            
        [CmdOp("env/paths")]
        void ProcPaths()
        {
            var src = Env.process().ToLookup();
            var names = src.Keys;
            var dst = text.emitter();
            iter(names, name => {
                dst.AppendLine(src[name]);
            });

            Channel.Row(dst.Emit());
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

        [CmdOp(EnvMod.Names.EnvTools)]
        void EnvTools(CmdArgs args)
            => Env.tools(Channel, args);

        [CmdOp("app/deploy")]
        void Deploy()
        {
            var dst = AppDb.Tools("z0/cmd").Targets().Root;
            var src = ExecutingPart.Assembly.Path().FolderPath;
            Archives.copy(Channel, src, dst);
        }

        static Files launchers()
            => FilteredArchive.match(AppSettings.Control("launch").Root, FileKind.Cmd, FileKind.Ps1);

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
        
        [CmdOp("settings")]
        void ReadSettings(CmdArgs args)
        {
            if(args.IsEmpty)
                Channel.Row(AppSettings.Format());
            else
                Channel.Row(AppSettings.absorb(FS.path(args.First.Value)));
        }

        [CmdOp("services")]
        void GetServices()
        {
            var src = ApiMd.parts();
            Write(ApiRuntime.services(src));
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
            => Env.reports(Channel, AppDb.AppData("env"));

        [CmdOp("env/machine")]
        void EmitMachineEnv()
            => Env.report(Channel, EnvVarKind.Machine, AppDb.AppData("env"));

        [CmdOp("env/user")]
        void EmitUserEnv()
            => Env.report(Channel, EnvVarKind.User, AppDb.AppData("env"));

        [CmdOp("env/process")]
        void EmitProcessEnv()
            => Env.report(Channel, EnvVarKind.Process, AppDb.AppData($"env/{Environment.ProcessId}"));

        [CmdOp("env/pid")]
        void ProcessId()
            => Write(Environment.ProcessId);

        [CmdOp("env/cpucore")]
        void ShowCurrentCore()
            => Emitter.Write(string.Format("Cpu:{0}", Kernel32.GetCurrentProcessorNumber()));

        [CmdOp("archives/register")]
        void RegisterWorkspace(CmdArgs args)
        {
            ArchiveRegistry.Register(arg(args,0).Value, FS.dir(arg(args,1).Value));
            var entries = ArchiveRegistry.Entries();            
        }

        void ShowMemory()
        {
            var info = WinMem.basic();
            var formatter = CsvChannels.formatter<BasicMemoryInfo>(16,RecordFormatKind.KeyValuePairs);
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

        [CmdOp("memory/emit")]
        void EmitRegions()
            => ProcessMemory.EmitRegions(Process.GetCurrentProcess(), ApiPacks.create());

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

        [CmdOp("nuget/stage")]
        void DevPack(CmdArgs args)
        {
            var src = FS.dir(arg(args,0));
            FilePacks.stage(Channel,PackageKind.Nuget, src);
        }

        [CmdOp("sln/root")]
        void SlnRoot(CmdArgs args)
        {
            if(args.Count == 1)
                Environment.CurrentDirectory = args.First.Value;
            Channel.Row(Env.cd());
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

        [CmdOp("cmd/script")]
        void RunAppScript(CmdArgs args)
            => ApiCmd.RunCmdScript(FS.path(arg(args,0)));

        [CmdOp("cfg")]
        void LoadCfg(CmdArgs args)
        {
            var src = args.Count != 0 ? FS.dir(args.First) : Env.cd();
            iter(src.Files(FileKind.Cfg), file => Channel.Row(Env.cfg(file).Format()));    
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
            
            ProcessControl.start(Channel, Cmd.cmd(path, CmdKind.Tool, emitter.Emit()));        
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
            var src = FS.dir(arg(args,0).Value);
            var dst = FS.dir(arg(args,1).Value);
            var result = FS.symlink(src,dst,true);
            if(result)
                Channel.Status($"symlink:{src} -> {dst}");
            else
                Channel.Error(result.Message);
            //ProcessControl.start(Channel, FS.path("mlkink.exe"), Cmd.args("/D", src, dst));
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
                Cmd.start(channel, new SysIO(OnA,OnB), CmdArgs.create("pwsh.exe", options), wd);
            }
        }

        [CmdOp("api/calls/check")]
        void CheckApiCalls()
        {
            CheckMullo(Rng.@default());
        }

        [CmdOp("api/catalog")]
        void EmitApiCatalog()
        {
            var src = ApiRuntime.catalog();
            var parts = src.Parts;
            var hosts = src.PartHosts();
            var catalogs = src.PartCatalogs;
            var assemblies = src.Assemblies;

            var counter = 0u; 
            iter(parts, part => {
                Channel.Row(string.Format("{0:D6} | {1,-24} | {2,-16} {3}", counter++, part.Owner.GetSimpleName(), part.Owner.AssemblyVersion(), part.Owner.Path()));
            });

            counter=0u;
            iter(hosts, host => {
                Channel.Row(string.Format("{0:D6} | {1,-16} | {2}", counter++, host.Assembly.GetSimpleName(), host.HostUri));
            });            
        }

        void CheckMullo(IBoundSource Source)
        {
            var @class = ApiClassKind.MulLo;
            var key = ApiKeys.key(Parts.Math.Resolved.Name, 1, @class);
            var count = 12;
            var left = Source.Array<uint>(count,100,200);
            var right = Source.Array<uint>(count,100,200);
            var dst = alloc<uint>(count);
            var results = alloc<ApiCall<uint,uint,uint>>(count);
            var output = alloc<uint>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var a = ref skip(left,i);
                ref readonly var b = ref skip(right,i);
                seek(dst,i) = cpu.mullo(a,b);
                seek(output,i) = math.mul(a,b);
                seek(results, i) = ApiCalls.call(key,a,b,skip(dst,i));
            }

            for(var i=0; i<count; i++)
            {
                Channel.Row(skip(results,i).Format() + " | " + skip(output,i).ToString());
            }
        }            

        [CmdOp("api/packs/list")]
        void ListApiPacks()
        {
            var src = ApiPacks.discover();
            for(var i=0; i<src.Count; i++)
            {
                Channel.Write($"{i}", src[i].Timestamp);
            }
        }

        [CmdOp("api/pack/list")]
        Outcome ListApiPack(CmdArgs args)
        {
            var result = Outcome.Failure;
            var src = ApiPacks.discover();
            var pack = default(IApiPack);
            if(args.Count > 0)
            {
                result = DataParser.parse(arg(args,0), out int i);
                if(result)
                {
                    var count = src.Length;
                    if(i<count-1)
                    {
                        pack = src[i];
                        result = true;
                    }
                }
            }
            else
            {
                if(src.Count >= 0)
                {
                    pack = src.Last;
                    result = true;
                }
            }

            if(result)
            {
                var listing = Archives.listing(pack.Files());
                var dst = AppDb.AppData().PrefixedTable<ListedFile>($"api.pack.{pack.Timestamp}");
                Channel.TableEmit(listing, dst);
            }

            return result;
        }
    }
}