//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XTend
    {
        public static ChanneledProcess ChannelProcess(this IWfChannel src, Process process)
            => Z0.ChanneledProcess.create(src, x => x.Init(process));
    }

    public class ChanneledProcess : Channeled<ChanneledProcess>
    {
        Process Process;

        internal void Init(Process process)
        {
            Process = process;
            process.OutputDataReceived += (s,d) => OnStatus(d);
            process.ErrorDataReceived += (s,d) => OnError(d);
        }

        void OnStatus(DataReceivedEventArgs e)
        {
            if(e != null && nonempty(e.Data))
                Channel.Row(e.Data);
        }

        void OnError(DataReceivedEventArgs e)
        {
            if(e != null && nonempty(e.Data))
                Channel.Error(e.Data);                
        }

        public ExecToken Run()
        {
            var token = ExecToken.Empty;
            var status = ExecutingProcess.Empty;            
            Process.Start();
            var executing = Channel.Running($"Executing {Process.ProcessName}:{Process.Id}");
            Process.BeginOutputReadLine();
            Process.BeginErrorReadLine();
            Process.WaitForExit();
            token = Channel.Ran(executing, $"Executed {Process.ProcessName}:{Process.Id}");
            return token;            
        }
    }
}