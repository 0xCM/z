//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Cmd
    {
        public static ExecToken run(CmdArgs spec, FilePath dst, WfEmit channel)
        {
            var running = channel.Running($"Executing command '{spec}");
            var token = ExecToken.Empty;
            var buffer = list<string>();
            buffer.Add($"# {spec}");

            void OnData(string src)
            {
                if(nonempty(src))
                    buffer.Add(src);
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
                    :  (IWfEvent)Events.babble(typeof(CmdScript), $"Process completed:{outcome}");

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
                WorkingDirectory = "C:\\temp"
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
                outcome.Duration = outcome.ExitTime - outcome.StartTime;
                outcome.ExitCode = process.ExitCode;
            }
            catch(Exception e)
            {
                error(e.ToString());
            }
            return outcome;
        }
    }
}