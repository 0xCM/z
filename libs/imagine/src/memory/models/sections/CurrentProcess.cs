//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static Windows.Kernel32;

    /// <summary>
    /// Surfaces information about the currently executing process
    /// </summary>
    [ApiHost]
    public readonly struct CurrentProcess
    {
        /// <summary>
        /// Gets the OS thread ID - not the CRL thread id
        /// </summary>
        public static uint OsThreadId
        {
            [MethodImpl(Inline), Op]
            get => GetCurrentThreadId();
        }

        public static int ManagedThreadId
        {
            [MethodImpl(Inline), Op]
            get => Thread.CurrentThread.ManagedThreadId;
        }

        /// <summary>
        /// The process id
        /// </summary>
        public static int ProcessId
        {
            [MethodImpl(Inline), Op]
            get => sys.CurrentProcess.Id;
        }

        /// <summary>
        /// The handle for the current process
        /// </summary>
        public static IntPtr ProcessHandle
        {
            [MethodImpl(Inline), Op]
            get => sys.CurrentProcess.Handle;
        }

        /// <summary>
        /// The handle for the current thread
        /// </summary>
        public static IntPtr ThreadHandle
        {
            [MethodImpl(Inline), Op]
            get => GetCurrentThread();
        }

        public static string Name
        {
            [MethodImpl(Inline), Op]
            get => sys.CurrentProcess.ProcessName;
        }

        public static IEnumerable<ProcessThread> Threads
            => from ProcessThread pt in sys.CurrentProcess.Threads select pt;

        /// <summary>
        /// Searches for a thread given an OS-assigned id, not the (mostly) useless clr id
        /// </summary>
        /// <param name="id">The OS thread Id</param>
        public static ProcessThread ProcessThread(uint id)
            => Threads.FirstOrDefault(t => t.Id == id);
    }
}