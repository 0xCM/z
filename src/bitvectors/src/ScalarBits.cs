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
        /// Defines the bitwise RightNot operator
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        [MethodImpl(Inline), RNot, Closures(Closure)]
        public static ScalarBits<T> rnot<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => ~y;

        /// <summary>
        /// Reverses the bits in the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> reverse<N,T>(ScalarBits<N,T> src)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.srl(gbits.reverse(src.State), (byte)(sys.width<T>() - src.Width));

        /// <summary>
        /// Reverses the bits in the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Reverse, Closures(Closure)]
        public static ScalarBits<T> reverse<T>(ScalarBits<T> x)
            where T : unmanaged
                => gbits.reverse(x.State);

        /// <summary>
        /// Extracts the represented data as a bitstring truncated to a specified width
        /// </summary>
        [MethodImpl(Inline), Op]
        public static BitString bitstring<T>(ScalarBits<T> src, int width)
            where T : unmanaged
                => BitStrings.scalar<T>(src.State, width);

        /// <summary>
        /// Defines the bitwise LeftNot operator
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        [MethodImpl(Inline), LNot, Closures(Closure)]
        public static ScalarBits<T> lnot<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => ~x;
                
        /// <summary>
        /// Creates an N-bit vector directly from the source data, bypassing masked initialization
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        internal static ScalarBits<N,T> inject<N,T>(T src, N n = default)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => ScalarBits<N,T>.Inject(src);

        /// <summary>
        /// Extracts the represented data as a bitstring
        /// </summary>
        [MethodImpl(Inline), Op]
        public static BitString bitstring<T>(ScalarBits<T> src)
            where T : unmanaged
                => BitStrings.scalar<T>(src.State);

        /// <summary>
        /// Defines the bitwise LeftProject operator
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        [MethodImpl(Inline), LProject, Closures(Closure)]
        public static ScalarBits<T> left<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => x;

        /// <summary>
        /// Defines the bitwise RightProject operator
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        [MethodImpl(Inline), RProject, Closures(Closure)]
        public static ScalarBits<T> right<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => y;

        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="fmt">Optional formatting style</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string format<T>(ScalarBits<T> x, BitFormat? fmt = null)
            where T : unmanaged
                => bitstring(x).Format(fmt);

        /// <summary>
        /// Computes the two's complement bitvector z := ~x + 1 for a bitvector x
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Negate, Closures(Closure)]
        public static ScalarBits<T> negate<T>(ScalarBits<T> x)
            where T : unmanaged
                => gmath.negate(x.State);

        /// <summary>
        /// Computes the two's complement bitvector z := ~x + 1 for a bitvector x
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> negate<N,T>(ScalarBits<N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.negate(x.State);

        /// <summary>
        /// Computes z := ~(x & y) for bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Nand, Closures(Closure)]
        public static ScalarBits<T> nand<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => gmath.nand(x.State, y.State);

        /// <summary>
        /// Computes z := ~(x & y) for bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> nand<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.nand(x.State, y.State);

        /// <summary>
        /// Computes the bitvector z: = ~(x | y) from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        /// <typeparam name="T">The primal bitvector type</typeparam>
        [MethodImpl(Inline), Nor, Closures(Closure)]
        public static ScalarBits<T> nor<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => gmath.nor(x.State, y.State);

        /// <summary>
        /// Computes the bitvector z: = ~(x | y) from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        /// <typeparam name="T">The primal bitvector type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> nor<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.nor(x.State, y.State);

        /// <summary>
        /// Computes the material nonimplication, equivalent to the bitwise expression a & (~b) for operands a and b
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), NonImpl, Closures(Closure)]
        public static ScalarBits<T> nonimpl<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => gbits.nonimpl(x.State, y.State);

        /// <summary>
        /// Computes the material nonimplication, equivalent to the bitwise expression a & (~b) for operands a and b
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> nonimpl<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.nonimpl(x.State, y.State);

        /// <summary>
        /// Computes the bitwise FALSE operator
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        [MethodImpl(Inline), False, Closures(Closure)]
        public static ScalarBits<T> @false<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => default;

        /// <summary>
        /// Computes the material implication z := x | ~y for bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Impl, Closures(Closure)]
        public static ScalarBits<T> impl<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => gmath.impl(x.State, y.State);

        /// <summary>
        /// Computes the material implication z := x | ~y for bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> impl<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.impl(x.State, y.State);

        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline), TestC, Closures(Closure)]
        public static bit testc<T>(ScalarBits<T> src)
            where T : unmanaged
                => gmath.eq(gmath.and(Limits.maxval<T>(), src.State), Limits.maxval<T>());

        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline),TestC]
        public static bit testc<N,T>(ScalarBits<N,T> src, N n = default)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.eq(gmath.and(Limits.maxval<T>(), src.State), Limits.maxval<T>());


        /// <summary>
        /// Creates a copy of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Replicate, Closures(Closure)]
        public static ScalarBits<T> replicate<T>(ScalarBits<T> x)
            where T : unmanaged
                => x.State;

        /// <summary>
        /// Creates a copy of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> replicate<N,T>(ScalarBits<N,T> src)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => src.State;

        /// <summary>
        /// Returns a generic vector with all bits enabled
        /// </summary>
        /// <typeparam name="T">The primal type upon which the vector is predicated</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<T> ones<T>()
            where T : unmanaged
                => sys.ones<T>();

        /// <summary>
        /// Computes the bitwise TRUE operator
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        [MethodImpl(Inline), True, Closures(Closure)]
        public static ScalarBits<T> @true<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => ones<T>();

        /// <summary>
        /// Computes z := x >> s for a bitvector x and shift offset s
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="offset">The shift amount</param>
        [MethodImpl(Inline), Srl, Closures(Closure)]
        public static ScalarBits<T> srl<T>(ScalarBits<T> x, byte offset)
            where T : unmanaged
                => gmath.srl(x.State,offset);

        /// <summary>
        /// Computes z := x >> s for a bitvector x and shift offset s
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="offset">The shift amount</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> srl<N,T>(ScalarBits<N,T> x, byte offset)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.srl(x.State, offset);

        /// <summary>
        /// Determines whether an index-identified bit is enabled
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="index">The 0-based position to test</param>
        [MethodImpl(Inline), TestBit, Closures(Closure)]
        public static bit testbit<T>(ScalarBits<T> src, byte index)
            where T : unmanaged
                => gbits.test(src.State, index);

        /// <summary>
        /// Determines whether an index-identified bit is enabled
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="index">The 0-based position to test</param>
        [MethodImpl(Inline)]
        public static bit testbit<N,T>(ScalarBits<N,T> src, byte index)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.test(src.State, index);

        /// <summary>
        /// Initializes a generic bitvector with a supplied value
        /// </summary>
        /// <param name="src">The value used to initialize the bitvector</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarBits<T> init<T>(T src)
            where T : unmanaged
                => new ScalarBits<T>(src);

        /// <summary>
        /// Initializes a natural bitvector over a primal type
        /// </summary>
        /// <param name="src">The value used to initialize the bitvector</param>
        [MethodImpl(Inline)]
        public static ScalarBits<W,T> init<W,T>(T src, W w = default)
            where T : unmanaged
            where W : unmanaged, ITypeNat
                => new ScalarBits<W,T>(src);

        /// <summary>
        /// Arithmetically increments the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Inc, Closures(Closure)]
        public static ScalarBits<T> inc<T>(ScalarBits<T> x)
            where T : unmanaged
                => gmath.inc(x.State);

        /// <summary>
        /// Arithmetically increments the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> inc<N,T>(ScalarBits<N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.inc(x.State);

        /// <summary>
        /// Counts the number of trailing zero bits
        /// </summary>
        [MethodImpl(Inline), Nlz, Closures(Closure)]
        public static T ntz<T>(in ScalarBits<T> x)
            where T : unmanaged
                => gbits.ntz(x.State);

        /// <summary>
        /// Counts the number of trailing zero bits
        /// </summary>
        [MethodImpl(Inline)]
        public static T ntz<N,T>(in ScalarBits<N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.ntz(x.State);

        /// <summary>
        /// Counts the number of leading zero bits
        /// </summary>
        [MethodImpl(Inline), Nlz, Closures(Closure)]
        public static int nlz<T>(ScalarBits<T> x)
            where T : unmanaged
                => gbits.nlz(x.State);

        /// <summary>
        /// Counts the number of leading zero bits
        /// </summary>
        [MethodImpl(Inline)]
        public static int nlz<N,T>(ScalarBits<N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.nlz(x.State) - x.Width;

        /// <summary>
        /// Counts the number of enabled bits in the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Pop, Closures(Closure)]
        public static uint pop<T>(ScalarBits<T> src)
            where T : unmanaged
                => gbits.pop(src.State);

        /// <summary>
        /// Counts the number of enabled bits in the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static uint pop<N,T>(ScalarBits<N,T> src)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.pop(src.State);

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
        /// Computes z := x << s for a bitvector x and shift offset s
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="offset">The shift amount</param>
        [MethodImpl(Inline), Sll, Closures(Closure)]
        public static ScalarBits<T> sll<T>(ScalarBits<T> x, byte offset)
            where T : unmanaged
                => gmath.sll(x.State,offset);

        /// <summary>
        /// Computes z := x >> s for a bitvector x and shift offset s
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="offset">The shift amount</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> sll<N,T>(ScalarBits<N,T> x, byte offset)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.sll(x.State,offset);


        /// <summary>
        /// Computes the arithmetic difference z := x - y for generic bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Sub, Closures(Closure)]
        public static ScalarBits<T> sub<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => gmath.sub(x.State, y.State);

        /// <summary>
        /// Computes the bitvector z := ~(x ^ y) from bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> sub<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.sub(x.State, y.State);

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

        /// <summary>
        /// Enables a bit if it is disabled
        /// </summary>
        /// <param name="index">The position of the bit to enable</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarBits<T> enable<T>(ScalarBits<T> src, byte index)
            where T : unmanaged
                => gbits.enable(src.State, index);

        /// <summary>
        /// Enables a bit if it is disabled
        /// </summary>
        /// <param name="index">The position of the bit to enable</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> enable<N,T>(ScalarBits<N,T> src, byte index)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.enable(src.State, index);


        [MethodImpl(Inline)]
        public static bit equals<N,T>(in ScalarBits<N,T> x, in ScalarBits<N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.eq(x.State, y.State);

        /// <summary>
        /// Extracts a contiguous sequence of bits defined by an inclusive range
        /// </summary>
        /// <param name="first">The first bit position</param>
        /// <param name="last">The last bit position</param>
        [MethodImpl(Inline), BitSeg, Closures(Closure)]
        public static ScalarBits<T> extract<T>(ScalarBits<T> x, byte first, byte last)
            where T : unmanaged
                => gbits.extract(x.State, first, last);

        /// <summary>
        /// Extracts a contiguous sequence of bits defined by an inclusive range
        /// </summary>
        /// <param name="first">The first bit position</param>
        /// <param name="last">The last bit position</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> extract<N,T>(ScalarBits<N,T> x, byte first, byte last)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.extract(x.State, first, last);

        /// <summary>
        /// Constructs a bitvector formed from the n lest significant bits of the source vector
        /// </summary>
        /// <param name="n">The count of least significant bits</param>
        [MethodImpl(Inline), LoSeg, Closures(Closure)]
        public static ScalarBits<T> lo<T>(ScalarBits<T> src, byte n)
            where T : unmanaged
                => extract(src, 0, n -=1);

        /// <summary>
        /// Constructs a bitvector formed from the n most significant bits of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The count of least significant bits</param>
        [MethodImpl(Inline), HiSeg, Closures(Closure)]
        public static ScalarBits<T> hi<T>(ScalarBits<T> x, byte n)
            where T : unmanaged
                => extract(x, (byte)(x.Width - n), (byte)(x.Width - 1));

 
        /// <summary>
        /// Computes the Hamming distance between two generic bitvectors
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint hamming<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => pop(xor(x,y));

        /// <summary>
        /// Computes the Hamming distance between bitvectors
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static uint hamming<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => pop(xor(x,y));

        /// <summary>
        /// Populates a target vector with specified source bits
        /// </summary>
        /// <param name="spec">Identifies the source bits of interest</param>
        /// <param name="dst">Receives the identified bits</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarBits<T> gather<T>(ScalarBits<T> src, ScalarBits<T> spec)
            where T : unmanaged
                => gbits.gather(src.State, spec.State);

        /// <summary>
        /// Populates a target vector with specified source bits
        /// </summary>
        /// <param name="spec">Identifies the source bits of interest</param>
        /// <param name="dst">Receives the identified bits</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> gather<N,T>(ScalarBits<N,T> src, ScalarBits<N,T> spec)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.gather(src.State, spec.State);

        /// <summary>
        /// Computes the effective width of the bitvector as determined by the number of leading zero bits
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), EffWidth, Closures(Closure)]
        public static int effwidth<T>(ScalarBits<T> x)
            where T : unmanaged
                => (int)width<T>() - nlz(x);

        /// <summary>
        /// Computes the effective width of the bitvector as determined by the number of leading zero bits
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static int effwidth<N,T>(ScalarBits<N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => x.Width - nlz(x);

        /// <summary>
        /// Rotates source bits rightward
        /// </summary>
        /// <param name="src">The source bitvector</param>
        /// <param name="count">The rotation magnitude</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Rotr, Closures(Closure)]
        public static ScalarBits<T> rotr<T>(ScalarBits<T> src, byte count)
            where T : unmanaged
                => gbits.rotr(src.State, count);

        /// <summary>
        /// Rotates source bits rightward
        /// </summary>
        /// <param name="src">The source bitvector</param>
        /// <param name="count">The rotation magnitude</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> rotr<N,T>(ScalarBits<N,T> src, byte count)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.rotr(src.State, count, (byte)src.Width);

        /// <summary>
        /// Rotates source bits leftward
        /// </summary>
        /// <param name="src">The source bitvector</param>
        /// <param name="count">The rotation magnitude</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Rotl, Closures(Closure)]
        public static ScalarBits<T> rotl<T>(ScalarBits<T> src, byte count)
            where T : unmanaged
                => gbits.rotl(src.State,count);

        [MethodImpl(Inline), Eq, Closures(Closure)]
        public static bit eq<T>(in ScalarBits<T> x, in ScalarBits<T> y)
            where T : unmanaged
                => gmath.eq(x.State, y.State);

        /// <summary>
        /// Assumes that
        /// 1. The source vector is a symbol tape upon which fixed-width symbols are sequentially recorded
        /// 2. The symbol alphabet is defined by the last character of the literals defined by an enumeration
        /// With these preconditions, the operation returns the ordered sequence of symbols written to the tape
        /// </summary>
        /// <param name="src">The source bitvector</param>
        /// <param name="segwidth">The number of bits designated to represent/define a symbol value</param>
        /// <param name="maxbits">The maximum number bits to use if less than the bit width of the vector</param>
        /// <typeparam name="E">The enumeration type that defines the symbols</typeparam>
        /// <typeparam name="T">The primal bitvector cell type</typeparam>
        public static ReadOnlySpan<char> symbols<E,T>(ScalarBits<T> src, byte segwidth, int? maxbits = null)
            where E : unmanaged, Enum
            where T : unmanaged
        {
            var index = ClrEnums.dictionary<E,T>();
            var bitcount = maxbits ?? sys.width<T>();
            var count = CellCalcs.mincells((ulong)segwidth, (ulong)bitcount);
            Span<char> symbols = new char[count];
            for(int i=0, bitpos = 0; i<count; i++, bitpos += segwidth)
            {
                var value = index[src[(byte)bitpos, (byte)(bitpos + segwidth - 1)]];
                symbols[i] = text.last(value.ToString());
            }
            return symbols;
        }

        /// <summary>
        /// Rearranges the vector as specified by a permutation
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="spec">The permutation</param>
        [Op, Closures(Closure)]
        public static ScalarBits<T> perm<T>(ScalarBits<T> src, in Perm spec)
            where T : unmanaged
        {
            var dst = replicate(src);
            var w = src.Width;
            for(var i=0; i<w; i++)
            {
                ref readonly var j = ref spec[i];
                if(j != i)
                    dst[i] = src[j];
            }
            return dst;
        }

        public static ScalarBits<N,T> perm<N,T>(ScalarBits<N,T> src, in Perm spec)
            where T : unmanaged
            where N : unmanaged, ITypeNat
        {
            var dst = src.Replicate();
            var n = src.Width;
            for(var i=0; i<n; i++)
                dst[i] = src[spec[i]];
            return dst;
        }        

        /// <summary>
        /// Converts the vector content to a bitring representation
        /// </summary>
        [MethodImpl(Inline)]
        public static BitString bitstring<N,T>(ScalarBits<N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => BitStrings.scalar<T>(x.State, x.Width);

        /// <summary>
        /// Converts the vector content to a bitring representation
        /// </summary>
        [MethodImpl(Inline)]
        public static BitString bitstring<N,T>(ScalarBits<N,T> x, byte[] storage)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => BitStrings.scalar<T>(x.State, storage, x.Width);


        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="fmt">Optional formatting style</param>
        [MethodImpl(Inline)]
        public static string format<N,T>(ScalarBits<N,T> x, BitFormat? fmt = null)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => bitstring(x).Format(fmt);        
    }

    public static partial class XTend
    {
        /// <summary>
        /// Creates a copy of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The storage cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<T> Replicate<T>(this ScalarBits<T> src)
            where T : unmanaged
                 => ScalarBits.replicate(src);

        /// <summary>
        /// Creates a copy of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The storage cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> Replicate<N,T>(this ScalarBits<N,T> src)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => ScalarBits.replicate(src);

        /// <summary>
        /// Applies a permutation to a copy of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="p">The permutation</param>
        /// <typeparam name="T">The storage cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<T> Permute<T>(this ScalarBits<T> src, in Perm p)
            where T : unmanaged
                => ScalarBits.perm(src,p);

        /// <summary>
        /// Applies a permutation to a copy of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="p">The permutation</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> Permute<N,T>(this ScalarBits<N,T> src, in Perm p)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => ScalarBits.perm(src,p);

        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline)]
        public static bit TestC<T>(this ScalarBits<T> src)
            where T : unmanaged
                => ScalarBits.testc(src);

        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline)]
        public static bit TestC<N,T>(this ScalarBits<N,T> src)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => ScalarBits.testc(src);

        /// <summary>
        /// Converts the vector content to a bitring representation
        /// </summary>
        [MethodImpl(Inline)]
        public static BitString ToBitString<N,T>(this ScalarBits<N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => ScalarBits.bitstring(x);

        /// <summary>
        /// Converts the vector content to a bitring representation
        /// </summary>
        [MethodImpl(Inline)]
        public static BitString ToBitString<N,T>(this ScalarBits<N,T> x, byte[] storage)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => ScalarBits.bitstring(x,storage);

        /// <summary>
        /// Extracts the represented data as a bitstring
        /// </summary>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this ScalarBits<T> src)
            where T : unmanaged
                => ScalarBits.bitstring(src);

        /// <summary>
        /// Extracts the represented data as a bitstring truncated to a specified width
        /// </summary>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this ScalarBits<T> src, int width)
            where T : unmanaged
                => ScalarBits.bitstring(src,width);

        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="fmt">Bitstring formatting specifications</param>
        public static string Format<N,T>(this ScalarBits<N,T> src, BitFormat? fmt = null)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => ScalarBits.format(src,fmt);

        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="fmt">Bitstring formatting specifications</param>
        public static string Format<T>(this ScalarBits<T> src, BitFormat? fmt = null)
            where T : unmanaged
                => ScalarBits.format(src,fmt);

        /// <summary>
        /// Reverses a copy of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The storage cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<T> Reverse<T>(this ScalarBits<T> src)
            where T : unmanaged
                => ScalarBits.reverse(src);

        /// <summary>
        /// Reverses the bits in the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> Reverse<N,T>(this ScalarBits<N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => ScalarBits.reverse(x);


    }
}