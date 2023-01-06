//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using Windows;

    [ApiHost,Free]
    public sealed class ProcessControl : Control<ProcessControl>
    {
        public static IControl Control()
            => Instance;    

        static ProcessControl Instance = new();

        public unsafe static Outcome context(out Amd64Context dst)
        {
            var id = ThreadId.Empty;
            var success = Outcome.Success;
            var ctx = default(Amd64Context);

            void OnStart(EventWaitHandle wait)
            {
                id = Kernel32.GetCurrentThreadId();
                using var open = ProcessThreads.open(id);
                success = Kernel32.GetThreadContext(open, (IntPtr)sys.gptr(ctx));
                wait.Set();
            }

            var wait = new EventWaitHandle(false, EventResetMode.ManualReset);
            var thread = new Thread(new ParameterizedThreadStart(obj => OnStart((EventWaitHandle)obj)));
            thread.Start(wait);
            wait.WaitOne();            
            dst = ctx;
            term.babble(id);
            return success;           
        }
    }
}