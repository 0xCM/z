//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a transposition in the context of a permutation of natural length
    /// </summary>
    public struct NatSwap<N>
        where N : unmanaged, ITypeNat
    {
        /// <summary>
        /// The first index
        /// </summary>
        Mod<N> i;

        /// <summary>
        /// The second index
        /// </summary>
        Mod<N> j;

        /// <summary>
        /// The empty element
        /// </summary>
        public static NatSwap<N> Empty => (-1,-1);

        /// <summary>
        /// The monodial zero
        /// </summary>
        public static NatSwap<N> Zero => (0,0);

        /// <summary>
        /// Creates a chain of transpositions, that includes the initial transposition
        /// </summary>
        /// <param name="s0">The leading transposition</param>
        /// <param name="len">The length of the chain</param>
        public static NatSwap<N>[] Chain(NatSwap<N> s0, int len)
        {
            var dst = new NatSwap<N>[len];
            dst[0]  = s0;
            for(var k = 1; k < len; k++)
                dst[k] = ++s0;
            return dst;
        }

        /// <summary>
        /// Parses a transposition in canonical form (i j), if possible; otherwise
        /// returns the empty transposition
        /// </summary>
        /// <param name="src">The source text</param>
        public static NatSwap<N> Parse(string src)
        {
            var indices = src.RemoveAny(Chars.LParen, Chars.RParen).Trim().Split(Chars.Space);
            if(indices.Length != 2)
                return Empty;

            var result = Option.Try(() => (Int32.Parse(indices[0]), Int32.Parse(indices[1])));
            if(result.IsSome())
                return result.Value();
            else
                return Empty;
        }

        [MethodImpl(Inline)]
        public static implicit operator NatSwap<N>((int i, int j) src)
            => new NatSwap<N>(src);

        [MethodImpl(Inline)]
        public static implicit operator (int i, int j)(NatSwap<N> src)
            => (src.i, src.j);

        [MethodImpl(Inline)]
        public static implicit operator Swap(NatSwap<N> src)
            => (src.i, src.j);

        [MethodImpl(Inline)]
        public static NatSwap<N> operator ++(in NatSwap<N> src)
        {
            ref var dst = ref edit(src);
            dst.i++;
            dst.j++;
            return dst;
        }

        [MethodImpl(Inline)]
        public static NatSwap<N> operator --(in NatSwap<N> src)
        {
            ref var dst = ref edit(src);
            if(src.i != 0)
                dst.i--;
            if(src.j != 0)
                --dst.j;
            return dst;
        }

        [MethodImpl(Inline)]
        public static bool operator ==(NatSwap<N> lhs, NatSwap<N> rhs)
            => lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static bool operator !=(NatSwap<N> lhs, NatSwap<N> rhs)
            => !(lhs == rhs);

        [MethodImpl(Inline)]
        public NatSwap((int i, int j) src)
        {
            this.i = src.i;
            this.j = src.j;
        }

        [MethodImpl(Inline)]
        public NatSwap(int i, int j)
        {
            this.i = i;
            this.j = j;
        }

        /// <summary>
        /// Renders the tranposition as text in canonical form
        /// </summary>
        public string Format()
            => $"({i} {j})";

        public bool IsEmpy
            => i == Empty.i && j == Empty.j;

        /// <summary>
        /// Determines whether this transposition is identical to another.
        /// Note that the order of indices is immaterial
        /// </summary>
        /// <param name="rhs">The right transposition</param>
        [MethodImpl(Inline)]
        public bool Equals(NatSwap<N> rhs)
            => (i == rhs.i && j == rhs.j) || (i == rhs.j && j == rhs.i);

        [MethodImpl(Inline)]
        public void Deconstruct(out int i, out int j)
        {
            i = this.i;
            j = this.j;
        }

        [MethodImpl(Inline)]
        public void Deconstruct<T>(out T i, out T j)
            where T : unmanaged
        {
            (i,j) = ToTuple<T>();
        }

        [MethodImpl(Inline)]
        public (int i, int j) ToTuple()
            => (i, j);

        [MethodImpl(Inline)]
        public (T i, T j) ToTuple<T>()
            where T : unmanaged
                => (Numeric.force<T>(i), Numeric.force<T>(j));

        /// <summary>
        /// Creates a copy
        /// </summary>
        [MethodImpl(Inline)]
        public NatSwap<N> Replicate()
            => (i,j);

        public override int GetHashCode()
            => throw new NotSupportedException();

        public override bool Equals(object o)
            => throw new NotSupportedException();
    }
}