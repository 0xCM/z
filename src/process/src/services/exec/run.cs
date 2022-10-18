//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ProcExec
    {
        public static void run(IWfChannel channel, string tool, string cmd, CmdArgs args, FilePath dst)
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
            
            ProcExec.run(new SysIO(OnStatus, OnError, Input), Cmd.args(tool,cmd), dst.FolderPath);
            channel.EmittedFile(emitting, counter);
        }

        public static CmdExecStatus run(ISysIO io, CmdArgs spec, FolderPath? wd = null)
        {
            var values = spec.Values();
            Demand.gt(values.Count,0u);
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

            var outcome = default(CmdExecStatus);
            try
            {                
                using var process = sys.process(psi);
                process.OutputDataReceived += OnStatus;
                process.ErrorDataReceived += OnError;
                process.Start();
                outcome.StartTime = sys.now();
                outcome.Id = process.Id;
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExitAsync().Wait();                
                outcome.HasExited = true;
                outcome.ExitTime = sys.now();
                outcome.Duration = outcome.ExitTime - outcome.StartTime;
                outcome.ExitCode = process.ExitCode;
            }
            catch(Exception e)
            {
                io.Error(e.ToString());
            }
            return outcome;
        }

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