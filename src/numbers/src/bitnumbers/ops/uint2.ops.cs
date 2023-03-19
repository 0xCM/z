//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using U = uint2;
    using W = W2;

    partial struct BitNumbers
    {
        [MethodImpl(Inline), Op]
        public static bit test(U src, byte pos)
            => bit.test(src,pos);

        [MethodImpl(Inline), Op]
        public static U set(U src, byte pos, bit state)
        {
            if(pos < U.Width)
                return wrap(w2, bit.set(src.Value, pos, state));
            else
                return src;
        }

        [MethodImpl(Inline), Op]
        public static string format(U src)
            => BitRender.gformat(src.Value, BitFormatter.limited(U.Width, U.Width));

        [MethodImpl(Inline)]
        public static string format(U src, BitFormat config)
            => BitRender.gformat(src.Value, config);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref S edit<S>(in U src)
            where S : unmanaged
                => ref @as<U,S>(src);

        /// <summary>
        /// Promotes a <see cref='U2'/> to a <see cref='U3'/>, as indicated by the <see cref='W3'/> selector
        /// and shifts the result <see cref='N1'/> bit leftward
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        /// <param name="n">The leftward shift count</param>
        [MethodImpl(Inline), Op]
        public static uint3 extend(W3 w, N1 n, U src)
            => (uint3)src << 1;

        /// <summary>
        /// Reduces the source value to a width-identified integer via modular arithmetic
        /// </summary>
        /// <param name="src">The input value</param>
        /// <param name="w">The target bit-width</param>
        [MethodImpl(Inline), Op]
        public static U reduce(byte src, W w)
            => new U(src);

        /// <summary>
        /// Reinterprets an input reference as a mutable <see cref='U'/> reference cell
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="dst">The target width selector</param>
        /// <typeparam name="S">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref U edit<S>(in S src, W dst)
            where S : unmanaged
                => ref @as<S,U>(src);

        [MethodImpl(Inline), Op]
        public static U maxval(W w)
            => U.Max;

        [MethodImpl(Inline), Op]
        public static U dec(U x)
            => !x.IsMin ? new U(Bytes.sub(x.Value, 1), false) : U.Max;

        [MethodImpl(Inline), Op]
        public static U inc(U x)
            => !x.IsMax ? new U(sys.add(x.Value, 1), false) : U.Min;

        /// <summary>
        /// Converts a source integral value to an enum value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="K">The target enum  type</typeparam>
        [MethodImpl(Inline)]
        public static ref K refine<K>(in U src)
            where K : unmanaged, Enum
                => ref @as<U,K>(src);

        /// <summary>
        /// Converts an enum to a width-identified integer
        /// </summary>
        /// <param name="src">The source enum value</param>
        /// <param name="n">The target integer width</param>
        /// <typeparam name="K">The source enum type</typeparam>
        [MethodImpl(Inline)]
        public static U scalar<K>(in K src, W w)
            where K : unmanaged, Enum
                => new U(@as<K,byte>(src));

        [MethodImpl(Inline)]
        internal static U wrap(W w, int src)
            => new U((byte)src,false);

        /// <summary>
        /// Creates a 2-bit unsigned integer, equal to zero or one, if the source value is respectively false or true
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U create(W w, bool src)
            => wrap2(@byte(src));

        /// <summary>
        /// Creates a 2-bit unsigned integer from the least 2 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U create(W w, byte src)
            => new U(src);

        /// <summary>
        /// Creates a 2-bit unsigned integer from the least 2 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U create(W w, sbyte src)
            => new U(src);

        /// <summary>
        /// Creates a 2-bit unsigned integer from the least 2 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U create(W w, ushort src)
            => new U(src);

        /// <summary>
        /// Creates a 2-bit unsigned integer from the least 2 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U create(W w, short src)
            => new U(src);

        /// <summary>
        /// Creates a 2-bit unsigned integer from the least 2 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U create(W w, int src)
            => new U(src);

        /// <summary>
        /// Creates a 2-bit unsigned integer from the least 2 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U create(W w, uint src)
            => new U(src);

        /// <summary>
        /// Creates a 2-bit unsigned integer from the least 2 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U create(W w, long src)
            => new U(src);

        /// <summary>
        /// Creates a 2-bit unsigned integer from the least 2 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U create(W w, ulong src)
            => new U((byte)((byte)src & U.MaxValue));

        /// <summary>
        /// Creates a 2-bit unsigned integer from a 2-term bit sequence
        /// </summary>
        /// <param name="x0">The term at index 0</param>
        /// <param name="x1">The term at index 1</param>
        [MethodImpl(Inline), Op]
        public static U create(W w, bit x0, bit x1 = default)
             => new U(((uint)x0 << 0) | ((uint)x1 << 1), true);

        [MethodImpl(Inline), Op]
        public static U uint2(bool src)
            => wrap2(@byte(src));

        /// <summary>
        /// Creates a 2-bit unsigned integer from the first two source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint2(byte src)
            => new U(src);

        /// <summary>
        /// Injects the source value directly into the width-identified target, bypassing bounds-checks
        /// </summary>
        /// <param name="src">The value to inject</param>
        /// <param name="w">The target bit-width</param>
        [MethodImpl(Inline)]
        public static U inject(byte src, W w)
            => new U(src, false);

        /// <summary>
        /// Creates a 2-bit unsigned integer from the first least two source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint2(sbyte src)
            => new U(src);

        /// <summary>
        /// Creates a 2-bit unsigned integer from the first least two source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint2(ushort src)
            => new U(src);

        /// <summary>
        /// Creates a 2-bit unsigned integer from the least two bits of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint2(short src)
            => new U(src);

        /// <summary>
        /// Creates a 2-bit unsigned integer from the least two bits of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint2(int src)
            => new U(src);

        /// <summary>
        /// Creates a 2-bit unsigned integer from the least two bits of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint2(uint src)
            => new U(src);

        /// <summary>
        /// Creates a 2-bit unsigned integer from the least two bits of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint2(long src)
            => new U((byte)src);

        /// <summary>
        /// Creates a 2-bit unsigned integer from the least two bits of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint2(ulong src)
            => new U((byte)((byte)src & U.MaxValue));

        [MethodImpl(Inline), Op]
        public static U add(U x, U y)
        {
            var sum = x.Value + y.Value;
            return wrap(w2, (sum >= U.Mod) ? sum - (byte)U.Mod: sum);
        }

        [MethodImpl(Inline), Op]
        public static U sub(U x, U y)
        {
            var diff = (int)x - (int)y;
            return wrap(w2, diff < 0 ? (byte)(diff + U.Mod) : (byte)diff);
        }

        [MethodImpl(Inline), Op]
        public static U mul(U a, U b)
            => reduce2((byte)(a.Value * b.Value));

        [MethodImpl(Inline), Op]
        public static U div (U a, U b)
            => wrap(w2, (byte)(a.Value / b.Value));

        [MethodImpl(Inline), Op]
        public static U mod (U a, U b)
            => wrap(w2, (byte)(a.Value % b.Value));

        [MethodImpl(Inline), Op]
        public static U srl(U a, byte b)
            => create(w2, a.Value >> b);

        [MethodImpl(Inline), Op]
        public static U sll(U a, byte b)
            => create(w2, a.Value << b);

        [MethodImpl(Inline), Op]
        public static bool eq(U x, U y)
            => x.Value == y.Value;

        [MethodImpl(Inline), False]
        public static U @false(U a, U b)
            => U.Min;

        [MethodImpl(Inline), True]
        public static U @true(U a, U b)
            => U.Max;

        [MethodImpl(Inline), Op]
        public static U and(U a, U b)
            => wrap(w2, (byte)(a.Value & b.Value));

        [MethodImpl(Inline), Op]
        public static U or(U a, U b)
            => wrap(w2, (byte)(a.Value | b.Value));

        [MethodImpl(Inline), Op]
        public static U xor(U a, U b)
            => wrap(w2, (byte)(a.Value ^ b.Value));

        [MethodImpl(Inline), Op]
        public static U not(U a)
            => wrap2(~a.Value & U.MaxValue);

        [MethodImpl(Inline), Nand]
        public static U nand(U a, U b)
            => ~(a & b);

        [MethodImpl(Inline), Nor]
        public static U nor(U a, U b)
            => ~(a | b);

        [MethodImpl(Inline), Xnor]
        public static U xnor(U a, U b)
            => ~(a ^ b);

        [MethodImpl(Inline), Impl]
        public static U impl(U a, U b)
            => a | ~b;

        [MethodImpl(Inline), NonImpl]
        public static U nonimpl(U a, U b)
            => ~a & b;

        [MethodImpl(Inline), Left]
        public static U left(U a, U b)
            => a;

        [MethodImpl(Inline), Right]
        public static U right(U a, U b)
            => b;

        [MethodImpl(Inline), LNot]
        public static U lnot(U a, U b)
            => ~a;

        [MethodImpl(Inline), RNot]
        public static U rnot(U a, U b)
            => ~b;

        [MethodImpl(Inline), CImpl]
        public static U cimpl(U a, U b)
            => ~a | b;

        [MethodImpl(Inline), CNonImpl]
        public static U cnonimpl(U a, U b)
            => a & ~b;

        [MethodImpl(Inline), Same]
        public static U same(U a, U b)
            => @byte(a == b);

        [MethodImpl(Inline), Select]
        public static U select(U a, U b, U c)
            => or(and(a,b), nonimpl(a,c));

        [MethodImpl(Inline)]
        public static byte crop2(byte x)
            => (byte)(U.MaxValue & x);

        [MethodImpl(Inline), Op]
        internal static byte reduce2(byte x)
            => (byte)(x % U.Mod);

        [MethodImpl(Inline)]
        internal static U wrap2(uint src)
            => new U((byte)src, false);

        [MethodImpl(Inline)]
        internal static U wrap2(int src)
            => new U((byte)src, false);
    }
}