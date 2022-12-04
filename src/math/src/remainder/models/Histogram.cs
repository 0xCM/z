//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct Histogram<T>
        where T : unmanaged, IEquatable<T>, IComparable<T>
    {
        public ClosedInterval<T> Domain {get;}

        public T Grain {get;}

        public Index<T> Partitions {get;}

        public Index<uint> Counts;

        [MethodImpl(Inline)]
        internal Histogram(in ClosedInterval<T> domain, T grain,  T[] partitions, uint[] counts)
        {
            Domain = domain;
            Grain = grain;
            Partitions = partitions;
            Counts = counts;
        }

        [MethodImpl(Inline)]
        public void Deposit(ReadOnlySpan<T> points)
            => gcalc.deposit(points, this);

        [MethodImpl(Inline)]
        public uint BinCount(uint index)
            => gcalc.count(this, index);
    }
}