//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class CmdRunner
    {
        [Op]
        public static void parse(ReadOnlySpan<TextLine> src, out ReadOnlySpan<CmdFlow> dst)
            => dst = flows(src);

        static ReadOnlySpan<CmdFlow> flows(ReadOnlySpan<TextLine> src)
        {
            var count = src.Length;
            var counter = 0u;
            var dst = span<CmdFlow>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(src,i);
                if(line.IsEmpty)
                    continue;

                var content = line.Content;
                var j = text.index(content, Chars.Colon);
                if(j >= 0)
                {
                    Tool tool = text.left(content, j);
                    var flow = Fenced.unfence(text.right(content,j), Fenced.Bracketed);

                    j = text.index(flow, "--");
                    if(j == NotFound)
                        j = text.index(flow, "->");

                    if(j>=0)
                    {
                        var a = text.left(flow,j).Trim();
                        var b = text.right(flow,j+2).Trim();
                        if(nonempty(a) && nonempty(b))
                            seek(dst,counter++) = new CmdFlow(tool, FS.path(a), FS.path(b));
                    }
                }
            }

            return slice(dst,0,counter);
        }

        public static ReadOnlySpan<CmdResponse> response(ReadOnlySpan<TextLine> src)
        {
            var count = src.Length;
            var parsed = list<CmdResponse>();
            for(var i=0; i<count; i++)
            {
                if(parse(skip(src,i).Content, out var response))
                    parsed.Add(response);
            }
            return parsed.ViewDeposited();
        }

        public static bool parse(string src, out CmdResponse dst)
        {
            dst = CmdResponse.Empty;
            var i = text.index(src, Chars.Colon);
            if(i > 0)
            {
                var left = text.left(src, i);
                var right = text.right(src,i);
                dst = (left,right);
                return true;
            }
            else
                return false;
        }

        public static Task<ExecToken> redirect(IWfChannel channel, CmdArgs args)
        {
            ExecToken Run()
            {
                var c0Name=$"{Environment.ProcessId}.channels.0";
                var c0Path = AppDb.Service.AppData().Path(c0Name, FileKind.Log);
                var h0 = $"# {args} -> ${c0Path}";

                var c1Name = $"{Environment.ProcessId}.channels.1";
                var c1Path = AppDb.Service.AppData().Path(c1Name, FileKind.Log);
                var h1 = $"# {args} -> ${c1Path}";
                
                using var c0 = c0Path.Utf8Writer(true);
                c0.WriteLine($"# {c0Name}");
                c0.WriteLine(h0);

                using var c1 = c1Path.Utf8Writer(true);
                c1.WriteLine($"# {c1Name}");
                c1.WriteLine(h1);

                void Channel0(string msg)
                {
                    channel.Row(msg, FlairKind.Data);
                    c0.WriteLine(msg);
                }

                void Channel1(string msg)
                {
                    channel.Row(msg, FlairKind.StatusData);
                    c1.WriteLine(msg);
                }

                var io = new SysIO(Channel0, Channel1);
                var running = channel.Running($"{args} -> ({c0Path}, ${c1Path})");
                run(io, args);
                return channel.Ran(running, c0);
            }

            return sys.start(Run);
        }

        public static Task<ExecToken> start(IWfChannel channel, ISysIO io, CmdArgs spec, FolderPath? wd = null)
        {
            ExecToken go()
            {
                var running = channel.Running(spec);
                var result = run(io, spec, wd);
                return channel.Ran(running);
            }

            return sys.start(go);
        }

        public static void run(IWfChannel channel, string tool, string args, FilePath dst)
        {
            var emitting = channel.EmittingFile(dst);
            using var status = dst.Utf8Writer(true);
            var counter = 0u;

            void OnStatus(string msg)
            {
                status.WriteLine(msg);
                counter++;
            }

            void OnError(string msg)
                => channel.Error(msg);

            string Input()
                => EmptyString;
            
            run(new SysIO(OnStatus, OnError, Input), Cmd.args(tool,args), dst.FolderPath);
            channel.EmittedFile(emitting, counter);
        }

        public static CmdExecStatus run(ISysIO io, CmdArgs spec, FolderPath? wd = null)
        {
            var values = spec.Values();
            Demand.gt(values.Count, 0u);
            var name = values.First;
            var args = values.ToSpan().Slice(1).ToArray();
            var psi = new ProcessStartInfo(values.First, text.join(Chars.Space,args))
            {
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                ErrorDialog = false,
                CreateNoWindow = true,
                RedirectStandardInput = false,
                WorkingDirectory = wd != null ? wd.Value.Format() : EmptyString
            };

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

            var result = default(CmdExecStatus);
            try
            {                
                using var process = sys.process(psi);
                process.OutputDataReceived += OnStatus;
                process.ErrorDataReceived += OnError;
                process.Start();
                result.StartTime = sys.now();
                result.Id = process.Id;
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExitAsync().Wait();                
                result.HasExited = true;
                result.ExitTime = sys.now();
                result.Duration = result.ExitTime - result.StartTime;
                result.ExitCode = process.ExitCode;
            }
            catch(Exception e)
            {
                io.Error(e.ToString());
            }
            return result;
        }


        public static CmdExecStatus status(ExecutingProcess src)
        {
            var dst = CmdExecStatus.Empty;
            dst.Id = src.Id;
            dst.StartTime = src.Started;
            dst.HasExited = src.Finished;
            if(src.Finished)
            {
                dst.ExitTime = src.Adapted.ExitTime;
                dst.Duration = dst.ExitTime - dst.StartTime;
                dst.ExitCode = src.Adapted.ExitCode;
            }
            return dst;
        }

        public static CmdScript script(string name, CmdScriptExpr src)
            => new CmdScript(name, src);

        public static CmdLine cmdline(FilePath src)
        {
            if(src.Is(FileKind.Cmd))
                return Cmd.cmd(src);
            else if(src.Is(FileKind.Ps1))
                return Cmd.pwsh(src);
            else
                return sys.@throw<CmdLine>();
        }

        public static CmdContext context(FolderPath work, params EnvVar[] vars)
            => new(work, vars);

        [Op]
        public static Outcome run(CmdLine cmd, CmdVars vars, FolderPath work, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> response)
        {
            response = sys.empty<TextLine>();
            var ctx = context(work,vars.Map(v => new EnvVar(v.Name, v.Value)));
            return true;
        }

        public static Task<ExecToken> start(IWfChannel channel, CmdArgs args, CmdContext? context = null)
            => start(channel, FS.path(args[0]), args.Skip(1), context);

        [Op]
        public static Task<ExecToken> start(IWfChannel channel, FilePath path, CmdArgs args, CmdContext? context = null)
        {
            void OnStatus(DataReceivedEventArgs e)
            {
                if(e != null && nonempty(e.Data))
                    channel.Row(e.Data);
            }

            void OnError(DataReceivedEventArgs e)
            {
                if(e != null && nonempty(e.Data))
                    channel.Error(e.Data);                
            }

            var info = new ProcessStartInfo
            {
                FileName = path.Format(),
                Arguments = Cmd.join(args),
                CreateNoWindow = true,
                WorkingDirectory = context?.WorkingDir.Format() ?? Environment.CurrentDirectory,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = false
            };

            var ctx = context ?? CmdContext.Default;
            iter(ctx.EnvVars, v => info.Environment.Add(v.VarName, v.VarValue));
            var cmdline = new CmdLine($"{info.FileName} {info.Arguments}");
            var ts = Timestamp.Zero;
            var token = ExecToken.Empty;
            var executing = ExecutingProcess.Empty;

            ExecToken Run()
            {
                try
                {
                    using var process = new Process {StartInfo = info};
                    process.OutputDataReceived += (s,d) => OnStatus(d);
                    process.ErrorDataReceived += (s,d) => OnError(d);
                    var flow = channel.Running(cmdline);
                    process.Start();
                    executing = new (cmdline, process);
                    ProcessState.enlist(executing);
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    channel.Babble($"Enlisted process {process.Id}");
                    process.WaitForExit();
                    ts = now();
                    token = channel.Ran(flow, $"Process {process.Id} finished");
                    term.cmd();
                    ProcessState.remove(new (executing, ts, token));
                }
                catch(Exception e)
                {
                    channel.Error(e);
                }
                return token;

            }   
            return sys.start(Run);
        }    
    }
}
