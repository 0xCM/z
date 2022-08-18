//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines mod/div operations
    /// </summary>
    /// <remarks>See https://arxiv.org/pdf/1902.01961.pdf</remarks>
     public record struct Mod
     {
        readonly ulong M;

        /// <summary>
        /// Specifies the divisor for which the modulus was constructed
        /// </summary>
        public readonly uint n;

        uint state;

        /// <summary>
        /// The maximum state value
        /// </summary>
        readonly uint stateMax;

        /// <summary>
        /// Constructs a modulus operator with a persistent type-natural divisor
        /// </summary>
        /// <param name="n">The divisor</param>
        [MethodImpl(Inline)]
        public static Mod<N> Define<N>(N n = default)
            where N : unmanaged, ITypeNat
                => new Mod<N>();

        [MethodImpl(Inline)]
        public static Mod<N> Define<N>(uint state, N n = default)
            where N : unmanaged, ITypeNat
                => Mod<N>.Define(state);

        /// <summary>
        /// Constructs a modulus operator with a persistent divisor
        /// </summary>
        /// <param name="n">The divisor</param>
        [MethodImpl(Inline)]
        public static Mod Define(uint n, uint state)
            => new Mod(n,state);

        [MethodImpl(Inline)]
        Mod(uint n, uint state)
        {
            this.n = n;
            this.M = UInt64.MaxValue / n + 1;
            this.state = state;
            this.stateMax = n - 1;
        }

        /// <summary>
        /// Computes a % n
        /// </summary>
        /// <param name="a">The dividend</param>
        [MethodImpl(Inline)]
        public uint mod(uint a)
            => (uint) ModOps.mulhi(M * a, n);

        /// <summary>
        /// Computes the quotient a / n
        /// </summary>
        /// <param name="a">The dividend</param>
        [MethodImpl(Inline)]
        public uint div(uint a)
            => (uint) ModOps.mulhi(M, a);

        /// <summary>
        /// Computes the quotient and remainder
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="rem">The remainder</param>
        [MethodImpl(Inline)]
        public uint divrem(uint a, out uint rem)
        {
            rem = mod(a);
            return div(a);
        }

        /// <summary>
        /// Computes whether a % n == 0
        /// </summary>
        /// <param name="a">The dividend</param>
        [MethodImpl(Inline)]
        public bool divisible(uint a)
            => a * M <= M - 1;

        [MethodImpl(Inline)]
        public string Format()
            => $"{state}(mod {n})";

        public override int GetHashCode()
            => (int)(state | n);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static Mod operator +(Mod lhs, Mod rhs)
            => Define(lhs.n, lhs.state + rhs.state);

        [MethodImpl(Inline)]
        public static Mod operator *(Mod lhs, Mod rhs)
            => Define(lhs.n, lhs.state * rhs.state);

        /// <summary>
        /// Increments the source operand in-place
        /// </summary>
        /// <param name="src">The source operand</param>
        [MethodImpl(Inline)]
        public static Mod operator ++(Mod src)
        {
            if(src.state == src.stateMax)
            {
                src.state = 0;
                return src;
            }
            else
            {
                ++src.state;
                return src;
            }
        }

        /// <summary>
        /// Decrements the source operand in-place
        /// </summary>
        /// <param name="src">The source operand</param>
        [MethodImpl(Inline)]
        public static Mod operator --(Mod src)
        {
            if(src.state == 0u)
                src.state = src.stateMax;
            else
                --src.state;
            return src;
        }
    }
}