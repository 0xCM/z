//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using U = uint6;
    using W = W6;

    partial struct BitNumbers
    {
        [MethodImpl(Inline), Op]
        public static bit test(U src, byte pos)
            => bit.test(src,pos);

        [MethodImpl(Inline), Op]
        public static U set(U src, byte pos, bit state)
        {
            if(pos < U.Width)
                return wrap6(bit.set(src.Value, pos, state));
            else
                return src;
        }

        [MethodImpl(Inline), Op]
        public static U maxval(W w)
            => U.Max;

        /// <summary>
        /// Increments a specified operand by the unit value
        /// </summary>
        /// <param name="a">The source operand</param>
        [MethodImpl(Inline), Op]
        public static U inc(U a)
            => !a.IsMax ? new U(sys.add(a.Value, 1), false) : U.Min;

        [MethodImpl(Inline), Op]
        public static U dec(U a)
            => !a.IsMin ? new U(Bytes.sub(a.Value, 1), false) : U.Max;

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

        /// <summary>
        /// Converts a source integral value to an enum value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="K">The target enum  type</typeparam>
        [MethodImpl(Inline)]
        public static ref K refine<K>(in uint6 src)
            where K : unmanaged, Enum
                => ref @as<uint6,K>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref S edit<S>(in U src)
            where S : unmanaged
                => ref @as<U,S>(src);

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

        /// <summary>
        /// Injects the source value directly into the width-identified target, bypassing bounds-checks
        /// </summary>
        /// <param name="src">The value to inject</param>
        /// <param name="w">The target bit-width</param>
        [MethodImpl(Inline)]
        public static U inject(byte src, W w)
            => new U(src, false);

        /// <summary>
        /// Reduces the source value to a width-identified integer via modular arithmetic
        /// </summary>
        /// <param name="src">The input value</param>
        /// <param name="w">The target bit-width</param>
        [MethodImpl(Inline), Op]
        public static U reduce(byte src, W w)
            => new U(src);

        /// <summary>
        /// Creates a 6-bit unsigned integer, equal to zero or one, if the source value is respectively false or true
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint6(bool src)
            => wrap6(@byte(src));

        /// <summary>
        /// Creates a 6-bit unsigned integer from the least 6 bits of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint6(byte src)
            => new U(src);

        /// <summary>
        /// Creates a 6-bit unsigned integer from the least 6 bits of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint6(sbyte src)
            => new U(src);

        /// <summary>
        /// Creates a 6-bit unsigned integer from the least 6 bits of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint6(ushort src)
            => new U(src);

        /// <summary>
        /// Creates a 6-bit unsigned integer from the least 6 bits of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint6(short src)
            => new U(src);

        /// <summary>
        /// Creates a 6-bit unsigned integer from the least 6 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint6(int src)
            => new U(src);

        /// <summary>
        /// Creates a 6-bit unsigned integer from the least 6 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint6(uint src)
            => new U(src);

        /// <summary>
        /// Creates a 6-bit unsigned integer from the least 6 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint6(long src)
            => new U(src);

        /// <summary>
        /// Creates a 6-bit unsigned integer from the least 6 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint6(uint24 src)
            => new U((uint)src);

        /// <summary>
        /// Creates a 6-bit unsigned integer from the least 6 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint6(ulong src)
            => new U((byte)((byte)src & U.MaxValue));

        /// <summary>
        /// Constructs a uint6 value from a sequence of bits ranging from low to high
        /// </summary>
        /// <param name="x0">The first/least bit value, if specified; otherwise, defaults to 0</param>
        /// <param name="x1">The second bit value, if specified; otherwise, defaults to 0</param>
        /// <param name="x2">The third bit value, if specified; otherwise, defaults to 0</param>
        /// <param name="x3">The fourth/highest bit value, if specified; otherwise, defaults to 0</param>
        [MethodImpl(Inline), Op]
        public static U uint6(bit x0, bit x1 = default, bit x2 = default, bit x3 = default, bit x4 = default, bit x5 = default)
             => wrap6((byte)(
                 ((uint)x0 << 0) |
                 ((uint)x1 << 1) |
                 ((uint)x2 << 2) |
                 ((uint)x3 << 3) |
                 ((uint)x4 << 4) |
                 ((uint)x5 << 5)
                ));

        [MethodImpl(Inline), Op]
        public static U add(U x, U y)
        {
            var sum = (byte)(x.Value + y.Value);
            return wrap6((sum >= U.Mod) ? (byte)(sum - U.Mod): sum);
        }

        [MethodImpl(Inline), Op]
        public static U sub(U x, U y)
        {
            var diff = (int)x - (int)y;
            return wrap6(diff < 0 ? (byte)(diff + U.Mod) : (byte)diff);
        }

        [MethodImpl(Inline), Op]
        public static U div (U lhs, U rhs)
            => wrap6((byte)(lhs.Value / rhs.Value));

        [MethodImpl(Inline), Op]
        public static U mod (U lhs, U rhs)
            => wrap6((byte)(lhs.Value % rhs.Value));

        [MethodImpl(Inline), Op]
        public static U mul(U lhs, U rhs)
            => reduce6((byte)(lhs.Value * rhs.Value));

        [MethodImpl(Inline), Op]
        public static U or(U lhs, U rhs)
            => wrap6((byte)(lhs.Value | rhs.Value));

        [MethodImpl(Inline), Op]
        public static U and(U lhs, U rhs)
            => wrap6((byte)(lhs.Value & rhs.Value));

        [MethodImpl(Inline), Op]
        public static U xor(U lhs, U rhs)
            => wrap6((byte)(lhs.Value ^ rhs.Value));

        [MethodImpl(Inline), Op]
        public static U srl(U lhs, byte count)
            => uint6(lhs.Value >> count);

        [MethodImpl(Inline), Op]
        public static U sll(U lhs, byte count)
            => uint6(lhs.Value << count);

        [MethodImpl(Inline)]
        public static bool eq(U x, U y)
            => x.Value == y.Value;

        [MethodImpl(Inline)]
        public static byte crop6(byte x)
            => (byte)(U.MaxValue & x);

        [MethodImpl(Inline), Op]
        internal static byte reduce6(byte x)
            => (byte)(x % U.Mod);

        [MethodImpl(Inline)]
        internal static U wrap6(byte src)
            => new U(src,false);

        [MethodImpl(Inline)]
        public static string format(U src)
            => BitRender.gformat(src.Value, BitFormatter.limited(U.Width,U.Width));

        [MethodImpl(Inline)]
        public static string format(U src, BitFormat config)
            => BitRender.gformat(src.Value, config);
    }
}