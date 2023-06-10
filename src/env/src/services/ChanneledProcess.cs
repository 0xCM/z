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
        
        ToolCmdSpec Context;
        
        internal void Init(Process process, ToolCmdSpec context)
        {
            Process = process;
            Context = context;
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
            Context.ProcessStart(Process);
            var id = Process.Id;
            var name = Process.ProcessName;
            Process.BeginOutputReadLine();
            Process.BeginErrorReadLine();
            var ran = Channel.Ran(flow, $"Executed {name}:{id}");
            Process.WaitForExit();
            Context.ProcessExit(Process.ExitCode);
            return ran;
        }

        public ExecToken Run()
            => Run(Channel.Running($"Executing {Process.ProcessName}:{Process.Id}"));            
    }

    partial class XTend
    {
        public static ChanneledProcess ChannelProcess(this IWfChannel src, Process process, ToolCmdSpec context)
            => ChanneledProcess.create(src, x => x.Init(process,context));
    }
}