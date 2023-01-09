//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

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

        public ExecToken Run<T>(ExecFlow<T> flow)
        {
            Process.Start();
            var id = Process.Id;
            var name = Process.ProcessName;
            Process.BeginOutputReadLine();
            Process.BeginErrorReadLine();
            Process.WaitForExit();
            return Channel.Ran(flow, $"Executed {name}:{id}");
        }

        public ExecToken Run()
            => Run(Channel.Running($"Executing {Process.ProcessName}:{Process.Id}"));            
    }

    partial class XTend
    {
        public static ChanneledProcess ChannelProcess(this IWfChannel src, Process process)
            => Z0.ChanneledProcess.create(src, x => x.Init(process));
    }
}