//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.Diagnostics.Tracing.Parsers;
    using Microsoft.Diagnostics.Tracing.Parsers.Kernel;
    using Microsoft.Diagnostics.Tracing.Session;
    using System.Diagnostics.Eventing.Reader;

    using static sys;
    using static Env;

    sealed class EnvCmd : WfAppCmd<EnvCmd>
    {    
        [CmdOp("env/modules")]
        void LoadedModule(CmdArgs args)
            => iter(args, arg => Channel.Row(NativeModules.loaded(arg)));

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
            => ApiMd.emit(Channel, ApiServers.catalog(), EnvDb);
    
        [CmdOp("api/version")]
        void ApiVersion()
            => Channel.Write(ExecutingPart.Assembly.AssemblyVersion());

        [CmdOp("api/script")]
        void RunAppScript(CmdArgs args)
            => ApiServers.Runner.RunCommandScript(FS.path(args[0]));

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
            => Env.EmitReports(Channel);

        [CmdOp("env/pid")]
        void ProcessId()
            => Channel.Write(Env.pid());

        [CmdOp("env/cpucore")]
        void ShowCurrentCore()
            => Channel.Write(Env.cpucore());

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

        [CmdOp("jobs/types")]
        void ListJobTypes()
        {
            var db = AppSettings.Default.DbRoot();
            Channel.Write(db.Root);
            Channel.Write(RP.PageBreak80);
            var jobs = db.Sources("jobs");
            Channel.Write($"Jobs: {jobs.Root}");
            jobs.Root.Folders(true).Iter(f => Channel.Write(f.Format()));
        }

        [CmdOp("env/id")]
        void EvId(CmdArgs args)
        {
            var id = Env.id();
            var msg = EmptyString;
            if(args.IsNonEmpty)
            {
                Env.id(args.First.Value);
                if(id.IsNonEmpty)
                    msg = $"{id} -> {Env.id()}";
                else
                    msg = $"{Env.id()}";
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
            => Tooling.redirect(Channel, args);

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

        [CmdOp("tool")]
        void ToolHelp(CmdArgs args)
            => Tooling.redirect(Channel,args).Wait();        
        
        void EmitEtwRecords(string provider)
        {
            try
            {
                var filename = FS.file(provider, FileKind.Xml);
                var path = EnvDb.Scoped("etw").Path(filename);
                var xml = RegisteredTraceEventParser.GetManifestForRegisteredProvider(provider);
                Channel.FileEmit(xml, path);
            }
            catch(Exception e)
            {
                Channel.Warn(e.Message);
            }
        }

        [CmdOp("etw/events")]
        void EtwProviders()
        {
            var providers = EventLogSession.GlobalSession.GetProviderNames();
            iter(providers, EmitEtwRecords,true);
        }

        [CmdOp("process/monitor/start")]
        void ProcMonStart()
        {
            var monitor = Channel.ProcessMonitor();
            monitor.Start();
        }

        [CmdOp("process/monitor/stop")]
        void ProcMonStop()
        {
            var monitor = Channel.ProcessMonitor();
            monitor.Stop();
        }
    }
}