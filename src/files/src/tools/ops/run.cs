//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class CmdScripts
    {
        // static FilePath ErrorLog(Timestamp ts, string name)
        //     => AppDb.Logs("process").Path($"{name}.errors.{ts}", FileKind.Log);

        // static FilePath StatusLog(Timestamp ts, string name)
        //     => AppDb.Logs("process").Path($"{name}.{ts}", FileKind.Log);

        public static void run(CmdScript src)
        {
            var ts = timestamp();
            var logs = AppDb.Logs("process").Root;
            var errors = ProcessLogs.errors(logs, ts, src.Name.Format());
            using var status = ProcessLogs.status(logs, ts, src.Name.Format()).AsciWriter();
            
            void OnStatus(in string msg)
                => status.AppendLine(msg);

            void OnError(in string msg)
                => errors.Append(msg);

            try
            {
                var process = CmdLauncher.process(src.ToCmdLine(), OnStatus, OnError).Wait();
            }
            catch(Exception e)
            {
                errors.Append(e.ToString());
            }            
        }

        [Op]
        public static Outcome run(CmdLine cmd, CmdVars vars, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> response)
            => run(cmd, vars, FilePath.Empty, status,error, out response);

        [Op]
        public static Outcome run(CmdLine cmd, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> response)
            => run(cmd, CmdVars.Empty, FilePath.Empty, status,error, out response);

        public static ReadOnlySpan<TextLine> run(CmdLine cmd, CmdVars vars)
        {
            try
            {
                var process = CmdLauncher.process(cmd, vars);
                process.Wait();
                return Lines.read(process.Output);
            }
            catch(Exception e)
            {
                term.error(e);
                return default;
            }
        }

        public static ReadOnlySpan<TextLine> run(CmdLine cmd, Name script, CmdVars? vars)
        {
            using var writer = AppDb.Logs("scripts").Path(script,FileKind.Log).Writer();
            try
            {
                var process = vars != null ? CmdLauncher.process(cmd, vars) : CmdLauncher.start(cmd);
                process.Wait();
                var lines =  Lines.read(process.Output);
                iter(lines, line => writer.WriteLine(line));
                return lines;
            }
            catch(Exception e)
            {
                term.error(e);
                writer.WriteLine(e.ToString());
                return default;
            }
        }

        public static ReadOnlySpan<TextLine> run(CmdLine cmd, Action<Exception> onerror = null)
        {
            try
            {
                var process = CmdLauncher.start(cmd);
                process.Wait();
                return Lines.read(process.Output);
            }
            catch(Exception e)
            {
                if(onerror != null)
                    onerror(e);
                else
                    term.error(e);
                return default;
            }
        }

        [Op]
        public static Outcome run(CmdLine cmd, CmdVars vars, FilePath log, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> response)
        {
            response = sys.empty<TextLine>();
            var result = Outcome.Success;
            try
            {
                var proc = CmdLauncher.start(cmd, vars, status, error);
                var outcome = proc.Wait();
                var lines =  Lines.read(proc.Output);
                if(log.IsNonEmpty)
                {
                    using var writer = log.AsciWriter(true);
                    iter(lines, line => writer.WriteLine(line));
                }
                response = lines;
                return true;
            }
            catch(Exception e)
            {
                result = e;
            }
            return result;
        }
    }
}