//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using U = uint8b;
    using W = W8;

    partial struct BitNumbers
    {
        [MethodImpl(Inline), Op]
        public static uint4 lo(uint8b src)
            => Bytes.and(src.Value, 0xF);

        [MethodImpl(Inline), Op]
        public static uint4 hi(uint8b src)
            => Bytes.srl(src.Value, 4);

        [MethodImpl(Inline), Op]
        public static void render(U src, uint offset, Span<char> dst)
            => render(src, 8, offset, dst);

        [MethodImpl(Inline), Op]
        public static void render(U src, Span<char> dst)
            => render(src, 8, 0, dst);

        [MethodImpl(Inline), Op]
        public static U maxval(W8 w)
            => U.Max;

        [MethodImpl(Inline), Op]
        public static U inc(U x)
            => !x.IsMax ? new U(core.add(x.Value, 1)) : U.Min;

        [MethodImpl(Inline), Op]
        public static U dec(U x)
            => !x.IsMin ? new U(Bytes.sub(x.Value, 1)) : U.Max;

        /// <summary>
        /// Reinterprets an input reference as a mutable <see cref='U'/> reference cell
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="dst">The target width selector</param>
        /// <typeparam name="S">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref U cast<S>(in S src, W8 dst)
            where S : unmanaged
                => ref @as<S,U>(src);

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

        /// <summary>
        /// Injects the source value directly into the width-identified target, bypassing bounds-checks
        /// </summary>
        /// <param name="src">The value to inject</param>
        /// <param name="w">The target bit-width</param>
        [MethodImpl(Inline)]
        public static U inject(byte src, W w)
            => new U(src);

        /// <summary>
        /// Creates a 8-bit unsigned integer, equal to zero or one, according to whether the source is respectively false or true
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint8(bool src)
            => new U(@byte(src));

        /// <summary>
        /// Creates a 8-bit unsigned integer from the least 8 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint8(byte src)
            => new U(src);

        /// <summary>
        /// Creates a 8-bit unsigned integer from the least 8 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint8(sbyte src)
            => new U((byte)src);

        /// <summary>
        /// Creates a 8-bit unsigned integer from the least 8 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint8(ushort src)
            => new U((byte)src);

        /// <summary>
        /// Creates a 8-bit unsigned integer from the least 8 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint8(short src)
            => new U((byte)src);

        /// <summary>
        /// Creates a 8-bit unsigned integer from the least 8 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint8(int src)
            => new U((byte)src);

        /// <summary>
        /// Creates a 8-bit unsigned integer from the least 8 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint8(uint src)
            => new U((byte)src);

        /// <summary>
        /// Creates a 8-bit unsigned integer from the least 8 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint8(long src)
            => new U((byte)src);

        /// <summary>
        /// Creates a 8-bit unsigned integer from the least 8 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint8(ulong src)
            => new U((byte)src);

        [MethodImpl(Inline), Op]
        public static bit test(U src, byte pos)
            => bit.test(src,pos);

        [MethodImpl(Inline), Op]
        public static U set(U src, byte pos, bit state)
        {
            if(pos < U.Width)
                return new U(bit.set(src.Value, pos, state));
            else
                return src;
        }

        static BitFormat FormatConfig8
            => BitFormatter.limited(U.Width,U.Width);

        [MethodImpl(Inline)]
        public static string format(U src)
            => BitRender.gformat(src.Value, FormatConfig8);

        [MethodImpl(Inline)]
        public static string format(U src, BitFormat config)
            => BitRender.gformat(src.Value, config);
    }
}