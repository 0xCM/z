//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Env;

    sealed class EnvCmd : ApiService<EnvCmd>
    {    
        [CmdOp("env/include")]
        void EnvInclude()
            => Env.path(Channel, EnvPathKind.Include, ShellData);

        [CmdOp("env/path")]
        void EnvPath()
            => Env.path(Channel, EnvPathKind.FileSystem, ShellData);

        [CmdOp("env/lib")]
        void EnvLib()
            => Env.path(Channel, EnvPathKind.Lib, ShellData);

        [CmdOp("api/commands")]
        void EmitCommands()
            => Wf.ApiCmd().EmitApiCatalog();
            //=> ApiCmd.emit(Channel, ApiCmd.catalog(), ShellData.Path(ExecutingPart.Name.Format() + ".commands", FileKind.Csv));

        [CmdOp("api/version")]
        void ApiVersion()
            => Channel.Write(ExecutingPart.Assembly.AssemblyVersion());

        [CmdOp("env/tools")]
        void EnvTools()
            => Tools.emit(Channel, Tools.ambient(), ShellData);

        [CmdOp("api/script")]
        void RunAppScript(CmdArgs args)
            => ApiCmd.start(Channel, args);

        [CmdOp("env/stack")]
        void Stack()
            => Channel.Write(Environment.StackTrace);

        [CmdOp("env/pagesize")]
        void PageSize()
            => Channel.Write(Environment.SystemPageSize);

        [CmdOp("env/ticks")]
        void Ticks()
            => Channel.Write(Environment.TickCount64);

        [CmdOp("env/reports")]
        void EmitEnv(CmdArgs args)
            => reports(Channel, ShellData);

        [CmdOp("env/machine")]
        void EmitMachineEnv()
            => report(Channel, EnvVarKind.Machine, ShellData);

        [CmdOp("env/user")]
        void EmitUserEnv()
            => report(Channel, EnvVarKind.User, ShellData);

        [CmdOp("env/process")]
        void EmitProcessEnv()
            => report(Channel, EnvVarKind.Process, ShellData);

        [CmdOp("env/pid")]
        void ProcessId()
            => Channel.Write(Env.pid());

        [CmdOp("env/cpucore")]
        void ShowCurrentCore()
            => Emitter.Write(Env.cpucore());

        [CmdOp("env/tid")]
        void ShowThread()
            => Channel.Row(Env.tid());

        [CmdOp("env/root")]
        void SlnRoot(CmdArgs args)
        {
            if(args.Count == 1)
                Environment.CurrentDirectory = args.First.Value;
            Channel.Row(Env.cd());
        }

        [CmdOp("env/cfg")]
        void LoadCfg(CmdArgs args)
        {
            var src = args.Count != 0 ? FS.dir(args.First) : Env.cd();
            iter(src.Files(FileKind.Cfg), file => Channel.Row(CfgBlocks.load(file).Format()));    
        }        

        [CmdOp("jobs/types")]
        void ListJobTypes()
        {
            var db = AppSettings.Default.DbRoot();
            Write(db.Root);
            Write(RP.PageBreak80);
            var jobs = db.Sources("jobs");
            Write($"Jobs: {jobs.Root}");
            jobs.Root.Folders(true).Iter(f => Write(f.Format()));
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

        [CmdOp("version")]
        void Version()
            => Channel.Row($"[z0.{ExecutingPart.Name}-v{ExecutingPart.Assembly.AssemblyVersion()}]({ExecutingPart.Assembly.Path().ToUri()})");

        [CmdOp("env/args")]
        void CmdlLineArgs()
            => iter(Environment.GetCommandLineArgs(), arg => Channel.Write(arg));

        [CmdOp("cmd")]
        void Redirect(CmdArgs args)
            => ProcessControl.redirect(Channel, args);

        [CmdOp("cd")]
        void Cd(CmdArgs args)
            => Channel.Row(Env.cd(args));

        [CmdOp("dir")]
        void Dir(CmdArgs args)
        {
            var src = args.Count == 0 ? Env.cd().ToArchive() : FS.dir(args[0]).ToArchive();
            Channel.Row($"dir {src.Root} >");
            iter(src.Folders(false), folder => Channel.Row(folder));
            iter(src.Files(false), file => Channel.Row(file));            
        }        

        [CmdOp("settings")]
        void ReadSettings(CmdArgs args)
        {
            if(args.IsEmpty)
                Channel.Row(AppSettings.Default.Format());
            else
                Channel.Row(AppSettings.Default.Absorb(FS.path(args.First.Value)));
        }

        [CmdOp("services")]
        void GetServices()
        {
           var services = ApiServers.services(ApiAssemblies.Parts);
           iter(services, svc => {
            var fmt = svc.Format();
            if(text.nonempty(fmt))
                Channel.Row(fmt);
           });
        }

        [CmdOp("develop")]
        void Develop(CmdArgs args)
            => CodeLauncher.create(Channel).Launch(args, launched => {});

        [CmdOp("devenv")]
        void DevEnv(CmdArgs args)
            => Tools.devenv(Channel, args[0].Value);

        [CmdOp("vscode")]
        void VsCode(CmdArgs args)
            => Tools.vscode(Channel, args[0].Value);

        [CmdOp("help")]
        void ToolHelp(CmdArgs args)
        {
            var tool = FS.path(args[0]);            
            var dst = args.Count > 1 ? FS.path(args[1]) : AppDb.DbTargets("tools/help").Path(tool.FileName.ChangeExtension(FileKind.Help));
            var task = ProcessControl.redirect(Channel, tool, "--help", dst);
            var token = task.Result;
            if(!token.Success)
            {

            }
            
        }

        [CmdOp("json/types")]
        void JsonTypes()
        {
            iter(Z0.JsonTypes.Types, t => Channel.Row(t));
        }
    }
}