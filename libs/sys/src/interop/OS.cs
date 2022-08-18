//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct OS
    {
        public readonly struct Delegates
        {
            [Fp(StdCall), Free]
            public delegate int DllMain(IntPtr instance, int reason, IntPtr reserved);

            [Fp(StdCall), Free]
            public delegate IntPtr GetProcAddress(IntPtr module, string name);

            [Fp(StdCall), Free]
            public delegate int AddRefDelegate(IntPtr self);

            [Fp(StdCall), Free]
            public delegate int ReleaseDelegate(IntPtr self);

            [Fp(StdCall), Free]
            public delegate int QueryInterfaceDelegate(IntPtr self, in Guid guid, out IntPtr ptr);

            [Fp(StdCall), Free]
            public delegate int QueryPerformanceCounter(ref long count);

            /// <summary>
            /// Retrieves the number of performance counter counts per second.
            /// </summary>
            /// <remarks>This is determined by the OS at boot time and is invariant until the next reboot</remarks>
            [Fp(StdCall), Free]
            public delegate int QueryPerformanceFrequency(ref long frequency);

            /// <summary>
            /// Retrieves the cyle time for a specified thread
            /// </summary>
            /// <param name="hThread">The handle to the thread</param>
            /// <param name="cycles">The number of cpu clock cycles used by the thread</param>
            [Fp(StdCall), Free]
            public delegate bool QueryThreadCycleTime(IntPtr hThread, ref ulong cycles);

            /// <summary>
            /// Retrieves the sum of the cycle time of all threads of the specified process.
            /// </summary>
            /// <param name="hProc">The handle to the process</param>
            /// <param name="cycles">The number of cpu clock cycles used by the threads of the process</param>
            [Fp(StdCall), Free]
            public delegate bool QueryProcessCycleTime(IntPtr hProc, ref ulong cycles);

            [Fp(StdCall), Free]
            public delegate void QueryInterruptTime(ref ulong time);

            [Fp(StdCall), Free]
            public delegate void QueryInterruptTimePrecise(ref ulong time);

            [Fp(StdCall), Free]
            public delegate bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int dwSize, out int lpNumberOfBytesRead);
        }
    }
}