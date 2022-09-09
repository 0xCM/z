//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static uint24;
    using static core;

    using U = uint24;

    partial struct BitNumbers
    {
        [MethodImpl(Inline), Op]
        public static bit test(U x, byte pos)
            => bit.test(x.Value, pos);

        [MethodImpl(Inline), Op]
        public static U set(U x, byte pos, bit state)
            => new U(bit.set(x.Value, pos, state));

        [MethodImpl(Inline), Op]
        public static U maxval(W24 w)
            => U.Max;

        /// <summary>
        /// Creates a 24-bit unsigned integer, equal to zero or one, according to whether the source is respectively false or true
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint24(bool src)
            => new U(src);

        /// <summary>
        /// Creates a 24-bit unsigned integer from the least 24 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint24(byte src)
            => new U(src);

        /// <summary>
        /// Creates a 24-bit unsigned integer from the least 24 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint24(sbyte src)
            => new U(src);

        /// <summary>
        /// Creates a 24-bit unsigned integer from the least 24 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint24(ushort src)
            => new U(src);

        /// <summary>
        /// Creates a 24-bit unsigned integer from the least 24 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint24(short src)
            => new U(src);

        /// <summary>
        /// Creates a 24-bit unsigned integer from the least 24 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint24(int src)
            => new U(src);

        /// <summary>
        /// Creates a 24-bit unsigned integer from the least 24 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint24(uint src)
            => new U(src);

        /// <summary>
        /// Creates a 24-bit unsigned integer from the least 24 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint24(long src)
            => new U(src);

        /// <summary>
        /// Creates a 24-bit unsigned integer from the least 24 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint24(ulong src)
            => new U(src);

        [MethodImpl(Inline), Op]
        public static U uint24(uint6 a, uint6 b, uint6 c, uint6 d)
        {
            var dst = new U();
            update(a | (b << 6) | (c << 12) | (d << 18), ref dst);
            return dst;
        }

        [MethodImpl(Inline)]
        public static ref uint24 update(uint src, ref uint24 dst)
        {
            dst = uint24(src);
            return ref dst;
        }

        /// <summary>
        /// Produces a <see cref='ushort'/> value by concatenating bits from two 8-bit segments
        /// </summary>
        /// <param name="b0">The first segment</param>
        /// <param name="b1">The second segment</param>
        [MethodImpl(Inline)]
        public static ushort join(byte b0, byte b1)
            => (ushort)(((uint)b0 | ((uint)b1 << 8)));

        /// <summary>
        /// Produces a <see cref='Z0.uint24'/> value by concatenating bits from three 8-bit segments
        /// </summary>
        /// <param name="b0">The first segment</param>
        /// <param name="b1">The second segment</param>
        /// <param name="b2">The third segment</param>
        [MethodImpl(Inline), Op]
        public static uint24 join(byte b0, byte b1, byte b2)
            => new uint24((uint)b0 | ((uint)b1 << 8) | ((uint)b2 << 16), true);

        [MethodImpl(Inline), Op]
        public static ushort seg16(N0 n, U src)
            => core.u16(src);

        [MethodImpl(Inline), Op]
        public static ushort seg16(N1 n, U src)
            => join(seg8(n1, src), seg8(n2,src));

        [MethodImpl(Inline), Op]
        public static byte seg8(N0 n, uint24 src)
            => skip(core.bytes(src),0);

        [MethodImpl(Inline), Op]
        public static byte seg8(N1 n, uint24 src)
            => skip(core.bytes(src), 1);

        [MethodImpl(Inline), Op]
        public static byte seg8(N2 n, uint24 src)
            => skip(core.bytes(src), 2);

        [MethodImpl(Inline), Op]
        public static ref byte seg8(N0 n, ref uint24 src)
            => ref seek(@as<uint24,byte>(src),0);

        [MethodImpl(Inline), Op]
        public static ref byte seg8(N1 n, ref uint24 src)
            => ref seek(@as<uint24,byte>(src),1);

        [MethodImpl(Inline), Op]
        public static ref byte seg8(N2 n, ref uint24 src)
            => ref seek(@as<uint24,byte>(src),2);

        [MethodImpl(Inline), Op]
        public static ref ushort seg16(N0 n, ref uint24 src)
            => ref @as<uint24,ushort>(src);

        [MethodImpl(Inline), Op]
        public static ref ushort seg16(N1 n, ref uint24 src)
            => ref @as<ushort>(seek(@as<uint24,byte>(src), 1));

        [MethodImpl(Inline), Op]
        public static U add(U x, U y)
            => x + y;

        [MethodImpl(Inline), Op]
        public static U sub(U x, U y)
            => x - y;

        [MethodImpl(Inline), Op]
        public static U div (U x, U y)
            => x / y;

        [MethodImpl(Inline), Op]
        public static U mod (U x, U y)
            => x % y;

        [MethodImpl(Inline), Op]
        public static U mul(U x, U y)
            => x * y;

        [MethodImpl(Inline), Op]
        public static U or(U x, U y)
            => x | y;

        [MethodImpl(Inline), Op]
        public static U and(U x, U y)
            => x & y;

        [MethodImpl(Inline), Op]
        public static U xor(U x, U y)
            => x ^ y;

        [MethodImpl(Inline), Op]
        public static U srl(U x, byte count)
            => x >> count;

        [MethodImpl(Inline), Op]
        public static U sll(U x, byte count)
            => x << count;

        [MethodImpl(Inline), Op]
        public static ref U inc(in U a)
        {
            ref var b = ref core.edit(a);
            b.Value++;

            if(b.Value > Mask)
                b.Value = 0;

            return ref b;
        }

        [MethodImpl(Inline), Op]
        public static ref U dec(in U a)
        {
            ref var b = ref core.edit(a);
            b.Value--;

            if(b.Value > Mask)
                b.Value = Mask;

            return ref b;
        }

        [MethodImpl(Inline), Op]
        public static bool eq(U a, U b)
            => a.Value == b.Value;

        static BitFormat FormatConfig24
            => BitFormatter.limited(U.PackedWidth, U.PackedWidth);

        [MethodImpl(Inline)]
        public static string format(U src)
            => BitRender.gformat(src.Value, FormatConfig24);

        [MethodImpl(Inline)]
        public static string format(U src, BitFormat config)
            => BitRender.gformat(src.Value, config);
    }
}