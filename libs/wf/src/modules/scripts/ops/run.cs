//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class CmdScripts
    {
        static FilePath ErrorLog(Timestamp ts, string name)
            => AppDb.Logs("process").Path($"{name}.errors.{ts}", FileKind.Log);

        static FilePath StatusLog(Timestamp ts, string name)
            => AppDb.Logs("process").Path($"{name}.{ts}", FileKind.Log);

        public static Outcome run(CmdLine cmd, CmdVars vars, out ReadOnlySpan<TextLine> response)
        {
            response = sys.empty<TextLine>();
            var result = Outcome.Success;
            try
            {
                var process = Cmd.process(cmd, vars);
                process.Wait();
                response = Lines.read(process.Output);
            }
            catch(Exception e)
            {
                result = e;
            }
            return result;
        }

        public static void run(CmdScript src)
        {
            var ts = timestamp();
            using var status = StatusLog(ts, src.Name.Format()).AsciWriter();

            void OnStatus(in string msg)
                => status.AppendLine(msg);

            void OnError(in string msg)
                => ErrorLog(ts,src.Name).Append(msg);

            try
            {
                var process = Cmd.process(src.ToCmdLine(), OnStatus, OnError).Wait();
            }
            catch(Exception e)
            {
                ErrorLog(ts,src.Name).Append(e.ToString());
            }            
        }

        [Op]
        public static Outcome run(CmdLine cmd, CmdVars vars, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> response)
            => run(cmd, vars, FilePath.Empty, status,error, out response);

        [Op]
        public static Outcome run(CmdLine cmd, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> response)
            => run(cmd, CmdVars.Empty, FilePath.Empty, status,error, out response);

        public static Outcome run(FilePath src, CmdArgs args, FilePath dst)
        {
            var result = Outcome.Success;
            try
            {
                var cmd = new CmdLine(string.Format("{0} \"{1}\"", src.Format(PathSeparator.BS), args.Format()));
                var process = Cmd.process(cmd).Wait();
                var lines =  Lines.read(process.Output);
                if(dst.IsNonEmpty)
                {
                    using var writer = dst.AsciWriter();
                    iter(lines, line => writer.WriteLine(line));
                }
            }
            catch(Exception e)
            {
                result = e;
            }
            return result;
        }

        public static ReadOnlySpan<TextLine> run(CmdLine cmd, CmdVars vars)
        {
            try
            {
                var process = Cmd.process(cmd, vars);
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
                var process = vars != null ? Cmd.process(cmd, vars) : Cmd.process(cmd);
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
                var process = Cmd.process(cmd);
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
                var proc = Cmd.process(cmd, vars, status, error).Wait();
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