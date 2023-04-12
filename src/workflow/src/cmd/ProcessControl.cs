//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    using static sys;

    [ApiHost,Free]
    public sealed unsafe class ProcessControl : Control<ProcessControl>
    {
        public static bool find(ProcessId id, out ProcessAdapter dst)
        {
            try
            {
                dst = Process.GetProcessById((int)id);
            }
            catch
            {
                dst = null;
            }
            return dst != null;
        }

        public static IControl Control()
            => Instance;    

        static ProcessControl Instance = new();

        [DllImport(ImageNames.PsApi, SetLastError = true), Free]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnumProcesses([Out] ProcessId* lpidProcess, [In]uint cb, [Out] uint* lpcbNeeded);

        public static ReadOnlySpan<ProcessId> executing()
        {
            var needed = 0u;
            var max = 2024u;
            var count = 0u;
            var buffer = span<ProcessId>(max);
            fixed(ProcessId* pBuffer = &buffer[0])
            {
                var result = EnumProcesses(pBuffer, max*4, &needed);                
                if(result)
                {
                    count = min(max,needed/4);
                }
            }
            var values = slice(buffer, 0, count);
            values.Sort();
            return values;
        }

        public static PROCESS_BASIC_INFORMATION basic()
        {
            var process = Kernel32.GetCurrentProcess();
            var dst = default(PROCESS_BASIC_INFORMATION);
            NtDll.NtQueryInformationProcess(process, PROCESSINFOCLASS.ProcessBasicInformation, &dst, size<PROCESS_BASIC_INFORMATION>(), out var length);
            Require.equal(length, size<PROCESS_BASIC_INFORMATION>());
            return dst;
        }

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
