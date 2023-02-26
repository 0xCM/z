//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using Windows;

    [ApiHost,Free]
    public class ProcessThreads
    {
        [MethodImpl(Inline), Op]
        public static ThreadId executing()
            => Kernel32.GetCurrentThreadId();

        [MethodImpl(Inline), Op]
        public static SystemHandle open(ThreadId threadId)
            => Kernel32.OpenThread(ThreadAccess.THREAD_ALL_ACCESS, true, threadId);

        [MethodImpl(Inline), Op]
        public static Outcome suspend(SystemHandle handle)
        {
            var result = Kernel32.SuspendThread(handle);
            if(result != 0)
                return (false, Kernel32.GetLastError());
            else
                return true;
        }

        [MethodImpl(Inline), Op]
        public static Outcome resume(SystemHandle handle)
        {
            var result = Kernel32.ResumeThread(handle);
            if(result != 0)
                return (false, Kernel32.GetLastError());
            else
                return true;
        }
    }
}