//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    using static Algs;

    public class WfCmd : AppCmdService<WfCmd>
    {
        WsRegistry WsRegistry => Wf.WsRegistry();

        ProjectScripts ProjectScripts => Wf.ProjectScripts();

        void _CatalogFiles(CmdArgs args)
        {
            var src = FS.dir(arg(args,0));
            var files = FS.listing(src);
            var name = Archives.identifier(src);
            var records = AppDb.Catalogs("files").Table<ListedFile>(name);
            Emitter.TableEmit(files, records);            
            var list = AppDb.Catalogs("files").Path(name,FileKind.List);
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

        [CmdOp("files")]
        void CatalogFiles(CmdArgs args)
            => _CatalogFiles(args);

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
            var db = AppDb.DbRoot();
            Write(db.Root);
            Write(RpOps.PageBreak80);
            var jobs = db.Sources("jobs");
            Write($"Jobs: {jobs.Root}");

            jobs.Root.Folders(true).Iter(f => Write(f.Format()));
        }

        [CmdOp("env/thread")]
        void ShowThread()
            => Write(string.Format("ThreadId:{0}", Kernel32.GetCurrentThreadId()));

        [CmdOp("env/exe")]
        void ProcessOrigin()
            => Write(FS.path(Environment.ProcessPath));

        [CmdOp("app/deploy")]
        void Deploy()
        {
            var dst = AppDb.Tools("z0/cmd").Targets().Root;
            var src = ExecutingPart.Assembly.Path().FolderPath;
            Archives.robocopy(src,dst);
        }


        [CmdOp("cmd")]
        protected void RunCmd(CmdArgs args)
            => CmdScripts.start(args);

        // tool ilc help
        [CmdOp("tool")]
        void RunTool(CmdArgs args)
        {
            var tool = arg(args,0).Value;
            var script = arg(args,1).Value;
            var count = args.Count - 2;
            var _args = count > 0 ? sys.alloc<string>(count) : sys.empty<string>();
            var path = AppDb.Toolbase($"{tool}/scripts").Path(FS.file(script,FileKind.Cmd));
            var emitter = text.emitter();
            var j=2;
            for(var i=0; i<count; i++, j++)
            {
                emitter.Append(Chars.Space);
                emitter.Append(args[i].Value);
            }
            
            var cmd = Cmd.cmdline(path, CmdKind.Tool, emitter.Emit());        
            CmdScripts.start(cmd, Emitter);        
        }

        [CmdOp("cmd/copy")]
        void Copy(CmdArgs args)
        {
            var src = FS.dir(arg(args,0).Value);
            var dst = FS.dir(arg(args,1).Value);
            Archives.robocopy(src,dst);
        }

        [CmdOp("pwsh")]
        protected void RunPwshCmd(CmdArgs args)
        {
            var cmd = Cmd.pwsh(Cmd.join(args));
            Status($"Executing '{cmd}'");
            CmdScripts.start(cmd);
        }


        static FS.Files launchers()
            => DbArchive.match(AppDb.Control("launch").Root, FS.Ps1, FS.Cmd);

        [CmdOp("launchers")]
        protected void Launchers(CmdArgs args)
        {
            var src = launchers();
            var emitter = text.emitter();
            iter(src, file => emitter.AppendLine(file.ToUri()));
            var data = emitter.Emit();
            Emitter.Row(data);
            Emitter.FileEmit(data, AppDb.App().Path("launchers", FileKind.List));
        }

        [CmdOp("launch")]
        protected void LaunchTargets(CmdArgs args)
        {
            var src = launchers().Map(x => (x.FileName,x)).ToDictionary();
            foreach(var arg in args)
            {
                var file = FS.file(arg.Value,FileKind.Cmd);
                var path = FS.FilePath.Empty;
                if(src.TryGetValue(file, out path))
                {
                    CmdScripts.start(CmdScripts.create(path));
                }
                else
                {
                    file = FS.file(arg.Value,FileKind.Ps1);
                    if(src.TryGetValue(file, out path))
                    {
                        CmdScripts.start(CmdScripts.create(path));
                    }
                    else
                    {
                        Error($"Launcher '{arg} not found");
                    }
                }

                if(path.IsNonEmpty)                
                    Status($"Script {path.ToUri()} executing", FlairKind.Ran);

            }
        }

        [CmdOp("app/settings")]
        void ReadSettings(CmdArgs args)
        {
            var src = AppSettings.load(Emitter);
            iter(src, setting => Write(setting.Format()));

            //iter(src, setting => Write(setting.Format()));
        }

        [CmdOp("services")]
        void GetServices()
        {
            Write(ServiceSpecs.discover(ApiCatalog.Components));
        }

        [CmdOp("setting")]
        Outcome Setting(CmdArgs args)
        {
            var name = arg(args,0).Value;
            var result = Outcome.Success;
            if(AppSettings.Service().Find(name, out var value))
            {
                Write($"{name}:{value}");
            }
            else
            {
                result = (false, $"Setting '{name}' not found");
            }
            return result;
        }

        [CmdOp("memory")]
        Outcome ShowMemHex(CmdArgs args)
        {
            var address = MemoryAddress.Zero;
            var result = DataParser.parse(arg(args,0), out address);
            if(result)
            {

                var size = 16u;
                if(args.Count >= 2)
                    result = DataParser.parse(arg(args,1), out size);

                if(result)
                {
                    ref readonly var src = ref address.Ref<byte>();
                    var data = Algs.cover(src,size);
                    var hex = data.FormatHex();
                    Write(string.Format("{0,-16}: {1}", address, hex));
                }

            }
            return result;
        }

        [CmdOp("env")]
        void EmitEnv(CmdArgs args)
        {
            var dst = AppDb.App("env").Root;
            EnvVars.emit(Emitter,EnvVarKind.Process, dst);
            EnvVars.emit(Emitter,EnvVarKind.User, dst);
            EnvVars.emit(Emitter,EnvVarKind.Machine, dst);
        }

        [CmdOp("env/machine")]
        void EmitMachineEnv()
            => EnvVars.emit(Emitter, EnvVarKind.Machine, AppDb.Env().Root);

        [CmdOp("env/user")]
        void EmitUserEnv()
            => EnvVars.emit(Emitter, EnvVarKind.User, AppDb.Env().Root);

        [CmdOp("env/process")]
        void EmitProcessEnv()
            => EnvVars.emit(Emitter, EnvVarKind.Process, AppDb.Env().Root);

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

        const string RegKey = @"HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Environment";

        static CmdScript unset(CmdArg src)
            => CmdScripts.create("unset", $"reg delete {RegKey} /F /V {src.Value}");

        [CmdOp("env/unset")]
        void Unset(CmdArgs args)
        {
            var scripts = map(args,unset);
            iter(scripts, script => CmdScripts.run(script));
        }

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

            var basic = BasicMemoryInfo.Empty;
            WinMem.vquery(@base, ref basic);
            Write(basic.ToString());
        }
    }
}