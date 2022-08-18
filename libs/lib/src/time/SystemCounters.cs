//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Windows.Kernel32;

    /// <summary>
    /// Defines counter api surface
    /// </summary>
    [ApiHost]
    public readonly struct SystemCounters
    {
        [MethodImpl(Inline), Op]
        public static ulong frequency()
        {
            var f = 0L;
            QueryPerformanceFrequency(ref f);
            return (ulong)f;
        }

        [MethodImpl(Inline), Op]
        public static SystemCounter counter(bool start = false)
        {
            var counter = default(SystemCounter);
            if(start)
                counter.Start();
            return counter;
        }

        /// <summary>
        /// Returns the difference between the current Counter value and a prior counter value
        /// </summary>
        [MethodImpl(Inline), Op]
        public static long delta(in long prior)
            => count() - prior;

        /// <summary>
        /// Converts a counter value to milliseconds
        /// </summary>
        /// <param name="count">The count value to convert</param>
        [MethodImpl(Inline), Op]
        public static double ms(in long count)
            => ((double)count)/((double) frequency());

        /// <summary>
        /// Gets the current value of the counter
        /// </summary>
        [MethodImpl(Inline), Op]
        public static long count()
        {
            var count = 0L;
            QueryPerformanceCounter(ref count);
            return count;
        }

        [MethodImpl(Inline), Op]
        public static ref long count(ref long count)
        {
            QueryPerformanceCounter(ref count);
            return ref count;
        }

        /// <summary>
        /// Gets the CPU cycles consumed by the calling thread
        /// </summary>
        [MethodImpl(Inline), Op]
        public static ulong cycles()
        {
            var cycles = 0ul;
            if (!QueryThreadCycleTime((IntPtr)(-2), ref cycles))
                return 0ul;
            return cycles;
        }

        /// <summary>
        /// Gets the CPU cycles consumed by the calling thread
        /// </summary>
        [MethodImpl(Inline), Op]
        public static ref ulong cycles(ref ulong dst)
        {
            if (!QueryThreadCycleTime((IntPtr)(-2), ref dst))
                dst = 0ul;
            return ref dst;
        }
    }
}