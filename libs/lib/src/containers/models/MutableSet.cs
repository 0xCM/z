//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Encloses a finite set of structural values
    /// </summary>
    public class MutableSet<T> : ISet<MutableSet<T>,T>, IEquatable<MutableSet<T>>, ISet<T>
    {
        readonly HashSet<T> Data;

        public MutableSet()
        {
            Data = new();
        }

        public MutableSet(IEnumerable<T> src)
            => Data = hashset(src);

        public MutableSet(HashSet<T> src)
            => Data = src;

        public MutableSet(T[] src)
            => Data = hashset(src);

        public IEnumerable<T> Next()
            => Data;

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Count;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Count == 0;
        }

        [MethodImpl(Inline)]
        public bool IsSubset(MutableSet<T> src, bool proper)
            => proper ? Data.IsProperSubsetOf(src.Data) : Data.IsSubsetOf(src.Data);

        [MethodImpl(Inline)]
        public bool IsSuperset(MutableSet<T> src, bool proper)
             => proper ? Data.IsProperSupersetOf(src.Data) : Data.IsSupersetOf(src.Data);

        [MethodImpl(Inline)]
        public MutableSet<T> Union(params T[] src)
        {
            Data.UnionWith(src);
            return this;
        }

        [MethodImpl(Inline)]
        public MutableSet<T> Union(MutableSet<T> src)
        {
            Data.UnionWith(src.Data);
            return this;
        }

        /// <summary>
        /// Determine whether the current set and a specified set have a nonemtpy intersection
        /// </summary>
        /// <param name="rhs">The set to compare</param>
        [MethodImpl(Inline)]
        public bool Intersects(in MutableSet<T> rhs)
            => Data.Overlaps(rhs.Data);

        /// <summary>
        /// Calculates the intersection between the current set and a specified set and
        /// returns a new set that embodies this result
        /// </summary>
        /// <param name="src">The set with which to intersect</param>
        [MethodImpl(Inline)]
        public MutableSet<T> Intersect(in MutableSet<T> src)
        {
            Data.IntersectWith(src.Data);
            return this;
        }

        [MethodImpl(Inline)]
        public MutableSet<T> Intersect(MutableSet<T> src)
        {
            Data.IntersectWith(src.Data);
            return this;
        }

        [MethodImpl(Inline)]
        public bool Contains(in T candidate)
            => Data.Contains(candidate);

        [MethodImpl(Inline)]
        public bool Contains(T candidate)
            => Data.Contains(candidate);

        /// <summary>
        /// Calculates the set difference, or symmetric difference, between the current set and a specified set
        /// and returns a new set that embodies this result
        /// </summary>
        /// <param name="src">The set that should be differenced</param>
        /// <remarks>See https://en.wikipedia.org/wiki/Symmetric_difference</remarks>
        [MethodImpl(Inline)]
        public MutableSet<T> Difference(MutableSet<T> src, bool symmetric)
        {
            if(symmetric)
                Data.SymmetricExceptWith(src.Data);
            else
                Data.ExceptWith(src.Data);

            return this;
        }

         [MethodImpl(Inline)]
         public MutableSet<T> Difference(in MutableSet<T> src, bool symmetric)
         {
            if(symmetric)
                Data.SymmetricExceptWith(src.Data);
            else
                Data.ExceptWith(src.Data);

            return this;
        }

        static IEqualityComparer<HashSet<T>> Comparer
            => HashSet<T>.CreateSetComparer();

        int ICollection<T>.Count
            => ((ICollection<T>)Data).Count;

        public bool IsReadOnly
            => false;

        [MethodImpl(Inline)]
        public bool Equals(MutableSet<T> src)
            => Comparer.Equals(Data, src.Data);

        public override bool Equals(object obj)
            => obj is MutableSet<T> x && Equals(x);

        public override int GetHashCode()
            => Data.GetHashCode();

        bool ISet<T>.Add(T item)
            => ((ISet<T>)Data).Add(item);

        void ISet<T>.ExceptWith(IEnumerable<T> other)
            => ((ISet<T>)Data).ExceptWith(other);

        void ISet<T>.IntersectWith(IEnumerable<T> other)
            => ((ISet<T>)Data).IntersectWith(other);

        bool ISet<T>.IsProperSubsetOf(IEnumerable<T> other)
            => ((ISet<T>)Data).IsProperSubsetOf(other);

        bool ISet<T>.IsProperSupersetOf(IEnumerable<T> other)
            => ((ISet<T>)Data).IsProperSupersetOf(other);
        bool ISet<T>.IsSubsetOf(IEnumerable<T> other)
        {
            return ((ISet<T>)Data).IsSubsetOf(other);
        }

        bool ISet<T>.IsSupersetOf(IEnumerable<T> other)
        {
            return ((ISet<T>)Data).IsSupersetOf(other);
        }

        bool ISet<T>.Overlaps(IEnumerable<T> other)
        {
            return ((ISet<T>)Data).Overlaps(other);
        }

        bool ISet<T>.SetEquals(IEnumerable<T> other)
        {
            return ((ISet<T>)Data).SetEquals(other);
        }

        void ISet<T>.SymmetricExceptWith(IEnumerable<T> other)
        {
            ((ISet<T>)Data).SymmetricExceptWith(other);
        }

        void ISet<T>.UnionWith(IEnumerable<T> other)
        {
            ((ISet<T>)Data).UnionWith(other);
        }

        void ICollection<T>.Add(T item)
        {
            ((ICollection<T>)Data).Add(item);
        }

        public void Clear()
        {
            ((ICollection<T>)Data).Clear();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((ICollection<T>)Data).CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return ((ICollection<T>)Data).Remove(item);
        }

        [MethodImpl(Inline)]
        public static implicit operator MutableSet<T>(HashSet<T> src)
            => new MutableSet<T>(src);

        [MethodImpl(Inline)]
        public static MutableSet<T> operator +(MutableSet<T> a, MutableSet<T> b)
            => a.Union(b);

        [MethodImpl(Inline)]
        public static MutableSet<T> operator -(MutableSet<T> a, MutableSet<T> b)
            => a.Difference(b,false);

        [MethodImpl(Inline)]
        public static MutableSet<T> operator *(MutableSet<T> a, MutableSet<T> b)
            => a.Intersect(b);

        [MethodImpl(Inline)]
        public static bool operator <(MutableSet<T> a, MutableSet<T> b)
            => b.IsSuperset(a, true);

        [MethodImpl(Inline)]
        public static bool operator >(MutableSet<T> a, MutableSet<T> b)
            => a.IsSuperset(b, true);

        [MethodImpl(Inline)]
        public static bool operator <=(MutableSet<T> a, MutableSet<T> b)
            => b.IsSuperset(a, false);

        [MethodImpl(Inline)]
        public static bool operator >=(MutableSet<T> a, MutableSet<T> b)
            => a.IsSuperset(b, false);

        public static bool operator <(T a, MutableSet<T> b)
            => b.Contains(a);

        [MethodImpl(Inline)]
        public static bool operator >(T a, MutableSet<T> b)
            => b.Contains(a) && b.Count == 1;

        [MethodImpl(Inline)]
        public static bool operator ==(MutableSet<T> a, MutableSet<T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(MutableSet<T> a, MutableSet<T> b)
            => !a.Equals(b);
    }
}