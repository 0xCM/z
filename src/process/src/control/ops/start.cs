//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ProcessControl
    {       
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