//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents one or more occurrence of a value within an interval
    /// </summary>
    /// <typeparam name="T">The value domain</typeparam>
    [DataTypeAttributeD("bin<t:{0}>")]
    public struct Bin<T>
        where T : unmanaged, IEquatable<T>, IComparable<T>
    {
        internal int Counter;

        public T Min {get;}

        public T Max {get;}

        [MethodImpl(Inline)]
        public Bin(in ClosedInterval<T> domain, uint count = 0)
        {
            Min = domain.Min;
            Max = domain.Max;
            Counter = (int)count;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Counter;
        }

        public string Format()
            => string.Format("{0:D6}:[{1},{2}]", Counter, Min, Max);

        [MethodImpl(Inline)]
        public Bin<T> Increment()
            => gcalc.next(ref this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static Bin<T> operator ++(in Bin<T> src)
            => src.Increment();
    }
}