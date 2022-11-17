//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ProcessControl
    {       
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
                    executing = new (command, process.Process);
                    ProcessState.enlist(executing);
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
                
                ProcessState.remove(new (executing,ts,token));
                term.cmd();
                return token;
            }
            return sys.start(run);
        }

        public static Task<ExecToken> start(IWfChannel channel, CmdLine cmd, CmdVars vars, Action<TextLine> receiver)
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

                term.cmd();
                return ran;

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

                term.cmd();
                return ran;
            }
            return sys.start(run);
        }
    }
}