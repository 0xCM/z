//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class Tooling : WfAppCmd<Tooling>
    {
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

        [Op]
        public static Task<ExecToken> start(IWfChannel channel, FilePath tool, CmdArgs args, ToolCmdSpec? spec = null)
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
                    token = channeled.Run(channel.Running($"Executing '{tool}' with arguments '{args}'"));
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

        public static Task<ExecToken> start(IWfChannel channel, CmdArgs args, ToolCmdSpec? spec = null)
            => start(channel, FS.path(args[0]), args.Skip(1), spec);

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

        
        [Op]
        public static CmdLine pwsh(string spec)
            => $"pwsh.exe {spec}";

        public static CmdLine pwsh(FilePath src, string args)
            => string.Format("pwsh.exe {0} {1}", src.Format(PathSeparator.BS), args);

        public static CmdLine pwsh(FilePath src)
            => string.Format("pwsh.exe {0}", src.Format(PathSeparator.BS));        

        public static CmdLine cmdline(params CmdArg[] args)
            => new CmdLine(args);

        public static CmdLine cmdline(params object[] args)
            => new CmdLine(args.Select(x => x?.ToString() ?? EmptyString));

        [Op]
        public static CmdLine cmd<T>(T src)
            => $"cmd.exe /c {src}";

        [Op]
        public static CmdLine cmd(string spec)
            => string.Format("cmd.exe /c {0}", spec);

        [Op]
        public static CmdLine cmd(FilePath src, CmdArgs args)
            => string.Format("cmd.exe /c {0} {1}", args.Format());

        [Op]
        public static CmdLine cmd(FilePath src, string args)
            => string.Format("cmd.exe /c {0} {1}", src.Format(PathSeparator.BS), args);

        [Op]
        public static CmdLine cmd(FilePath src)
            => string.Format("cmd.exe /c {0}", src.Format(PathSeparator.BS));

        [Op]
        public static CmdLine cmd(FilePath path, CmdKind kind)
        {
            return kind switch{
                CmdKind.Cmd => cmd(path),
                CmdKind.Tool => cmd(path),
                CmdKind.Pwsh => pwsh(path),
                _ => Z0.CmdLine.Empty
            };
        }

        [Op]
        public static CmdLine cmd(FilePath path, CmdKind kind, string args)
        {
            return kind switch{
                CmdKind.Cmd => cmd(path, args),
                CmdKind.Tool => cmd(path, args),
                CmdKind.Pwsh => pwsh(path, args),
                _ => Z0.CmdLine.Empty
            };
        }

        public static CmdLine cmdline(FilePath src)
        {
            if(src.Is(FileKind.Cmd))
                return cmd(src);
            else if(src.Is(FileKind.Ps1))
                return pwsh(src);
            else
                return sys.@throw<CmdLine>();
        }

        [CmdOp("tool/docs")]
        void ToolDocs(CmdArgs args)
            => iter(LoadDocs(arg(args,0).Value), doc => Channel.Write(doc));
        
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
         
        // public static Task<ExecToken> shell(IWfChannel channel, CmdArgs args)
        // {
        //     ExecToken Run()
        //     {
        //         var profile = args[0].Value;
        //         var cwd = args.Count > 1 ? FS.dir(args[1]) : Env.cd();
        //         return shell(channel, profile, cwd);  
        //     }
        //     return sys.start(Run);
        // }

        // [Op]
        // public static ExecToken shell(IWfChannel channel, string profile, FolderPath cwd)
        // {
        //     var flow = channel.Running($"Launching {profile} shell");
        //     var psi = new ProcessStartInfo
        //     {
        //         FileName = @"d:\tools\wt\wt.exe",
        //         CreateNoWindow = false,
        //         UseShellExecute = false,
        //         Arguments = $"nt --profile {profile} -d {cwd}",
        //         RedirectStandardError = false,
        //         RedirectStandardOutput = false,
        //         RedirectStandardInput = false,
        //     };
        //     var process = sys.process(psi);
        //     var result = process.Start();
        //     var token = ExecToken.Empty;
        //     if(!result)
        //         channel.Error("Process creation failed");
        //     else
        //         token = channel.Ran(flow, $"Launched {profile} shell: {process.Id}");
        //     return token;
        // }

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(FilePath tool, params string[] src)
            => new ToolCmdLine(tool, src);

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

        public FilePath ToolPath(FolderPath root, Tool tool)
            => root + FS.file(tool.Name, FileKind.Exe);

        public Index<string> LoadDocs(string tool)
        {
            var src = Docs(tool);
            var dst = bag<string>();
            iter(src.Files(), file => dst.Add(file.ReadText()));
            return dst.ToIndex();
        }
    }


    partial class XSvc
    {
        partial class ServiceCache
        {
            public Tooling Tooling(IWfRuntime wf) 
                => Service<Tooling>(wf);
        }

        public static Tooling Tooling(this IWfRuntime wf)
            => Services.Tooling(wf);
    }
}