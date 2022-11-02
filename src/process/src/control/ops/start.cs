//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ProcessControl
    {       
        [Op]
        public static Task<ExecToken> start(IWfChannel channel, FilePath path, CmdArgs args, CmdContext? context = null)
        {
            var info = new ProcessStartInfo
            {
                FileName = path.Format(),
                Arguments = Cmd.join(args),
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true
            };

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

            ExecToken Run()
            {
                var token = ExecToken.Empty;
                var running = channel.Running($"{info.FileName} ${info.Arguments}");
                var process = new Process {StartInfo = info};
                var ctx = context ?? CmdContext.Default;
                if (!ctx .WorkingDir.IsNonEmpty)
                    process.StartInfo.WorkingDirectory = context.WorkingDir.Name;
                iter(ctx.EnvVars, v => process.StartInfo.Environment.Add(v.Name, v.Value));
                process.OutputDataReceived += (s,d) => OnStatus(d);
                process.ErrorDataReceived += (s,d) => OnError(d);
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                token = channel.Ran(running);
                term.cmd();
                return token;

            }   
            return sys.start(Run);
        }

        [Op]
        public static ProcessAdapter start(ProcessStartSpec spec)
            => Process.Start(spec);

        public static Task<ExecToken> start(IWfChannel channel, CmdArgs args)
        {
            void status(in string src)
                => channel.Row(src);

            void error(in string src)
                => channel.Error(src);

            ExecToken run()
            {
                var token = ExecToken.Empty;
                var data = text.emitter();
                iter(args.Values(), arg => data.Append($" {arg}"));
                var command = cmd(data.Emit());
                var flow = channel.Running($"Executing '{command}'");
                var executing = ExecutingProcess.Empty;
                var ts = Timestamp.Zero;
                try
                {
                    var process = CmdProcess.create(command, status, error);
                    executing = new (args, command, process.Process);
                    enlist(executing);
                    process.Wait();
                    var lines =  Lines.read(process.Output);
                    iter(lines, line => channel.Row(line));
                    ts = now();
                    token = channel.Ran(flow, $"Executed {text.quote(command)}");
                }
                catch(Exception e)
                {
                    ts = now();
                    token = channel.Ran(flow,$"error:cmd='{command}, description='{e}'");
                }
                
                remove(new (executing,ts,token));
                term.cmd();
                return token;
            }
            return sys.start(run);
        }

        public static Task<ExecToken> start(CmdLine cmd, CmdVars vars, Action<TextLine> receiver, WfEmit channel)
        {
            ExecToken run()
            {
                var ran = ExecToken.Empty;
                var running = channel.Running($"Executing '{cmd}'");
                try
                {
                    var process = CmdProcess.create(cmd, vars);
                    process.Wait();
                    iter(Lines.read(process.Output), receiver);
                    ran = channel.Ran(running, $"Executed {text.quote(cmd)}");
                }
                catch(Exception e)
                {
                    ran = channel.Ran(running,$"error:cmd='{cmd}, description='{e}'");
                }

                term.write("cmd> ", (FlairKind)ConsoleColor.Cyan);
                return ran;

            }
            return sys.start(run);
        }

        public static Task<FilePath> start(CmdLine cmd)
        {
            static void OnError(in string src)
                => term.emit(Events.error(typeof(ProcessControl), src, Events.originate(typeof(CmdScript))));

            static void OnStatus(in string src)
                => term.emit(Events.data(src,FlairKind.Babble));

            FilePath run()
            {
                var log = AppDb.Logs("procs").Path(sys.timestamp().Format(),FileKind.Log);
                using var writer = log.AsciWriter();
                try
                {
                    term.print();
                    term.emit(Events.running(typeof(ProcessControl), $"'{cmd}"));
                    var process = CmdProcess.create(cmd, OnStatus, OnError);
                    var outcome = process.Wait();
                    var lines =  Lines.read(process.Output);
                    iter(lines, line => writer.WriteLine(line));
                    term.emit(Events.ran(typeof(ProcessControl), $"Executed '{cmd}'"));
                }
                catch(Exception e)
                {
                    writer.WriteLine(e.ToString());
                }
                term.write("cmd> ", (FlairKind)ConsoleColor.Cyan);
                return log;
            }
            return sys.start(run);
        }

        public static Task<ExecToken> start(IWfChannel channel, CmdLine cmd)
        {
            void OnError(in string src)
                => channel.Error(src);

            void OnStatus(in string src)
                => channel.Babble(src);

            ExecToken run()
            {
                var running = channel.Running($"Executing '{cmd}'");
                var log = ProcessLogs.status(timestamp(), cmd.Format());
                var ran = ExecToken.Empty;
                using var logger = log.AsciWriter();
                try
                {
                    var process = CmdProcess.create(cmd, OnStatus, OnError);
                    var outcome = process.Wait();
                    var lines =  Lines.read(process.Output);
                    iter(lines, line => logger.WriteLine(line));
                    ran = channel.Ran(running, $"Executed {text.quote(cmd)}");
                }
                catch(Exception e)
                {
                    logger.WriteLine(e.ToString());
                    ran = channel.Ran(running,$"error:cmd='{cmd}, description='{e}'");
                }

                term.write("cmd> ", (FlairKind)ConsoleColor.Cyan);
                return ran;
            }
            return sys.start(run);
        }

        public static Task<ExecToken> start(IWfChannel channel, ISysIO io, CmdArgs spec, FolderPath? wd = null)
        {
            ExecToken go()
            {
                var running = channel.Running(spec);
                var result = run(io,spec,wd);
                return channel.Ran(running);
            }

            return sys.start(go);
        }
    }
}