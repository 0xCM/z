//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial record class ProcExec
    {
        public static CmdExecStatus run(CmdScript src)
        {
            var ts = timestamp();
            var errors = ProcessLogs.errors(ts, src.Name.Format());
            using var status = ProcessLogs.status(ts, src.Name.Format()).AsciWriter();
            
            void OnStatus(in string msg)
                => status.AppendLine(msg);

            void OnError(in string msg)
                => errors.Append(msg);

            var result = CmdExecStatus.Empty;
            try
            {
                var process = CmdProcess.create(src.ToCmdLine(), OnStatus, OnError);
                CmdProcess.status(process, ref result);
                result = process.Wait();
            }
            catch(Exception e)
            {
                errors.Append(e.ToString());
                result.ExitCode = -1;
                result.ExitTime = timestamp();
                result.Duration = result.ExitTime - result.StartTime;
            }       
            return result;     
        }

        public static ReadOnlySpan<TextLine> run(CmdLine cmd, CmdVars vars)
        {
            try
            {
                var process = CmdProcess.create(cmd, vars);
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
                var process = vars != null ? CmdProcess.create(cmd, vars) : CmdProcess.create(cmd);
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

        [Op]
        public static Outcome run(CmdLine cmd, CmdVars vars, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> response)
            => run(cmd, vars, FilePath.Empty, status,error, out response);

        [Op]
        public static Outcome run(CmdLine cmd, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> response)
            => run(cmd, CmdVars.Empty, FilePath.Empty, status,error, out response);


        public static ReadOnlySpan<TextLine> run(CmdLine cmd, Action<Exception> onerror = null)
        {
            try
            {
                var process = CmdProcess.create(cmd);
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
                var proc = CmdProcess.create(cmd, vars, status, error);
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