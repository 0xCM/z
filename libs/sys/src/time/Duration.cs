//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Captures a duration
    /// </summary>
    public readonly struct Duration : IDataType<Duration>
    {
        /// <summary>
        /// The number of elapsed timer ticks that determines the period length
        /// </summary>
        public long Ticks {get;}

        [MethodImpl(Inline)]
        public static Duration init(long ticks)
            => new Duration(ticks);

        [MethodImpl(Inline)]
        public static Duration init(ulong ticks)
            => new Duration((long)ticks);

        [MethodImpl(Inline)]
        public static Duration init(TimeSpan ts)
            => new Duration(ts.Ticks);

        [MethodImpl(Inline)]
        public Duration(long ticks)
            => Ticks = ticks;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get  => hash(Ticks);
        }

        bool INullity.IsEmpty
            => Ticks == 0;

        /// <summary>
        /// The duration expressed in nanoseconds
        /// </summary>
        public ulong Ns
        {
            [MethodImpl(Inline)]
            get => TimerTicks.ns(Ticks);
        }

        /// <summary>
        /// The duration expressed in timer ticks
        /// </summary>
        public ulong TickCount
        {
            [MethodImpl(Inline)]
            get => (ulong)Ticks;
        }

        /// <summary>
        /// The duration expressed in milliseconds
        /// </summary>
        public double Ms
        {
            [MethodImpl(Inline)]
            get => TimerTicks.ms(Ticks);
        }

        public TimeSpan TimeSpan
        {
            [MethodImpl(Inline)]
            get => new TimeSpan(Ticks);
        }

        [MethodImpl(Inline)]
        public bool Equals(Duration rhs)
            => this.Ticks == rhs.Ticks;

        [MethodImpl(Inline)]
        public int CompareTo(Duration other)
            => Ticks.CompareTo(other.Ticks);

        public string Format()
            => $"{Ms} ms";

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Ticks.GetHashCode();

        public override bool Equals(object obj)
            => obj is Duration x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator TimeSpan(Duration src)
            => src.TimeSpan;

        [MethodImpl(Inline)]
        public static implicit operator Duration(TimeSpan src)
            => new Duration(src.Ticks);

        [MethodImpl(Inline)]
        public static implicit operator Duration(long ticks)
            => init(ticks);

        [MethodImpl(Inline)]
        public static implicit operator Duration(ulong ticks)
            => init(ticks);

        [MethodImpl(Inline)]
        public static explicit operator int(Duration src)
            => (int)src.Ticks;

        [MethodImpl(Inline)]
        public static Duration operator +(Duration a, Duration b)
            => new Duration(a.Ticks + b.Ticks);

        [MethodImpl(Inline)]
        public static Duration operator +(Duration a, TimeSpan b)
            => new Duration(a.Ticks + b.Ticks);

        [MethodImpl(Inline)]
        public static Duration operator -(Duration a, Duration b)
            => new Duration(a.Ticks - b.Ticks);

        [MethodImpl(Inline)]
        public static Duration operator -(Duration a, TimeSpan b)
            => new Duration(a.Ticks - b.Ticks);

        [MethodImpl(Inline)]
        public static double operator /(Duration a, Duration b)
            => Math.Round((double)a.Ticks / (double) b.Ticks, 4);

        [MethodImpl(Inline)]
        public static double operator /(Duration a, TimeSpan b)
            => Math.Round((double)a.Ticks / (double) b.Ticks, 4);

        [MethodImpl(Inline)]
        public static bool operator !=(Duration a, Duration b)
            => a.Ticks != b.Ticks;

        [MethodImpl(Inline)]
        public static bool operator ==(Duration a, Duration b)
            => a.Ticks == b.Ticks;

        [MethodImpl(Inline)]
        public static bool operator >(Duration lhs, Duration rhs)
            => lhs.Ticks > rhs.Ticks;

        [MethodImpl(Inline)]
        public static bool operator >(Duration lhs, TimeSpan rhs)
            => lhs.Ticks > rhs.Ticks;

        [MethodImpl(Inline)]
        public static bool operator <(Duration lhs, Duration rhs)
            => lhs.Ticks < rhs.Ticks;

        [MethodImpl(Inline)]
        public static bool operator <(Duration lhs, TimeSpan rhs)
            => lhs.Ticks < rhs.Ticks;

        [MethodImpl(Inline)]
        public static bool operator >=(Duration lhs, Duration rhs)
            => lhs.Ticks >= rhs.Ticks;

        [MethodImpl(Inline)]
        public static bool operator >=(Duration lhs, TimeSpan rhs)
            => lhs.Ticks >= rhs.Ticks;

        [MethodImpl(Inline)]
        public static bool operator <=(Duration lhs, Duration rhs)
            => lhs.Ticks <= rhs.Ticks;

        [MethodImpl(Inline)]
        public static bool operator <=(Duration lhs, TimeSpan rhs)
            => lhs.Ticks <= rhs.Ticks;

        public static Duration Zero
            => new Duration(0);
    }
}