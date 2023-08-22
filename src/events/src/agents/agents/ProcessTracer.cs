//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Microsoft.Diagnostics.Tracing.Parsers;
using Microsoft.Diagnostics.Tracing.Parsers.Kernel;
using Microsoft.Diagnostics.Tracing.Session;

[Agent]
public class ProcessTracer : IAgent
{
    const string Name = nameof(ProcessTracer);

    ExecFlow? Flow;

    IWorkerLog StartLog;

    TraceEventSession Session;

    readonly ICsvFormatter<ProcessStartEvent> StartEventFormatter;

    readonly IWfChannel Channel;

    readonly IDbArchive Targets;
    
    public ProcessTracer(IWfRuntime wf)
    {
        Channel = wf.Channel;
        Targets = AppSettings.Default.EnvDb();
        StartEventFormatter = CsvTables.formatter<ProcessStartEvent>();
    }

    void StartAgent()
    {
        var dst = Targets.Scoped(Name);
        ProcessId control = ExecutingPart.Process.Id;
        var fileid= $"{control}.processes.start";
        if(Session == null)
        {
            Session = AppGlobals.register(Name,() => new TraceEventSession(KernelTraceEventParser.KernelSessionName));
        }

        if(StartLog == null)
        {
            StartLog = Loggers.worker(new LogSettings(dst.Path(fileid,FileKind.Csv), dst.Path(fileid, FS.ext("errors"))));
        }

        if(Flow == null)
        {
            sys.start(() => {
                var session = Session;
                session.EnableKernelProvider(KernelTraceEventParser.Keywords.ImageLoad | KernelTraceEventParser.Keywords.Process);

                session.Source.Kernel.ImageLoad += delegate (ImageLoadTraceData data)
                {
                    Channel.RowFormat("Process {0,16} image load 0x{1,8:x} {2}", data.ProcessName, data.ImageBase, data.FileName);
                };
                session.Source.Kernel.ProcessStart += delegate (ProcessTraceData data)
                {                        
                    var e = new ProcessStartEvent(data.ProcessID, data.ParentID, data.TimeStamp, data.ProcessName, data.CommandLine);
                    var cmdline = data.PayloadByName(nameof(data.CommandLine));
                    Channel.RowFormat("Process Started {0,6} Parent {1,6} Name {2,8} Cmd: {3}", data.ProcessID, data.ParentID, data.ProcessName, $"{data.PayloadByName(nameof(data.CommandLine))}");
                    StartLog.LogStatus(StartEventFormatter.Format(e));
                
                };
                //  Subscribe to more events (process end)
                session.Source.Kernel.ProcessStop += delegate (ProcessTraceData data)
                {
                    Channel.RowFormat("Process {0,-6} {1} finished", data.ProcessID, data.ProcessName);
                };
                Flow = Channel.Running(Name);
                session.Source.Process();
            });
        }
    }

    public Task Start()
        => sys.start(StartAgent);

    void StopAgent()
    {
        if(Session != null)
        {
            Session.Source.StopProcessing();
            if(AppGlobals.unregister(Name))
            {
                Channel.Ran(Flow.Value, Name);                
                Flow = null;
            }
            else
            {
                Channel.Warn($"{Name} not running");
            }
        }
        else
        {
            Channel.Warn($"{Name} not running");
        }

        if(StartLog != null)
        {
            StartLog.Dispose();
            StartLog = null;
        }
    }

    public Task Stop()
        => sys.start(StopAgent);

    public void Dispose()
    {
        Stop().Wait();
    }
}
