// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    partial struct Kernel32
    {
        [DllImport(LibName), Free]
        public static extern int QueryPerformanceCounter(ref long count);

        /// <summary>
        /// Retrieves the number of performance counter counts per second.
        /// </summary>
        /// <remarks>This is determined by the OS at boot time and is invariant until the next reboot</remarks>
        [DllImport(LibName), Free]
        public static extern int QueryPerformanceFrequency(ref long frequency);

        /// <summary>
        /// Retrieves the cyle time for a specified thread
        /// </summary>
        /// <param name="hThread">The handle to the thread</param>
        /// <param name="cycles">The number of cpu clock cycles used by the thread</param>
        [DllImport(LibName), Free]
        public static extern bool QueryThreadCycleTime(IntPtr hThread, ref ulong cycles);

        /// <summary>
        /// Retrieves the sum of the cycle time of all threads of the specified process.
        /// </summary>
        /// <param name="hProc">The handle to the process</param>
        /// <param name="cycles">The number of cpu clock cycles used by the threads of the process</param>
        [DllImport(LibName), Free]
        public static extern bool QueryProcessCycleTime(IntPtr hProc, ref ulong cycles);

        [DllImport(LibName), Free]
        public static extern void QueryInterruptTime(ref ulong time);

        [DllImport(LibName), Free]
        public static extern void QueryInterruptTimePrecise(ref ulong time);
    }
}