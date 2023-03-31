//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    [ApiHost,Free]
    public sealed class ProcessControl : Control<ProcessControl>
    {
        public static IControl Control()
            => Instance;    

        static ProcessControl Instance = new();

        public static unsafe Outcome context(ThreadId id, out CONTEXT dst)
        {
            var result = Outcome.Failure;
            var ctx = default(CONTEXT);
            ctx.ContextFlags = CONTEXT_FLAGS.CONTEXT_CONTROL | CONTEXT_FLAGS.CONTEXT_SEGMENTS | CONTEXT_FLAGS.CONTEXT_INTEGER;
            ctx.VectorControl = 1;
            using var open = ProcessThreads.open(id);
            result = Kernel32.GetThreadContext(open, (IntPtr)sys.gptr(ctx));
            if(result.Fail)
                result = Outcome.fail(Kernel32.GetLastError());
            dst = ctx;
            return result;
        }

        public unsafe static Outcome context(out CONTEXT dst)
        {
            var id = ThreadId.Empty;
            var result = Outcome.Failure;
            var ctx = default(CONTEXT);

            void OnStart(EventWaitHandle wait)
            {
                id = ProcessThreads.executing();
                result = context(id, out ctx);
                // using var open = ProcessThreads.open(id);
                // result = Kernel32.GetThreadContext(open, (IntPtr)sys.gptr(ctx));
                // if(result.Fail)
                //     result = Outcome.fail(Kernel32.GetLastError());
                wait.Set();
            }

            var wait = new EventWaitHandle(false, EventResetMode.ManualReset);
            var thread = new Thread(new ParameterizedThreadStart(obj => OnStart((EventWaitHandle)obj)));
            thread.Start(wait);
            wait.WaitOne();            
            dst = ctx;
            term.babble(id);
            return result;           
        }
    }
}
