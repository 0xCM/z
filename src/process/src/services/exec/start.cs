//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial record class ProcExec
    {        
        [Op]
        public static ProcessAdapter start(ProcessStartSpec spec)
            => Process.Start(spec);

        public static Task<ExecToken> start(CmdArgs args, IWfChannel channel)
        {
            void status(in string src)
            {
                channel.Row(src);
            }

            void error(in string src)
            {
                channel.Error(src);
            }

            ExecToken run()
            {
                var ran = ExecToken.Empty;
                var data = text.emitter();
                iter(args.Values(), arg => data.Append($" {arg}"));
                var command = cmd(data.Emit());
                var running = channel.Running($"Executing '{command}'");
                try
                {
                    var process = CmdProcess.create(command, status, error);
                    process.Wait();
                    var lines =  Lines.read(process.Output);
                    iter(lines, line => channel.Row(line));
                    ran = channel.Ran(running, $"Executed {text.quote(command)}");
                }
                catch(Exception e)
                {
                    ran = channel.Ran(running,$"error:cmd='{command}, description='{e}'");
                }

                term.write("cmd> ", (FlairKind)ConsoleColor.Cyan);
                return ran;
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
                => term.emit(Events.error(typeof(ProcExec), src, Events.originate(typeof(CmdScript))));

            static void OnStatus(in string src)
                => term.emit(Events.data(src,FlairKind.Babble));

            FilePath run()
            {
                var log = AppDb.Logs("procs").Path(sys.timestamp().Format(),FileKind.Log);
                using var writer = log.AsciWriter();
                try
                {
                    term.print();
                    term.emit(Events.running(typeof(Cmd), $"'{cmd}"));
                    var process = CmdProcess.create(cmd, OnStatus, OnError);
                    var outcome = process.Wait();
                    var lines =  Lines.read(process.Output);
                    iter(lines, line => writer.WriteLine(line));
                    term.emit(Events.ran(typeof(Cmd), $"Executed '{cmd}'"));
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

        public static Task<ExecToken> start(CmdLine cmd, IWfChannel channel)
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
    }
}