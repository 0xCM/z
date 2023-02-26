//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Threading;

    using static sys;

    using Windows;

    public class CmdArbiter : IDisposable
    {
        public static CmdArbiter start(NativeBuffer buffer)
        {
            var arbiter = new CmdArbiter(buffer);
            arbiter.WorkerThread = new Thread(arbiter.Run);
            arbiter.ControlThread = new Thread(arbiter.Control);
            arbiter.Start();
            return arbiter;
        }

        public class Job
        {
            public static Job create(Action worker, Action finished)
                => new Job(worker,finished);

            public Action Worker {get;}

            public Action Finished {get;}

            public Job(Action worker, Action finished)
            {
                Worker = worker;
                Finished = finished;
            }
        }

        readonly NativeBuffer ContextBuffer;

        Thread WorkerThread;

        uint WorkerThreadId;

        SystemHandle WorkerHandle;

        Thread ControlThread;

        uint ControlThreadId;

        ConcurrentQueue<Job> WorkQueue;

        ConcurrentQueue<Job> CompletionQueue;

        bool Stopping;

        bool WorkerStopped;

        bool ControlStopped;

        bool Verbose;

        CmdArbiter(NativeBuffer buffer)
        {
            ContextBuffer = buffer;
            Stopping = false;
            WorkerStopped = false;
            ControlStopped = false;
            Verbose = false;
            WorkQueue = new();
            CompletionQueue = new();
        }

        void Control()
        {
            ControlThreadId = ExecutingThread();

            if(Verbose)
                term.babble(string.Format("Thread {0}:Beginning control loop", ControlThreadId));

            while(!Stopping)
            {
                if(CompletionQueue.TryDequeue(out var job))
                {
                    job.Finished();
                }

                Thread.Sleep(10);
            }

            ControlStopped = true;
        }

        void Run()
        {
            WorkerThreadId = ExecutingThread();
            if(WorkerThreadId == 0)
            {
                term.error("Thread has no identity");
                return;
            }

            WorkerHandle = OpenThread(WorkerThreadId);

            if(Verbose)
                term.babble(string.Format("Thread {0}:Beginning worker loop", WorkerThreadId));

            while(!Stopping)
            {
                while(WorkQueue.TryDequeue(out var job))
                {
                    try
                    {
                        job.Worker();
                        CompletionQueue.Enqueue(job);
                    }
                    catch(Exception e)
                    {
                        term.error(e);
                    }
                }

                Thread.Sleep(10);
            }

            WorkerStopped = true;
        }

        void Start()
        {
            WorkerThread.Start();
            ControlThread.Start();
        }

        Outcome Suspend()
        {
            var result = Kernel32.SuspendThread(WorkerHandle);
            if(result != 0)
                return (false, Kernel32.GetLastError());
            else
                return true;
        }

        Outcome Resume()
        {
            var result = Kernel32.ResumeThread(WorkerHandle);
            if(result != 0)
                return (false, Kernel32.GetLastError());
            else
                return true;
        }

        public void Dispose()
        {
            Stopping = true;
            while(!WorkerStopped && !ControlStopped)
            {
                delay(10);
                if(Verbose)
                    term.babble(string.Format("{0}: Terminating threads {1} and {2}", ExecutingThread(), ControlThreadId, WorkerThreadId));
            }
            WorkerHandle.Dispose();
        }

        public void Enque(Action worker, Action complete)
        {
            WorkQueue.Enqueue(Job.create(worker,complete));
        }

        public unsafe void CaptureContext()
        {
            var executing = ExecutingThread();
            if(Verbose)
                term.babble(string.Format("[{0}]:Suspending command thread {1}",  executing, WorkerThreadId));

            var outcome = Suspend();
            if(outcome.Fail)
            {
                term.error(outcome.Message);
                return;
            }

            if(Verbose)
                term.babble(string.Format("[{0}]:Capuring suspended thread context", executing, WorkerThreadId));

            ContextBuffer.Clear();
            ref var context = ref @as<byte,Amd64Context>(first(ContextBuffer.Edit));
            context.ContextFlags = ContextFlags.CONTEXT_ALL;
            outcome = Kernel32.GetThreadContext(WorkerHandle, gptr(context));
            if(outcome.Fail)
                term.error(Kernel32.GetLastError());

            if(Verbose)
                term.babble(string.Format("[{0}]:Resuming thread {1}",  executing, WorkerThreadId));

            Resume();
        }

        static uint ExecutingThread()
            => Kernel32.GetCurrentThreadId();

        static SystemHandle OpenThread(uint threadId)
            => Kernel32.OpenThread(ThreadAccess.THREAD_ALL_ACCESS, true, threadId);
    }
}