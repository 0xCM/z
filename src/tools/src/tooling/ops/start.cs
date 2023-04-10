//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Tooling
    {
        public static Task<ExecStatus> start(IToolFlow flow, ToolCmd cmd)
            => sys.start(() => run(flow, cmd));

        static ExecStatus run(IToolFlow flow, ToolCmd cmd)
        {
            var i=0u;
            var j=0u;
            var psi = new ProcessStartInfo(cmd.ToolPath.Format(), cmd.Args.Format())
            {
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                ErrorDialog = false,
                CreateNoWindow = true,
                RedirectStandardInput = false,
                WorkingDirectory = cmd.WorkingDir.Format(PathSeparator.BS)
            };

            iter(cmd.Vars, v => psi.Environment.Add(v.Name, v.Value));

            void OnStatus(object sender, DataReceivedEventArgs e)
            {
                if(sys.nonempty(e.Data))
                {
                    inc(ref i);
                    flow.OnStatus((i,e.Data));
                }                    
            }
    
            void OnError(object sender, DataReceivedEventArgs e)
            {
                if(sys.nonempty(e.Data))
                {
                    inc(ref j);
                    flow.OnError((j,e.Data));
                }
            }

            var status = default(ExecStatus);
            var msg = string.Format("{0}:({1})", cmd.ToolPath, cmd.Args.Map(x => text.squote(x.Format())).Delimit());
            var running = flow.Running(msg);
            status.Token = running.Token;
            try
            {                
                using var process = sys.process(psi);
                process.OutputDataReceived += OnStatus;
                process.ErrorDataReceived += OnError;
                process.Start();
                flow.OnStart(running.Token);
                status.StartTime = sys.now();
                status.Id = process.Id;
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                status.HasExited = true;
                status.ExitTime = sys.now();
                status.Duration = status.ExitTime - status.StartTime;
                status.ExitCode = process.ExitCode;
                flow.OnFinish(status);
                flow.Ran(running, msg);
            }
            catch(Exception e)
            {
                inc(ref j);
                status.ExitCode = -1;
                flow.OnError((j,e.ToString()));
                flow.OnFinish(status);
            }
            return status;
        }
    }
}