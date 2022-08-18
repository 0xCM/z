//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    /// <summary>
    /// Contains a finite set of values
    /// </summary>
    public readonly struct ConstSet<T> : IConstSet<ConstSet<T>,T>
    {
        readonly HashSet<T> Data;

        [MethodImpl(Inline)]
        public ConstSet(IEnumerable<T> src)
            => Data = hashset(src);

        [MethodImpl(Inline)]
        public ConstSet(HashSet<T> src)
            => Data = src;

        [MethodImpl(Inline)]
        public ConstSet(T[] src)
            => Data = hashset(src);

        public IEnumerable<T> Next()
            => Data;

        [MethodImpl(Inline)]
        public static implicit operator ConstSet<T>(HashSet<T> src)
            => new ConstSet<T>(src);

        [MethodImpl(Inline)]
        public static bool operator <(ConstSet<T> a, ConstSet<T> b)
            => b.IsSuperset(a, true);

        [MethodImpl(Inline)]
        public static bool operator >(ConstSet<T> a, ConstSet<T> b)
            => a.IsSuperset(b, true);

        [MethodImpl(Inline)]
        public static bool operator <=(ConstSet<T> a, ConstSet<T> b)
            => b.IsSuperset(a, false);

        [MethodImpl(Inline)]
        public static bool operator >=(ConstSet<T> a, ConstSet<T> b)
            => a.IsSuperset(b, false);

        public static bool operator <(T a, ConstSet<T> b)
            => b.Contains(a);

        [MethodImpl(Inline)]
        public static bool operator >(T a, ConstSet<T> b)
            => b.Contains(a) && b.Count == 1;

        [MethodImpl(Inline)]
        public static bool operator ==(ConstSet<T> a, ConstSet<T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(ConstSet<T> a, ConstSet<T> b)
            => !a.Equals(b);

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Count;
        }

        public HashSet<T> Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Count == 0;
        }

        [MethodImpl(Inline)]
        public bool Contains(T candidate)
            => Data.Contains(candidate);

        [MethodImpl(Inline)]
        public bool IsMember(object candidate)
            => candidate is T ? Contains((T)candidate) :false;

        /// <summary>
        /// Determines whether the current set is a subset of a specified set.
        /// </summary>
        /// <param name="rhs">The candidate superset</param>
        /// <param name="proper">Specifies whether only proper subsets are considered "subsets"</param>
        [MethodImpl(Inline)]
        public bool IsSubset(ConstSet<T> rhs, bool proper = true)
            => proper ? Data.IsProperSubsetOf(rhs.Data) : Data.IsSubsetOf(rhs.Data);

        /// <summary>
        /// Determines whether the current set is a superset of a specified set.
        /// </summary>
        /// <param name="rhs">The candidate subset</param>
        /// <param name="proper">Specifies whether only proper subsets are considered "subsets"</param>
        [MethodImpl(Inline)]
        public bool IsSuperset(ConstSet<T> rhs, bool proper)
            => proper ? Data.IsProperSupersetOf(rhs.Data) : Data.IsSubsetOf(rhs.Data);

        /// <summary>
        /// Calculates the union between the current set and a specified set and returns a new set that embodies this result
        /// </summary>
        /// <param name="src">The set with which to union/param>
        [MethodImpl(Inline)]
        public void Union(HashSet<T> dst)
        {
            dst.UnionWith(Data);
        }

        /// <summary>
        /// Calculates the intersection between the current set and a specified set and
        /// returns a new set that embodies this result
        /// </summary>
        /// <param name="src">The set with which to intersect</param>
        [MethodImpl(Inline)]
        public void Intersect(HashSet<T> dst)
        {
            dst.IntersectWith(Data);
        }

        /// <summary>
        /// Calculates the set difference, or symmetric difference, between the current set and a specified set
        /// and returns a new set that embodies this result
        /// </summary>
        /// <param name="src">The set that should be differenced</param>
        /// <remarks>See https://en.wikipedia.org/wiki/Symmetric_difference</remarks>
        [MethodImpl(Inline)]
        public void Difference(HashSet<T> dst, bool symmetric)
        {
            if(symmetric)
                dst.SymmetricExceptWith(Data);
            else
                dst.ExceptWith(Data);
        }

        /// <summary>
        /// Determine whether the current set and a specified set have a nonemtpy intersection
        /// </summary>
        /// <param name="rhs">The set to compare</param>
        [MethodImpl(Inline)]
        public bool Intersects(ConstSet<T> rhs)
            => Data.Overlaps(rhs.Data);

        static IEqualityComparer<HashSet<T>> Comparer
            => HashSet<T>.CreateSetComparer();

        [MethodImpl(Inline)]
        public bool Equals(ConstSet<T> src)
            => Comparer.Equals(Data, src.Data);

        public override bool Equals(object obj)
            => obj is ConstSet<T> x && Equals(x);

        public override int GetHashCode()
            => Data.GetHashCode();
    }
}