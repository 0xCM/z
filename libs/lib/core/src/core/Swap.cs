//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Swaps;

    /// <summary>
    /// Defines a transposition, i.e. a specification for a two-element position exchange
    /// Typically denoted by an ordered pair of space-delimited indices (i j)
    /// </summary>
    public struct Swap
    {
        /// <summary>
        /// The first index
        /// </summary>
        public int i;

        /// <summary>
        /// The second index
        /// </summary>
        public int j;

        [MethodImpl(Inline)]
        public Swap((int i, int j) src)
        {
            i = src.i;
            j = src.j;
        }

        [MethodImpl(Inline)]
        public Swap(int i, int j)
        {
            this.i = i;
            this.j = j;
        }

        /// <summary>
        /// Renders the tranposition as text in canonical form
        /// </summary>
        [MethodImpl(Inline), Op]
        public string Format()
            => api.format(this);

        public bool IsEmpty
        {
            [MethodImpl(Inline), Op]
            get => i == Empty.i && j == Empty.j;
        }

        /// <summary>
        /// Determines whether this transposition is identical to another.
        /// Note that the order of indices is immaterial
        /// </summary>
        /// <param name="rhs">The right transposition</param>
        [MethodImpl(Inline), Op]
        public bool Equals(Swap rhs)
            => (i == rhs.i && j == rhs.j) || (i == rhs.j && j == rhs.i);

        [MethodImpl(Inline)]
        public void Deconstruct(out int i, out int j)
        {
            i = this.i;
            j = this.j;
        }

        /// <summary>
        /// Creates a copy
        /// </summary>
        [MethodImpl(Inline)]
        public Swap Replicate()
            => (i,j);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => HashCode.Combine(i,j);

        public override bool Equals(object o)
            => o is Swap x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator Swap((int i, int j) src)
            => new Swap(src);

        [MethodImpl(Inline)]
        public static implicit operator (int i, int j)(Swap src)
            => (src.i, src.j);

        [MethodImpl(Inline)]
        public static Swap operator ++(Swap src)
            => api.inc(ref src);

        [MethodImpl(Inline)]
        public static Swap operator --(Swap src)
            => api.dec(ref src);

        [MethodImpl(Inline)]
        public static bool operator ==(Swap lhs, Swap rhs)
            => lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static bool operator !=(Swap lhs, Swap rhs)
            => !(lhs == rhs);

        /// <summary>
        /// The monodial zero
        /// </summary>
        public static Swap Zero => new Swap(0,0);

        /// <summary>
        /// The empty element, which is not Zero
        /// </summary>
        public static Swap Empty => new Swap(-1,-1);
    }
}