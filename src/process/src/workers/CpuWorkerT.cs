//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Threading;
using System.Threading.Tasks;

using api = CpuWorkers;

/// <summary>
/// Embodies an asynchronous thread of execution that is assigned to a specific CPU core
/// </summary>
public class CpuWorker<T>
{
    public void Execute()
        => Run();

    readonly uint Core;

    public TimeSpan Frequency {get;}

    public ulong CycleLength {get;}

    public ulong MaxCycles {get;}

    public uint WorkerId {get;}

    readonly Func<T,T> WorkerFunc;

    internal Thread ManagedWorkerThread;

    ulong CycleCounter;

    ProcessThread NativeWorkerThread;

    CpuCycleInfo WorkerStatus;

    T State;

    [MethodImpl(Inline)]
    internal CpuWorker(uint core, uint id, Func<T,T> fx, T data, TimeSpan freq, ulong length, ulong cycles)
    {
        Core = core;
        NativeWorkerThread = null;
        WorkerId = id;
        WorkerFunc = fx;
        State = data;
        Frequency = freq;
        MaxCycles = cycles;
        CycleCounter = 0;
        CycleLength = length;
        WorkerStatus = default;
        ManagedWorkerThread = default;
    }

    public ulong CurrentCycle
    {
        [MethodImpl(Inline)]
        get => CycleCounter;
    }

    public ulong CpuUsage
    {
        [MethodImpl(Inline)]
        get  => (ulong)(NativeWorkerThread?.TotalProcessorTime.Ticks ?? 0);
    }

    public uint CpuCore
    {
        [MethodImpl(Inline)]
        get => Core;
    }

    public T CurrentState
    {
        [MethodImpl(Inline)]
        get  => State;
    }

    [MethodImpl(Inline)]
    Task RunCycles()
    {
        return Task.Factory.StartNew(() =>
        {
            while(CycleCounter++ <= MaxCycles)
            {
                for(var i=0ul; i<CycleLength; i++)
                    State = WorkerFunc(State);

                api.describe(this, ref WorkerStatus);
                ++CycleCounter;
            }
        });
    }

    public CpuCycleInfo Status()
        => WorkerStatus;

    Task Run()
    {
        NativeWorkerThread = api.thread(CurrentProcess.OsThreadId);
        if(NativeWorkerThread != null)
            NativeWorkerThread.IdealProcessor = (int)Core;

        return RunCycles();
    }
}
