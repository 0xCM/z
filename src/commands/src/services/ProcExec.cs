//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ProcExec
    {        
        public static ToolContext context(FolderPath? work = null, params EnvVar[] vars)
            => new (work ?? Env.cd(), vars);

        public static ToolContext context(FolderPath work, params EnvVar[] vars)
            => new(work, vars);

        public static ToolContext context(FolderPath work, EnvVars vars, Action<Process> created)
            => new(work, vars, created);

        public static ToolContext context(FolderPath work, EnvVars vars, Action<Process> created, Action<int> exit)
            => new(work, vars, created, exit);

        public static ToolContext context()
            => new(Env.cd(), EnvVars.Empty);

        [Op]
        public static Task<ExecToken> launch(IWfChannel channel, FilePath path, CmdArgs args, ToolContext? context = null)
        {
            var ctx = context ?? ToolContext.Default;
            var psi = new ProcessStartInfo
            {
                FileName = path.Format(),
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
                    token = channeled.Run(channel.Running($"Executing '{path}' with arguments '{args}"));
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

        public static Task<ExecToken> launch(IWfChannel channel, CmdArgs args, ToolContext? context = null)
            => launch(channel, FS.path(args[0]), args.Skip(1), context);

        public static Task<ExecToken> redirect(IWfChannel channel, CmdArgs args, FilePath status, FilePath? error = null)
        {
            FilePath _error = error == null ? (status + FS.ext("errors")) : error.Value;
            ExecToken Run()
            {
                var c0Name=$"{Environment.ProcessId}.channels.0";
                var h0 = $"# {args} -> {status}";

                var c1Name = $"{Environment.ProcessId}.channels.1";
                var h1 = $"# {args} -> {_error}";
                
                using var c0 = status.Utf8Writer(true);
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
                        c1 = _error.Utf8Writer(true);
                        c1.WriteLine($"# {c1Name}");
                        c1.WriteLine(h1);
                    }

                    channel.Row(msg, FlairKind.StatusData);
                    c1.WriteLine(msg);
                }

                var io = new SysIO(Channel0, Channel1);
                var running = channel.Running($"{args} -> ({status}, {_error})");

                var token = channel.Ran(running, run(io, args, context()));
                c1?.Dispose();
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
                var status = run(io, args, context());
                var token = channel.Ran(running, status);
                c1?.Dispose();
                return token;
            }

            return sys.start(Run);
        }

        static ExecStatus run(ISysIO io, CmdArgs spec, ToolContext context)
        {
            var values = spec.Values();
            Demand.gt(values.Count, 0u);
            var name = values.First;
            var path = FS.path(values.First);            
            var psi = new ProcessStartInfo(path.Format(), spec.Skip(1).Format())
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
    }
}