//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Numeric;

    /// <summary>
    /// Defines a transposition in the context of a permutation of natural length
    /// </summary>
    public struct NatSwap<N,T>
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        /// <summary>
        /// The first index
        /// </summary>
        Mod<N> I;

        /// <summary>
        /// The second index
        /// </summary>
        Mod<N> J;

        [MethodImpl(Inline)]
        public NatSwap((int i, int j) src)
        {
            I = src.i;
            J = src.j;
        }

        [MethodImpl(Inline)]
        public NatSwap((T i, T j) src)
        {
            I = force<T,uint>(src.i);
            J = force<T,uint>(src.j);
        }

        [MethodImpl(Inline)]
        NatSwap(Mod<N> i, Mod<N> j)
        {
            this.I = i;
            this.J = j;
        }

        /// <summary>
        /// Renders the tranposition as text in canonical form
        /// </summary>
        public string Format()
            => $"({I} {J})";

        public bool IsEmpy
            => I == Zero.I && J == Zero.J;

        /// <summary>
        /// Determines whether this transposition is identical to another.
        /// Note that the order of indices is immaterial
        /// </summary>
        /// <param name="rhs">The right transposition</param>
        [MethodImpl(Inline)]
        public bool Equals(NatSwap<N,T> rhs)
            => (I == rhs.I && J == rhs.J) || (I == rhs.J && J == rhs.I);

        [MethodImpl(Inline)]
        public void Deconstruct(out T i, out T j)
        {
            i = force<T>(this.I.State);
            j = force<T>(this.J.State);
        }

        /// <summary>
        /// Converts the transpostion to its canonical tuple representation
        /// </summary>
        /// <param name="i">The first term index</param>
        /// <param name="j">The second term index</param>
        [MethodImpl(Inline)]
        public (T i, T j) ToTuple()
            => (force<T>(I.State), force<T>(J.State));

        /// <summary>
        /// Creates a copy
        /// </summary>
        [MethodImpl(Inline)]
        public NatSwap<N,T> Replicate()
            => new NatSwap<N,T>(I,J);


        /// <summary>
        /// The monodial zero
        /// </summary>
        public static NatSwap<N,T> Zero => default;

        /// <summary>
        /// Creates a chain of transpositions, that includes the initial transposition
        /// </summary>
        /// <param name="t0">The leading transposition</param>
        /// <param name="len">The length of the chain</param>
        public static NatSwap<N,T>[] Chain(NatSwap<N,T> t0, int len)
        {
            var dst = new NatSwap<N,T>[len];
            dst[0]  = t0;
            for(var k = 1; k < len; k++)
                dst[k] = ++t0;
            return dst;
        }

        /// <summary>
        /// Converts a tuple representation to a swap
        /// </summary>
        /// <param name="i">The first term index</param>
        /// <param name="j">The second term index</param>
        [MethodImpl(Inline)]
        public static NatSwap<N,T> FromTuple((T i, T j) src)
            => new NatSwap<N,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator NatSwap<N,T>((T i, T j) src)
            => FromTuple(src);

        /// <summary>
        /// Implicitly converts the transpostion to its unsized representation
        /// </summary>
        /// <param name="i">The first term index</param>
        /// <param name="j">The second term index</param>
        [MethodImpl(Inline)]
        public static implicit operator Swap<T>(NatSwap<N,T> src)
            => new Swap<T>(src.ToTuple());

        /// <summary>
        /// Implicitly converts the transpostion to its canonical tuple representation
        /// </summary>
        /// <param name="i">The first term index</param>
        /// <param name="j">The second term index</param>
        [MethodImpl(Inline)]
        public static implicit operator (T i, T j)(NatSwap<N,T> src)
            => src.ToTuple();

        [MethodImpl(Inline)]
        public static implicit operator Swap(NatSwap<N,T> src)
            => (src.I, src.J);

        [MethodImpl(Inline)]
        public static NatSwap<N,T> operator ++(in NatSwap<N,T> src)
        {
            ref var dst = ref edit(src);
            dst.I++;
            dst.J++;
            return dst;
        }

        [MethodImpl(Inline)]
        public static NatSwap<N,T> operator --(in NatSwap<N,T> src)
        {
            ref var dst = ref edit(src);
            if(src.I != 0)
                dst.I--;
            if(src.J != 0)
                --dst.J;
            return dst;
        }

        [MethodImpl(Inline)]
        public static bool operator ==(NatSwap<N,T> lhs, NatSwap<N,T> rhs)
            => lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static bool operator !=(NatSwap<N,T> lhs, NatSwap<N,T> rhs)
            => !(lhs == rhs);

        public override int GetHashCode()
            => throw new NotSupportedException();

        public override bool Equals(object o)
            => throw new NotSupportedException();
    }
}