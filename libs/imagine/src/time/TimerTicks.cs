//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics;

    /// <summary>
    /// Captures and explores the relationship between hardware ticks and measured time
    /// </summary>
    [ApiHost]
    public readonly struct TimerTicks
    {
        readonly ulong TicksPerSecond;

        public static TimerTicks Default
        {
            [MethodImpl(Inline)]
            get => new TimerTicks((ulong)Stopwatch.Frequency);
        }

        [MethodImpl(Inline), Op]
        public static TimerTicks @default()
            => Default;

        [MethodImpl(Inline), Op]
        public static ulong nsPerTick(TimerTicks src)
            => src.NsPerTick;

        [MethodImpl(Inline), Op]
        public static double ticksPerMs(TimerTicks src)
            => src.TicksPerMs;

        /// <summary>
        /// Computes the number of milliseconds accounted for by a specified number of ticks
        /// </summary>
        /// <param name="ticks">The tick count</param>
        [MethodImpl(Inline), Op]
        public static double ms(long ticks)
            => ((double)ticks)/Default.TicksPerMs;

        /// <summary>
        /// Computes the number of nanoseconds accounted for by a specified number of ticks
        /// </summary>
        /// <param name="ticks">The tick count</param>
        [MethodImpl(Inline), Op]
        public static ulong ns(long ticks)
            => Default.NsPerTick * (ulong)ticks;

        [MethodImpl(Inline)]
        TimerTicks(ulong frequency)
            => TicksPerSecond = frequency;

        /// <summary>
        /// The number of nanoseconds that elapse during a timer tick
        /// </summary>
        public ulong NsPerTick
        {
            [MethodImpl(Inline)]
            get => 1_000_000_000/TicksPerSecond;
        }

        /// <summary>
        /// The number of ticks per second
        /// </summary>
        public double TicksPerMs
        {
            [MethodImpl(Inline)]
            get => (double)TicksPerSecond/1000.0;
        }
    }
}