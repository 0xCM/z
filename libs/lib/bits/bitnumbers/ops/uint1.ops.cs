//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using U = uint1;
    using W = W1;

    partial struct BitNumbers
    {
        [MethodImpl(Inline), Op]
        public static bit test(U x)
            => bit.test(x.Value, 0);

        [MethodImpl(Inline), Op]
        public static U set(U src, byte pos, bit state)
        {
            if(pos < U.Width)
                return wrap1(bit.set(src.Value, pos, state));
            else
                return src;
        }

        [MethodImpl(Inline), Op]
        public static U maxval(W1 w)
            => U.Max;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref S edit<S>(in U src)
            where S : unmanaged
                => ref @as<U,S>(src);

        /// <summary>
        /// Reduces the source value to a width-identified integer via modular arithmetic
        /// </summary>
        /// <param name="src">The input value</param>
        /// <param name="w">The target bit-width</param>
        [MethodImpl(Inline), Op]
        public static U reduce(byte src, W w)
            => new U(src);

        /// <summary>
        /// Reinterprets an input reference as a mutable <see cref='Z0.uint1'/> reference cell
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="dst">The target width selector</param>
        /// <typeparam name="S">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref uint1 edit<S>(in S src, W dst)
            where S : unmanaged
                => ref @as<S,uint1>(src);

        /// <summary>
        /// Shears the input to a target width
        /// </summary>
        /// <param name="src">The value to cut</param>
        /// <param name="dst">The target width</param>
        [MethodImpl(Inline), Op]
        public static ref uint1 cut(in byte src, W dst)
            => ref @as<byte,uint1>(src);

        /// <summary>
        /// Converts a source integral value to an enum value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="K">The target enum  type</typeparam>
        [MethodImpl(Inline)]
        public static ref K refine<K>(in uint1 src)
            where K : unmanaged, Enum
                => ref @as<uint1,K>(src);

        /// <summary>
        /// Converts an to sized integral value
        /// </summary>
        /// <param name="src">The source enum value</param>
        /// <param name="n">The target integer width</param>
        /// <typeparam name="K">The source enum type</typeparam>
        [MethodImpl(Inline)]
        public static ref U scalar<K>(in K src, N1 n)
            where K : unmanaged, Enum
                => ref @as<K,U>(src);

        [MethodImpl(Inline), Op]
        public static U uint1(bool src)
            => wrap1(@byte(src));

        /// <summary>
        /// Creates a 1-bit unsigned integer from the first bit of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint1(byte src)
            => new U(src);

        /// <summary>
        /// Creates a 1-bit unsigned integer from the first bit of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint1(sbyte src)
            => new U(src);

        /// <summary>
        /// Creates a 1-bit unsigned integer from the first bit of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint1(ushort src)
            => new U(src);

        /// <summary>
        /// Creates a 1-bit unsigned integer from the first bit of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint1(short src)
            => new U(src);

        /// <summary>
        /// Creates a 1-bit unsigned integer from the first bit of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint1(int src)
            => new U(src);

        /// <summary>
        /// Creates a 1-bit unsigned integer from the first bit of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint1(uint src)
            => new U(src);

        /// <summary>
        /// Creates a 1-bit unsigned integer from the first bit of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint1(long src)
            => new U((byte)src);

        /// <summary>
        /// Creates a 1-bit unsigned integer from the first bit of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint1(ulong src)
            => new U((byte)((byte)src & U.MaxValue));

        [MethodImpl(Inline), Op]
        public static U add(U a, U b)
        {
            var sum = a.Value + b.Value;
            return wrap1((sum >= U.Count) ? (byte)sum - (byte)U.Count: sum);
        }

        [MethodImpl(Inline), Op]
        public static U sub(U a, U b)
        {
            var diff = (int)a - (int)b;
            return wrap1(diff < 0 ? (byte)(diff + U.Count) : (byte)diff);
        }

        [MethodImpl(Inline), Op]
        public static U mul(U a, U b)
            => reduce1((byte)(a.Value * b.Value));

        [MethodImpl(Inline), Op]
        public static U div (U lhs, U rhs)
            => wrap1((byte)(lhs.Value / rhs.Value));

        [MethodImpl(Inline), Op]
        public static U mod (U lhs, U rhs)
            => wrap1((byte)(lhs.Value % rhs.Value));

        [MethodImpl(Inline), Op]
        public static U srl(U lhs, byte rhs)
            => uint1((byte)(lhs.Value >> rhs));

        [MethodImpl(Inline), Op]
        public static U sll(U a, byte b)
            => uint1((byte)(a.Value << b));

        [MethodImpl(Inline), Op]
        public static U inc(U x)
            => !x.IsMax ? new U(Bytes.add(x.Value, 1), false) : U.Min;

        [MethodImpl(Inline), Op]
        public static U dec(U x)
            => !x.IsMin ? new U(Bytes.sub(x.Value, 1), false) : U.Max;

        [MethodImpl(Inline), Op]
        public static bit eq(U a, U b)
            => a.Value == b.Value;

        [MethodImpl(Inline)]
        public static byte crop1(byte a)
            => (byte)(U.MaxValue & a);

        [MethodImpl(Inline), Op]
        internal static byte reduce1(byte a)
            => (byte)(a % U.Count);

        [MethodImpl(Inline)]
        internal static U wrap1(int a)
            => new U((byte)a, false);

        /// <summary>
        /// Injects the source value directly into the width-identified target, bypassing bounds-checks
        /// </summary>
        /// <param name="src">The value to inject</param>
        /// <param name="w">The target bit-width</param>
        [MethodImpl(Inline)]
        public static U inject(byte src, W w)
            => new U(src, false);

        [MethodImpl(Inline), Op]
        public static U @false(U a, U b)
            => U.Min;

        [MethodImpl(Inline), Op]
        public static U @true(U a, U b)
            => U.Max;

        [MethodImpl(Inline), Op]
        public static U or(U a, U b)
            => wrap1((byte)(a.Value | b.Value));

        [MethodImpl(Inline), Op]
        public static U and(U a, U b)
            => wrap1((byte)(a.Value & b.Value));

        [MethodImpl(Inline), Op]
        public static U xor(U lhs, U rhs)
            => wrap1((byte)(lhs.Value ^ rhs.Value));

        [MethodImpl(Inline), Op]
        public static U nand(U a, U b)
            => !(a & b);

        [MethodImpl(Inline), Op]
        public static U nor(U a, U b)
            => ~(a | b);

        [MethodImpl(Inline), Op]
        public static U xnor(U a, U b)
            => !(a ^ b);

        [MethodImpl(Inline), Op]
        public static U impl(U a, U b)
            => a | ~b;

        [MethodImpl(Inline), Op]
        public static U nonimpl(U a, U b)
            => ~a & b;

        [MethodImpl(Inline), Op]
        public static U left(U a, U b)
            => a;

        [MethodImpl(Inline), Op]
        public static U right(U a, U b)
            => b;

        [MethodImpl(Inline), Op]
        public static U lnot(U a, U b)
            => !a;

        [MethodImpl(Inline), RNot]
        public static U rnot(U a, U b)
            => ~b;

        [MethodImpl(Inline), Op]
        public static U cimpl(U a, U b)
            => ~a | b;

        [MethodImpl(Inline), Op]
        public static U cnonimpl(U a, U b)
            => a & ~b;

        [MethodImpl(Inline)]
        public static U same(U a, U b)
            => a == b;

        [MethodImpl(Inline), Select]
        public static U select(U a, U b, U c)
            => or(and(a,b), nonimpl(a,c));

        [MethodImpl(Inline), Op]
        public static Span<bit> bits(U src)
        {
            var storage = z8;
            var dst = @recover<byte,bit>(@bytes(storage));
            if(bit.test(src,0))
                seek(dst,0) = bit.On;
            return dst;
        }
    }
}