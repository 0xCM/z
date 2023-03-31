//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ToolFlows
    {
        public static IToolStreamWriter writer(FilePath src)
            => new ToolStreamWriter(src);
            
        public static Task<ExecStatus> start(IToolFlow flow, ToolExecSpec spec)
            => sys.start(() => run(flow, spec));
            
        static ExecStatus run(IToolFlow flow, ToolExecSpec spec)
        {
            var i=0u;
            var j=0u;
            var tool = spec.ToolPath;
            var args = spec.Args;
            var psi = new ProcessStartInfo(tool.Format(), args.Format())
            {
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                ErrorDialog = false,
                CreateNoWindow = true,
                RedirectStandardInput = false,
                WorkingDirectory = spec.WorkingDir.Format(PathSeparator.BS)
            };

            iter(spec.Vars, v => psi.Environment.Add(v.Name, v.Value));

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
            var running = flow.Running($"{tool}:{args}");
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
                flow.Ran(running);
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