//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ProcessLauncher
    {        
        public static CmdContext context(FolderPath? work = null, params EnvVar[] vars)
            => new (work ?? Env.cd(), vars);

        public static CmdContext context(FolderPath work, params EnvVar[] vars)
            => new(work, vars);

        public static CmdContext context(FolderPath work, EnvVars vars, Action<Process> created)
            => new(work, vars, created);

        public static CmdContext context()
            => new(Env.cd(), EnvVars.Empty);

        public static Task<ExecToken> launch(IWfChannel channel, ISysIO io, CmdArgs spec, FolderPath? wd = null)
        {
            ExecToken go()
            {
                var running = channel.Running(spec);
                var result = run(io, spec, context(wd));
                return channel.Ran(running);
            }

            return sys.start(go);
        }

        [Op]
        public static Task<ExecToken> launch(IWfChannel channel, FilePath path, CmdArgs args, CmdContext? context = null)
        {
            var ctx = context ?? CmdContext.Default;
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
            
            var ts = Timestamp.Zero;
            var token = ExecToken.Empty;
            var status = ExecutingProcess.Empty;

            ExecToken Run()
            {
                try
                {
                    using var process = sys.process(psi);
                    ctx.ProcessCreated(process);
                    var channeled = channel.ChannelProcess(process,ctx);
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

        public static Task<ExecToken> launch(IWfChannel channel, CmdArgs args, CmdContext? context = null)
            => launch(channel, FS.path(args[0]), args.Skip(1), context);

        public static Task<ExecToken> launch(IWfChannel channel, CmdLine cmd, CmdContext? context = null)
        {
            var psi = new ProcessStartInfo
            {
                FileName = cmd.ExePath.Format(),
                Arguments = cmd.Args.Format(),
                CreateNoWindow = true,
                WorkingDirectory = context?.WorkingDir.Format() ?? Environment.CurrentDirectory,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = false
            };
            
            var ctx = context ?? CmdContext.Default;
            if(context != null)
                iter(context.Vars, v => psi.Environment.Add(v.Name, v.Value));

            var token = ExecToken.Empty;

            ExecToken Run()
            {
                try
                {
                    using var process = sys.process(psi);
                    ctx.ProcessCreated(process);
                    var channeled = channel.ChannelProcess(process, ctx);
                    token = channeled.Run();                    
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

        public static Task<ExecToken> redirect(IWfChannel channel, CmdArgs args, FilePath dst)
        {
            ExecToken Run()
            {
                var counter = 0u;
                var emitting = channel.EmittingFile(dst);
                using var writer = dst.Utf8Writer(true);
                run(new SysIO(msg => { 
                    writer.WriteLine(msg);
                    counter++;
                }, 
                    msg => channel.Error(msg), 
                    () => EmptyString), 
                    args, 
                    context(dst.FolderPath)
                );

                return channel.EmittedFile(emitting, counter);
            }
            return sys.start(Run);
        }

        [Op]
        public static Task<ExecToken> redirect(IWfChannel channel, FilePath path, CmdArgs args, CmdVars vars, FolderPath work, Receiver<string> status, Receiver<string> error)
            => launch(channel, path, args, context(work, vars.Map(v => new EnvVar(v.Name, v.Value))));

        //public static ExecToken run()
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
                var running = channel.Running($"{args} -> ({c0Path}, {c1Path})");
                var status = run(io, args, context());
                return channel.Ran(running, status);
            }

            return sys.start(Run);
        }

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

        public static ExecStatus status(ExecutingProcess src)
        {
            var dst = ExecStatus.Empty;
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

        static ExecStatus run(ISysIO io, CmdArgs spec, CmdContext context)
        {
            var values = spec.Values();
            Demand.gt(values.Count, 0u);
            var name = values.First;
            //var args = text.join(Chars.Space,values.ToSpan().Slice(1).ToArray());
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

            var result = default(ExecStatus);
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
                process.WaitForExit();
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
    }
}