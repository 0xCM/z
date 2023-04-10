//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public partial class Tooling : WfAppCmd<Tooling>
    {

        class ServiceCache : AppServices<ServiceCache>
        {
            
        }

        static readonly ServiceCache ToolServices = new();

        [CmdOp("tool/docs")]
        void ToolDocs(CmdArgs args)
            => iter(LoadDocs(arg(args,0).Value), doc => Channel.Write(doc));

        public static ToolCmd command(FilePath tool, params ToolCmdArg[] args)
            => new (tool,args, Env.cd(), EnvVars.Empty);

        public static ToolCmd command(FilePath tool, ToolCmdArgs args)
            => new (tool, args, Env.cd(), EnvVars.Empty);

        public static ToolCmd command(FilePath tool, ToolCmdArgs args, FolderPath work)
            => new (tool,args, work, EnvVars.Empty);

        public static ToolCmd command(FilePath tool, ToolCmdArgs args, FolderPath work, params EnvVar[] vars)
            => new (tool,args, work, vars);


        public static ToolCmdArg flag(ArgPrefixKind prefix, string name)
            => new ToolCmdArg{
                Prefix = prefix,
                Name = name,
            };

        public static ToolCmdArg option(ArgPrefixKind prefix, string name, ArgSepKind sep, ArgValue value)
            => new ToolCmdArg{
                Prefix = prefix,
                Name = name,
                Sep = sep,
                Value = value
            };

        public static ToolCmdArg arg(string name, ArgValue value)
            => new ToolCmdArg{
                Name = name,
                Value = value
            };
        
        public static ToolCmdSpec spec(FolderPath? work = null, params EnvVar[] vars)
            => new (FilePath.Empty, CmdArgs.Empty, work ?? Env.cd(), vars, null, null);

        public static ToolCmdSpec spec(FolderPath work, params EnvVar[] vars)
            => new(FilePath.Empty, CmdArgs.Empty, work, vars, null, null);

        public static ToolCmdSpec spec(FolderPath work, EnvVars vars, Action<Process> created)
            => new(FilePath.Empty, CmdArgs.Empty, work, vars, created, null);

        public static ToolCmdSpec spec(FolderPath work, EnvVars vars, Action<Process> created, Action<int> exit)
            => new(FilePath.Empty, CmdArgs.Empty, work, vars, created, exit);

        public static ToolCmdSpec spec()
            => new(FilePath.Empty, CmdArgs.Empty, Env.cd(), EnvVars.Empty, null, null);

        public static ToolCmdSpec spec(FilePath tool, CmdArgs args)
            => new(tool, args,Env.cd(), EnvVars.Empty, null, null);

        public static IToolStreamWriter writer(FilePath src)
            => new ToolStreamWriter(src);
         
        public static Task<ExecStatus> start(IToolFlow flow, ToolCmdSpec spec)
            => sys.start(() => run(flow, spec));
         
        static ExecStatus run(IToolFlow flow, ToolCmdSpec spec)
        {
            var i=0u;
            var j=0u;
            var tool = spec.ToolPath;
            var args = spec.Args;
            var psi = new ProcessStartInfo(tool.Format(), args.Format())
            {
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                ErrorDialog = false,
                CreateNoWindow = true,
                RedirectStandardInput = false,
                WorkingDirectory = spec.WorkingDir.Format(PathSeparator.BS)
            };

            iter(spec.Vars, v => psi.Environment.Add(v.Name, v.Value));

            void OnStatus(object sender, DataReceivedEventArgs e)
            {
                if(sys.nonempty(e.Data))
                {
                    inc(ref i);
                    flow.OnStatus((i,e.Data));
                }                    
            }
    
            void OnError(object sender, DataReceivedEventArgs e)
            {
                if(sys.nonempty(e.Data))
                {
                    inc(ref j);
                    flow.OnError((j,e.Data));
                }
            }

            var status = default(ExecStatus);
            var running = flow.Running($"{tool}:{args}");
            status.Token = running.Token;
            try
            {                
                using var process = sys.process(psi);
                process.OutputDataReceived += OnStatus;
                process.ErrorDataReceived += OnError;
                process.Start();
                flow.OnStart(running.Token);
                status.StartTime = sys.now();
                status.Id = process.Id;
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                status.HasExited = true;
                status.ExitTime = sys.now();
                status.Duration = status.ExitTime - status.StartTime;
                status.ExitCode = process.ExitCode;
                flow.OnFinish(status);
                flow.Ran(running);
            }
            catch(Exception e)
            {
                inc(ref j);
                status.ExitCode = -1;
                flow.OnError((j,e.ToString()));
                flow.OnFinish(status);

            }
            return status;
        }

        public static ExecToken shell(IWfChannel channel, CmdArgs args)
        {
            var profile = args[0].Value;
            var cwd = args.Count > 1 ? FS.dir(args[1]) : Env.cd();
            return shell(channel, profile, cwd);  
        }

        [Op]
        public static ExecToken shell(IWfChannel channel, string profile, FolderPath cwd)
        {
            var flow = channel.Running($"Launching {profile} shell");
            var psi = new ProcessStartInfo
            {
                FileName = @"d:\tools\wt\wt.exe",
                CreateNoWindow = false,
                UseShellExecute = false,
                Arguments = $"nt --profile {profile} -d {cwd}",
                RedirectStandardError = false,
                RedirectStandardOutput = false,
                RedirectStandardInput = false,
            };
            var process = sys.process(psi);
            var result = process.Start();
            var token = ExecToken.Empty;
            if(!result)
                channel.Error("Process creation failed");
            else
                token = channel.Ran(flow, $"Launched {profile} shell: {process.Id}");
            return token;
        }

        [Op]
        public static Task<ExecToken> run(IWfChannel channel, FilePath tool, CmdArgs args, ToolCmdSpec? spec = null)
        {
            var ctx = spec ?? ToolCmdSpec.Default;
            var psi = new ProcessStartInfo
            {
                FileName = tool.Format(),
                Arguments = Cmd.join(args),
                CreateNoWindow = true,
                WorkingDirectory = ctx.WorkingDir.Format(),
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = false
            };

            iter(ctx.Vars, v => psi.Environment.Add(v.Name, v.Value));
            
            var token = ExecToken.Empty;
            ExecToken Run()
            {
                try
                {
                    using var process = sys.process(psi);
                    var channeled = channel.ChannelProcess(process, ctx);
                    token = channeled.Run(channel.Running($"Executing '{tool}' with arguments '{args}"));
                    term.cmd();
                }
                catch(Exception e)
                {
                    channel.Error(e);
                }
                return token;

            }   
            return sys.start(Run);
        }    

        public static Task<ExecToken> run(IWfChannel channel, CmdArgs args, ToolCmdSpec? spec = null)
            => run(channel, FS.path(args[0]), args.Skip(1), spec);

        public static Task<ExecToken> redirect(IWfChannel channel, FilePath tool, CmdArgs args, FilePath status, Action<string> receiver = null)
        {
            FilePath alt = (status + FS.ext("alt"));

            ExecToken Run()
            {
                var c1 = default(StreamWriter);
                var c0 = default(StreamWriter);
                var token = ExecToken.Empty;
                
                try
                {
                    void OnStatus(string msg)
                    {
                        if(c0 == null)
                            c0 = status.Utf8Writer(false);
                        c0.WriteLine(msg);
                        receiver?.Invoke(msg);
                    }

                    void OnError(string msg)
                    {
                        if(c1 == null)
                            c1 = alt.Utf8Writer(true);                     

                        channel.Row(msg, FlairKind.StatusData);
                        c1.WriteLine(msg);
                    }


                    var running = channel.Running(args);
                    token = channel.Ran(running, run(spec(tool, args), OnStatus, OnError));
                }
                catch(Exception e)
                {
                    channel.Error(e.Message);
                }
                finally
                {
                    c0?.Dispose();
                    c1?.Dispose();
                }
                return token;

            }

            return sys.start(Run);
        }

        public static Task<ExecToken> redirect(IWfChannel channel, CmdArgs args)
        {
            ExecToken Run()
            {
                var c0Name=$"{Environment.ProcessId}.channels.0";
                var c0Path = AppDb.Service.AppData().Path(c0Name, FileKind.Log);
                var h0 = $"# {args} -> {c0Path}";

                var c1Name = $"{Environment.ProcessId}.channels.1";
                var c1Path = AppDb.Service.AppData().Path(c1Name, FileKind.Log);
                var h1 = $"# {args} -> {c1Path}";
                
                using var c0 = c0Path.Utf8Writer(true);
                c0.WriteLine($"# {c0Name}");
                c0.WriteLine(h0);

                var c1 = default(StreamWriter);

                void Channel0(string msg)
                {
                    channel.Row(msg, FlairKind.Data);
                    c0.WriteLine(msg);
                }

                void Channel1(string msg)
                {
                    if(c1 == null)
                    {
                        c1 = c1Path.Utf8Writer(true);
                        c1.WriteLine($"# {c1Name}");
                        c1.WriteLine(h1);
                    }

                    channel.Row(msg, FlairKind.StatusData);
                    c1.WriteLine(msg);
                }

                var io = new SysIO(Channel0, Channel1);
                var running = channel.Running($"{args} -> ({c0Path}, {c1Path})");
                var status = run(io, args, spec());
                var token = channel.Ran(running, status);
                c1?.Dispose();
                return token;
            }

            return sys.start(Run);
        }

        static ExecStatus run(ToolCmdSpec context, Action<string> status, Action<string> error)
        {
            var psi = new ProcessStartInfo(context.ToolPath.Format(), context.Args.Format())
            {
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                ErrorDialog = false,
                CreateNoWindow = true,
                RedirectStandardInput = false,
                WorkingDirectory = context.WorkingDir.Format(PathSeparator.BS)
            };

            iter(context.Vars, v => psi.Environment.Add(v.Name, v.Value));

            void OnStatus(object sender, DataReceivedEventArgs e)
            {
                if(sys.nonempty(e.Data))
                    status(e.Data);
            }
    
            void OnError(object sender, DataReceivedEventArgs e)
            {
                if(sys.nonempty(e.Data))
                    error(e.Data);
            }

            var flow = default(ExecStatus);
            try
            {                
                using var process = sys.process(psi);
                process.OutputDataReceived += OnStatus;
                process.ErrorDataReceived += OnError;
                process.Start();
                context.ProcessStart(process);
                flow.StartTime = sys.now();
                flow.Id = process.Id;
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                flow.HasExited = true;
                flow.ExitTime = sys.now();
                flow.Duration = flow.ExitTime - flow.StartTime;
                flow.ExitCode = process.ExitCode;
                context.ProcessExit(process.ExitCode);
            }
            catch(Exception e)
            {
                error(e.ToString());
            }
            return flow;
        }

        static ExecStatus run(ISysIO io, CmdArgs args, ToolCmdSpec context)
        {
            var values = args.Values();
            Demand.gt(values.Count, 0u);
            var name = values.First;
            var path = FS.path(values.First);            
            var psi = new ProcessStartInfo(path.Format(), args.Skip(1).Format())
            {
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                ErrorDialog = false,
                CreateNoWindow = true,
                RedirectStandardInput = false,
                WorkingDirectory = context.WorkingDir.Format(PathSeparator.BS)
            };

            iter(context.Vars, v => psi.Environment.Add(v.Name, v.Value));

            void OnStatus(object sender, DataReceivedEventArgs e)
            {
                if(sys.nonempty(e.Data))
                    io.Status(e.Data);
            }
    
            void OnError(object sender, DataReceivedEventArgs e)
            {
                if(sys.nonempty(e.Data))
                    io.Error(e.Data);
            }

            var flow = default(ExecStatus);
            try
            {                
                using var process = sys.process(psi);
                process.OutputDataReceived += OnStatus;
                process.ErrorDataReceived += OnError;
                process.Start();
                context.ProcessStart(process);
                flow.StartTime = sys.now();
                flow.Id = process.Id;
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                flow.HasExited = true;
                flow.ExitTime = sys.now();
                flow.Duration = flow.ExitTime - flow.StartTime;
                flow.ExitCode = process.ExitCode;
                context.ProcessExit(process.ExitCode);
            }
            catch(Exception e)
            {
                io.Error(e.ToString());
            }
            return flow;
        }
         
        public static ReadOnlySeq<IToolExecutor> executors(params Assembly[] src)
            => src.Types().Tagged<CmdExecutorAttribute>().Concrete().Map(x => (IToolExecutor)Activator.CreateInstance(x));


        [MethodImpl(Inline), Op]
        public static ToolFlagSpec flag(string name, string desc)
            => new ToolFlagSpec(name, desc);

        public static ReadOnlySeq<ToolFlagSpec> flags(FilePath src)
        {
            var k = z16;
            var dst = list<ToolFlagSpec>();
            using var reader = src.AsciLineReader();
            while(reader.Next(out var line))
            {
                var content = line.Codes;
                var i = SQ.index(content, AsciCode.Colon);
                if(i == NotFound)
                    i = SQ.index(content, AsciCode.Eq);
                if(i == NotFound)
                    i = SQ.index(content, AsciCode.FS);
                
                if(i == NotFound)
                    continue;


                var name = text.trim(AsciSymbols.format(SQ.left(content,i)));
                var desc = text.trim(AsciSymbols.format(SQ.right(content,i)));
                dst.Add(flag(name, desc));
            }
            return dst.ToArray();
        }

        [MethodImpl(Inline), Op]
        public static ToolScript script(FilePath src, CmdVars vars)
            => new ToolScript(src, vars);

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(FilePath tool, params string[] src)
            => new ToolCmdLine(tool, src);

        // [Op, Closures(UInt64k)]
        // public static Tool tool(CmdArgs args, byte index = 0)
        //     => new (CmdArgs.arg(args,index).Value);


        public T Tool<T>()
            where T : IToolService, new()
                => ToolServices.Service<T>(Wf);

        public FilePath ConfigScript(Tool tool)
            => Home(tool).ConfigScript(ApiAtomic.config, FileKind.Cmd);

        public FilePath Script(Tool tool, string name, FileKind kind)
            => Home(tool).Script(name, kind);

        public IDbArchive Docs(Tool tool)
            => Home(tool).Docs();

        public IToolWs Home(Tool tool)
            => new ToolWs(tool, ToolBase.Sources(tool.Name).Root);

        public IDbArchive ToolBase
            => AppDb.Toolbase();

        public FilePath ScriptPath(Tool tool, string name, FileKind kind)
            => Home(tool).Script(name, kind);

        public SettingLookup LoadCfg(Tool tool)
            => Z0.Settings.lookup(Home(tool).Script("tools", FileKind.Cfg).ReadNumberedLines(), Chars.Eq);

        public ConstLookup<Actor,ToolProfile> InferProfiles(FolderPath src)
        {
            var @base = FolderPath.Empty;
            var members = Index<Actor>.Empty;
            var config = src + FS.file("toolset", FS.Settings);
            if(!config.Exists)
            {
                Channel.Error(FS.missing(config));
                return dict<Actor,ToolProfile>();
            }

            using var reader = config.Utf8LineReader();
            while(reader.Next(out var line))
            {
                ref readonly var content = ref line.Content;
                var i = text.index(content, Chars.Colon);
                if(i >=0)
                {
                    var name = text.left(content,i);
                    var value = text.right(content,i);
                    if(name == "InstallBase")
                    {
                        var root = FS.dir(value);
                        if(root.Exists)
                            @base = root;
                    }
                }
            }

            return LoadProfileLookup(src);
        }

        public FilePath ToolPath(FolderPath root, Tool tool)
        {
            if(LoadProfileLookup(root).Find(tool, out var profile))
                return profile.Executable;
            else
                return FilePath.Empty;
        }

        public Index<string> LoadDocs(string tool)
        {
            var src = Docs(tool);
            var dst = bag<string>();
            iter(src.Files(), file => dst.Add(file.ReadText()));
            return dst.ToIndex();
        }

        public ConstLookup<Actor,FilePath> CalcHelpPaths(FolderPath src)
        {
            var dst = new Lookup<Actor,FilePath>();
            var profiles = LoadProfileLookup(src).Values;
            var count = profiles.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var profile = ref skip(profiles,i);
                if(profile.HelpCmd.IsEmpty)
                    continue;

                dst.Include(profile.ToolName, src + FS.folder("help") + FS.file(profile.ToolName, FS.Help));
            }

            return dst.Seal();
        }

        public Index<ToolCmdLine> BuildHelpCommands(IToolWs ws)
        {
            var profiles = LoadProfileLookup(ws.Root.Root).Values;
            var count = profiles.Length;
            var dst = list<ToolCmdLine>();
            for(var i=0; i<count; i++)
            {
                ref readonly var profile = ref skip(profiles,i);
                if(profile.HelpCmd.IsEmpty)
                    continue;
                dst.Add(Tooling.cmdline(FS.path(profile.ToolName), string.Format("{0} {1}", profile.Executable.Format(PathSeparator.BS), profile.HelpCmd)));
            }
            dst.Sort();
            return dst.ToArray();
        }

        public Index<ToolHelpDoc> EmitHelp(IToolWs ws)
        {
            var result = Outcome.Success;
            var paths = CalcHelpPaths(ws.Root.Root);
            var commands = BuildHelpCommands(ws);
            var count = commands.Length;
            var docs = list<ToolHelpDoc>();
            for(var i=0; i<count; i++)
            {
                ref readonly var cmd = ref commands[i];
                var tool = cmd.Tool;
                //result = OmniScript.Run(cmd, CmdVars.Empty, out var response);
                if(result.Fail)
                {
                    Channel.Error(result.Message);
                    continue;
                }

                Channel.Babble(string.Format("Executed '{0}'", cmd.Format()));

            }

            return docs.ToArray();
        }
 
        public ConstLookup<Actor,ToolProfile> LoadProfileLookup(FolderPath dir)
        {
            var running = Channel.Running(string.Format("Loading tool profiles from {0}", dir));
            var sources = dir.Match("tool.profiles", FS.Csv, true);
            var dst = new Lookup<Actor,ToolProfile>();
            iter(sources, src => ToolSettings.profiles(src,dst,Channel));
            var lookup = dst.Seal();
            Channel.Ran(running, string.Format("Collected {0} profile definitions", lookup.EntryCount));
            return lookup;
        }
    }
}