//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static gmath;
    using static BitMaskLiterals;

    [ApiHost,Free]
    public partial class ScalarBits
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Defines a bitvector of natural width
        /// </summary>
        /// <param name="n">The width selector</param>
        /// <param name="a">The scalar source data</param>
        /// <typeparam name="N">The width type</typeparam>
        /// <typeparam name="T">The scalar type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> natural<N,T>(N n, T a)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new ScalarBits<N,T>(a);

        /// <summary>
        /// Defines a bitvector of natural width
        /// </summary>
        /// <param name="n">The width selector</param>
        /// <param name="a">The scalar source data</param>
        /// <typeparam name="N">The width type</typeparam>
        /// <typeparam name="T">The scalar type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> natural<N,T>(T a)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new ScalarBits<N,T>(a);

        /// <summary>
        /// Creates a vector from a bitstring
        /// </summary>
        /// <param name="src">The source bitstring</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> natural<N,T>(BitString src, N n = default, T t = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => SeqPack.packseq(src.Slice(0, Typed.nat32i(n)).BitSeq, out T _);

        /// <summary>
        /// Creates a bitvector with uniformly alternating states where the state of
        /// the first bit is determine by a parity bit
        /// </summary>
        /// <param name="parity">The state of the first bit</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarBits<T> alt<T>(bit parity)
            where T : unmanaged
                => parity ? generic<T>(Even64) : generic<T>(Odd64);

        /// <summary>
        /// Creates a bitvector with uniformly alternating states where the state of
        /// the first bit is determined by a parity bit
        /// </summary>
        /// <param name="parity">The state of the first bit</param>
        /// <param name="n">The width selector</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> alt<N,T>(bit parity, N n = default)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => natural<N,T>(parity ? generic<T>(Even64) : generic<T>(Odd64));

        /// <summary>
        /// Computes the Euclidean scalar product between two bitvectors using modular arithmetic
        /// </summary>
        /// <param name="x">The first vector</param>
        /// <param name="y">The second vector</param>
        /// <remarks>This should be considered a reference implementation; the dot operation is considerably faster</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit modprod<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
        {
            var result = 0;
            for(var i=0; i<x.Width; i++)
            {
                var a = x[i] ? 1 : 0;
                var b = y[i] ? 1 : 0;
                result += a*b;
            }
            return gmath.odd(result);
        }

        /// <summary>
        /// Computes the Euclidean scalar product between two bitvectors using modular arithmetic
        /// </summary>
        /// <param name="x">The first vector</param>
        /// <param name="y">The second vector</param>
        /// <remarks>This should be considered a reference implementation; the dot operation is considerably faster</remarks>
        [MethodImpl(Inline)]
        public static bit modprod<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
        {
            var result = 0u;
            for(var i=0; i<x.Width; i++)
                result += ((uint)x[i]*(uint)y[i]);
            return gmath.odd(result);
        }
        /// <summary>
        /// Allocates a natural bitvector
        /// </summary>
        /// <param name="n">The number of bits to store</param>
        /// <typeparam name="T">The primal storage type</typeparam>
        [MethodImpl(Inline), Alloc]
        public static ScalarBits<N,T> alloc<N,T>(N n = default, T fill = default)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => new ScalarBits<N,T>(fill);

        /// <summary>
        /// Allocates a generic bitvector
        /// </summary>
        /// <param name="n">The number of bits to store</param>
        /// <typeparam name="T">The primal storage type</typeparam>
        [MethodImpl(Inline), Alloc, Closures(Closure)]
        public static ScalarBits<T> alloc<T>(T fill = default)
            where T : unmanaged
                => load(fill);
        /// <summary>
        /// Computes the bitwise ternary select for bitvector operands
        /// </summary>
        /// <param name="x">The pivot/mask vector</param>
        /// <param name="y">The primary choice</param>
        /// <param name="z">The alternative choice</param>
        [MethodImpl(Inline), Select, Closures(Closure)]
        public static ScalarBits<T> select<T>(ScalarBits<T> x, ScalarBits<T> y, ScalarBits<T> z)
            where T : unmanaged
                => gbits.select(x.State, y.State, z.State);

        /// <summary>
        /// Computes the bitvector z := x ^ y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> select<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y, ScalarBits<N,T> z)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.select(x.State, y.State, z.State);

        /// <summary>
        /// Creates a generic bitvector
        /// </summary>
        /// <param name="src">The source cell</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarBits<T> load<T>(T src)
            where T : unmanaged
                => new ScalarBits<T>(src);

        /// <summary>
        /// Creates a generic bitvector from a span of bytes
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="n">The bitvector length</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarBits<T> load<T>(Span<byte> src)
            where T : unmanaged
                => load(src.Take<T>());

        /// <summary>
        /// Loads an bitvector of minimal size from a source bitstring
        /// </summary>
        /// <param name="src">The bitstring source</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarBits<T> load<T>(BitString src)
            where T : unmanaged
                => load<T>(src.ToPackedBytes());

        /// <summary>
        /// Creates a byte-generic bitvector
        /// </summary>
        [MethodImpl(Inline), Op]
        public static ScalarBits<byte> load(N8 n8, byte a)
            => a;

        /// <summary>
        /// Creates a byte-generic bitvector from 4 explicit bytes
        /// </summary>
        /// <param name="src">The source bitstring</param>
        [MethodImpl(Inline), Op]
        public static ScalarBits<uint> load(byte x0, byte x1, byte x2, byte x3)
            => load(bits.join(x0,x1,x2,x3));        

        /// <summary>
        /// Arithmetically decrements the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarBits<T> dec<T>(ScalarBits<T> x)
            where T : unmanaged
                => gmath.dec(x.State);

        /// <summary>
        /// Arithmetically decrements the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> dec<N,T>(ScalarBits<N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.dec(x.State);

        /// <summary>
        /// Computes the arithmetic sum z := x + y for generic bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarBits<T> add<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => gmath.add(x.State, y.State);

        /// <summary>
        /// Computes the bitvector z := x & y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), And, Closures(Closure)]
        public static ScalarBits<T> and<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => gmath.and(x.State, y.State);

        /// <summary>
        /// Computes the bitvector z := x & y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> and<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.and(x.State, y.State);


        [MethodImpl(Inline), CImpl, Closures(Closure)]
        public static ScalarBits<T> cimpl<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => gbits.cimpl(x.State, y.State);

        /// <summary>
        /// Computes the converse nonimplication, z := x & ~y, for bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), CNonImpl, Closures(Closure)]
        public static ScalarBits<T> cnonimpl<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => gmath.cnonimpl(x.State, y.State);

        /// <summary>
        /// Computes the converse nonimplication, z := x & ~y, for bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> cnonimpl<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.cnonimpl(x.State, y.State);                

        /// <summary>
        /// Disables a bit if it is enabled
        /// </summary>
        /// <param name="pos">The position of the bit to disable</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarBits<T> disable<T>(ScalarBits<T> x, int pos)
            where T : unmanaged
                => gbits.disable(x.State, (byte)pos);

        /// <summary>
        /// Disables a bit if it is enabled
        /// </summary>
        /// <param name="pos">The position of the bit to disable</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> disable<N,T>(ScalarBits<N,T> x, int pos)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.disable(x.State, (byte)pos);

        /// <summary>
        /// Computes the parity of a generic bitvector, which is 1 if an odd number of its components are enabled and 0 otherwise
        /// </summary>
        /// <remarks>
        /// The parity function p:{0,1}x...x{0,1} -> {0,1} is a boolean function that attains the
        /// value 1 when an odd number of its input values are 1 and 0 otherwise.
        /// </remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit parity<T>(ScalarBits<T> src)
            where T : unmanaged
                => odd(gbits.pop(src.State));

        /// <summary>
        /// Computes the parity of a natural bitvector, which is 1 if an odd number of its components are enabled and 0 otherwise
        /// </summary>
        /// <remarks>
        /// The parity function p:{0,1}x...x{0,1} -> {0,1} is a boolean function that attains the
        /// value 1 when an odd number of its input values are 1 and 0 otherwise.
        /// </remarks>
        [MethodImpl(Inline)]
        public static bit parity<N,T>(ScalarBits<N,T> src)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => odd(gbits.pop(src.State));


        /// <summary>
        /// Computes the scalar product between two bitvectors
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Dot, Closures(Closure)]
        public static bit dot<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => parity(and(x,y));

        /// <summary>
        /// Computes the scalar product between two bitvectors
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline)]
        public static bit dot<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => parity(and(x,y));            
    }
}
