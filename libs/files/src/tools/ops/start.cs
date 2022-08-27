//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class CmdScripts
    {
        public static Task<FilePath> start(CmdArgs args)
        {
            var count = Demand.gt(args.Count,0u);
            var spec = text.emitter();
            for(var i=0; i<args.Count; i++)
            {
                if(i != 0)
                    spec.Append(Chars.Space);
                spec.Append(args[i].Value);
            }

            return start(Cmd.cmd(spec.Emit()));
        }

        public static Task start(ReadOnlySeq<CmdScript> src, bool pll)
            => sys.start(() => iter(src, run, pll));

        public static Task start(CmdLine cmd, CmdVars vars, Action<TextLine> receiver)
        {
            void run()
            {
                var result = Outcome.Success;
                try
                {
                    var process = Cmd.process(cmd, vars);
                    process.Wait();
                    iter(Lines.read(process.Output), receiver);
                }
                catch(Exception e)
                {
                    result = e;
                }

            }
            return sys.start(run);
        }

        public static Task<FilePath> start(CmdLine cmd)
        {
            static void OnError(in string src)
                => term.emit(Events.error(typeof(CmdScripts), src, Events.originate(typeof(CmdScript))));

            static void OnStatus(in string src)
                => term.emit(Events.data(src,FlairKind.Babble));

            FilePath run()
            {
                var log = AppDb.Logs("procs").Path(Algs.timestamp().Format(),FileKind.Log);
                using var writer = log.AsciWriter();
                try
                {
                    term.print();
                    term.emit(Events.running(typeof(Cmd), $"'{cmd}"));
                    var process = Cmd.process(cmd, OnStatus, OnError);
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
            return Algs.start(run);
        }

        public static Task<ExecToken> start(CmdLine cmd, WfEmit channel)
        {
            void OnError(in string src)
                => channel.Error(src);

            void OnStatus(in string src)
                => channel.Babble(src);

            ExecToken run()
            {
                var running = channel.Running($"Executing '{cmd}'");
                var log = AppDb.Logs("procs").Path(timestamp().Format(),FileKind.Log);
                var ran = ExecToken.Empty;
                using var logger = log.AsciWriter();
                try
                {
                    var process = Cmd.process(cmd, OnStatus, OnError);
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