//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using U = uint3;
    using W = W3;

    partial struct BitNumbers
    {
        [MethodImpl(Inline), Op]
        public static bit test(U src, byte pos)
            => bit.test(src, pos);

        [MethodImpl(Inline), Op]
        public static U set(U src, byte pos, bit state)
        {
            if(pos < U.Width)
                return wrap3(bit.set(src.Value, pos, state));
            else
                return src;
        }

        [MethodImpl(Inline), Op]
        public static U maxval(W w)
            => U.Max;

        /// <summary>
        /// Reduces the source value to a width-identified integer via modular arithmetic
        /// </summary>
        /// <param name="src">The input value</param>
        /// <param name="w">The target bit-width</param>
        [MethodImpl(Inline), Op]
        public static U reduce(byte src, W w)
            => new U(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref S edit<S>(in U src)
            where S : unmanaged
                => ref @as<U,S>(src);

        [MethodImpl(Inline), Op]
        public static U inc(U x)
            => !x.IsMax ? new U(sys.add(x.Value, 1), false) : U.Min;

        [MethodImpl(Inline), Op]
        public static U dec(U x)
            => !x.IsMin ? new U(Bytes.sub(x.Value, 1), false) : U.Max;

        /// <summary>
        /// Reinterprets an input reference as a mutable <see cref='Z0.uint2'/> reference cell
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
        public static ref K refine<K>(in U src)
            where K : unmanaged, Enum
                => ref @as<U,K>(src);

        /// <summary>
        /// Converts an to sized integral value
        /// </summary>
        /// <param name="src">The source enum value</param>
        /// <param name="n">The target integer width</param>
        /// <typeparam name="K">The source enum type</typeparam>
        [MethodImpl(Inline)]
        public static U scalar<K>(in K src, W w)
            where K : unmanaged, Enum
                => new U(@as<K,byte>(src));

        /// <summary>
        /// Creates a 3-bit unsigned integer, equal to zero or one, if the source value is respectively false or true
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint3(bool src)
            => wrap3(@byte(src));

        /// <summary>
        /// Creates a 3-bit unsigned integer from the least 3 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint3(byte src)
            => new U(src);

        /// <summary>
        /// Creates a 3-bit unsigned integer from the least 3 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint3(sbyte src)
            => new U(src);

        /// <summary>
        /// Creates a 3-bit unsigned integer from the least 3 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint3(ushort src)
            => new U(src);

        /// <summary>
        /// Creates a 3-bit unsigned integer from the least 3 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint3(short src)
            => new U(src);

        /// <summary>
        /// Creates a 3-bit unsigned integer from the least 3 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint3(int src)
            => new U(src);

        /// <summary>
        /// Creates a 3-bit unsigned integer from the least 3 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint3(uint src)
            => new U(src);

        /// <summary>
        /// Creates a 3-bit unsigned integer from the least 3 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint3(long src)
            => new U(src);

        /// <summary>
        /// Creates a 3-bit unsigned integer from the least 3 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint3(ulong src)
            => new U((byte)((byte)src & U.MaxValue));

        /// <summary>
        /// Creates a 3-bit unsigned integer from a 3-term bit sequence
        /// </summary>
        /// <param name="a">The term at index 0</param>
        /// <param name="b">The term at index 1</param>
        /// <param name="c">The term at index 2</param>
        [MethodImpl(Inline), Op]
        public static U uint3(bit a, bit b = default, bit c = default)
             => wrap3((byte)(
                 ((uint)a << 0) |
                 ((uint)b << 1) |
                 ((uint)c << 2)
                 ));

        [MethodImpl(Inline), Op]
        public static U add(U a, U b)
        {
            var sum = a.Value + b.Value;
            return wrap3((sum >= U.Mod) ? (byte)(sum - U.Mod): (byte)sum);
        }

        [MethodImpl(Inline), Op]
        public static U sub(U a, U b)
        {
            var diff = (int)a - (int)b;
            return wrap3(diff < 0 ? (byte)(diff + U.Mod) : (byte)diff);
        }

        [MethodImpl(Inline), Op]
        public static U mul(U a, U b)
            => reduce3((byte)(a.Value * b.Value));

        [MethodImpl(Inline), Op]
        public static U div (U a, U b)
            => wrap3((byte)(a.Value / b.Value));

        [MethodImpl(Inline), Op]
        public static U mod (U a, U b)
            => wrap3((byte)(a.Value % b.Value));

        [MethodImpl(Inline), Op]
        public static U and(U a, U b)
            => wrap3((byte)(a.Value & b.Value));

        [MethodImpl(Inline), Op]
        public static U or(U a, U b)
            => wrap3((byte)(a.Value | b.Value));

        [MethodImpl(Inline), Op]
        public static U or(U a, U b, U c)
            => wrap3((byte)(a.Value | b.Value | c.Value));

        [MethodImpl(Inline), Op]
        public static U xor(U a, U b)
            => wrap3((byte)(a.Value ^ b.Value));

        [MethodImpl(Inline), Op]
        public static U not(U a)
            => wrap3(~a.Value & U.MaxValue);

        [MethodImpl(Inline), Op]
        public static U srl(U lhs, byte offset)
            => uint3(lhs.Value >> offset);

        [MethodImpl(Inline), Op]
        public static U sll(U lhs, byte offset)
            => uint3(lhs.Value << offset);

        [MethodImpl(Inline), Op]
        public static bool eq(U x, U y)
            => x.Value == y.Value;

        /// <summary>
        /// Injects the source value directly into the width-identified target, bypassing bounds-checks
        /// </summary>
        /// <param name="src">The value to inject</param>
        /// <param name="w">The target bit-width</param>
        [MethodImpl(Inline)]
        public static U inject(byte src, W w)
            => new U(src, false);

        [MethodImpl(Inline), Op]
        internal static byte reduce3(byte x)
            => (byte)(x % U.Mod);

        [MethodImpl(Inline)]
        internal static U wrap3(byte src)
            => new U(src, false);

        [MethodImpl(Inline)]
        internal static U wrap3(uint src)
            => new U(src, false);

        [MethodImpl(Inline)]
        internal static U wrap3(int src)
            => new U((byte)src,false);

        [MethodImpl(Inline)]
        public static byte crop3(byte x)
            => (byte)(U.MaxValue & x);

        static BitFormat FormatConfig3
            => BitFormatter.limited(U.Width, U.Width);

        [MethodImpl(Inline)]
        public static string format(U src)
            => BitRender.gformat(src.Value, FormatConfig3);

        [MethodImpl(Inline)]
        public static string format(U src, BitFormat config)
            => BitRender.gformat(src.Value, config);
    }
}