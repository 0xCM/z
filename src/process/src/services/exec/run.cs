//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial record class ProcExec
    {
        public static ExecToken run(FilePath src, FilePath dst, IWfChannel channel)
            => run(Cmd.args(src), dst, channel);

        public static ExecToken run(CmdArgs spec, FilePath dst, IWfChannel channel)
        {
            var running = channel.Running($"Executing command '{spec}");
            var token = ExecToken.Empty;
            var buffer = list<string>();
            buffer.Add($"# {spec}");

            void OnData(string src)
            {
                if(nonempty(src))
                {
                    buffer.Add(src);
                    channel.Row(src);
                }
            }

            void OnError(string src)
            {
                if(nonempty(src))
                    buffer.Add(src);                
                channel.Error(src);
            }

            try
            {
                var outcome = run(spec, OnData, OnError);
                var @event = outcome.ExitCode != 0 ? 
                    (IWfEvent)Events.error(typeof(CmdScript), $"Process exited with code {outcome.ExitCode}") 
                    : (IWfEvent)Events.babble(typeof(CmdScript), $"Process completed:{outcome}");

                channel.Raise(@event);
                channel.FileEmit(text.join('\n', buffer.ViewDeposited()), dst);                
                token = channel.Ran(running);
            }
            catch(Exception e)
            {
                token = channel.Ran(running,e);
            }
            return token;            
        }

        public static CmdExecStatus run(CmdArgs spec, Action<string> status, Action<string> error)
        {
            var values = spec.Values();
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
                WorkingDirectory = Environment.CurrentDirectory
            };

            void OnStatus(object sender, DataReceivedEventArgs e)
            {
                if(sys.nonempty(e.Data))
                    status(e.Data);
            }
    
            void OnError(object sender, DataReceivedEventArgs e)
            {
                if(sys.nonempty(e.Data))
                    error(e.Data);
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
                outcome.Duration = (ulong)outcome.ExitTime - (ulong)outcome.StartTime;
                outcome.ExitCode = process.ExitCode;
            }
            catch(Exception e)
            {
                error(e.ToString());
            }
            return outcome;
        }

        public static CmdExecStatus run(CmdArgs spec, IStdIO io, FolderPath wd)
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
                WorkingDirectory = wd.Format()
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

        public static ReadOnlySpan<TextLine> run(CmdLine cmd, string script, CmdVars? vars)
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