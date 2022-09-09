//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Timestamp : IDataType<Timestamp>
    {
        public const string FormatPattern = "yyyy-MM-dd.HH.mm.ss.fff";

        [MethodImpl(Inline)]
        public static Timestamp now()
            => DateTime.Now;

        [MethodImpl(Inline), Op]
        public static Timestamp ticks(ulong ticks)
            => new Timestamp(ticks);

        [MethodImpl(Inline), Op]
        public static Timestamp ticks(long ticks)
            => new Timestamp((ulong)ticks);

        readonly ulong Ticks;

        [MethodImpl(Inline)]
        public Timestamp(ulong ticks)
            => Ticks = ticks;

        [MethodImpl(Inline)]
        public string Format()
            => new DateTime((long)Ticks).ToString(FormatPattern);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(Timestamp src)
            => Ticks == src.Ticks;

        [MethodImpl(Inline)]
        public int CompareTo(Timestamp src)
            => Ticks.CompareTo(src.Ticks);

        bool INullity.IsEmpty
            => IsZero;

        public bool IsZero
        {
            [MethodImpl(Inline)]
            get => Ticks == 0;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Ticks != 0;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => HashCodes.hash(Ticks);
        }

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public static implicit operator ulong(Timestamp src)
            => src.Ticks;

        [MethodImpl(Inline)]
        public static implicit operator Timestamp(DateTime src)
            => new Timestamp((ulong)src.Ticks);

        public static Duration operator -(Timestamp a, Timestamp  b)
            => b.Ticks - a.Ticks;

        [MethodImpl(Inline)]
        public static bool operator <(Timestamp a, Timestamp b)
            => a.Ticks < b.Ticks;

        [MethodImpl(Inline)]
        public static bool operator <=(Timestamp a, Timestamp b)
            => a.Ticks <= b.Ticks;

        [MethodImpl(Inline)]
        public static bool operator >(Timestamp a, Timestamp b)
            => a.Ticks > b.Ticks;

        [MethodImpl(Inline)]
        public static bool operator >=(Timestamp a, Timestamp b)
            => a.Ticks >= b.Ticks;

        public static Timestamp Zero => default;
    }
}