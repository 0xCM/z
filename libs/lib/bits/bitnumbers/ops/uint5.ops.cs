
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using U = uint5;
    using W = W5;

    partial struct BitNumbers
    {
        [MethodImpl(Inline), Op]
        public static bit test(U src, byte pos)
            => bit.test(src,pos);

        [MethodImpl(Inline), Op]
        public static U set(U src, byte pos, bit state)
            => Bytes.lt(pos, U.Width) ? new U(bit.set(src.Value, pos, state), false) : src;

        /// <summary>
        /// Reinterprets an input reference as a mutable <see cref='Z0.uint4'/> reference cell
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="dst">The target width selector</param>
        /// <typeparam name="S">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref U edit<S>(in S src, W dst)
            where S : unmanaged
                => ref @as<S,U>(src);

        /// <summary>
        /// Reinterprets an input reference as a mutable <see cref='Z0.uint5'/> reference cell
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="dst">The target width selector</param>
        /// <typeparam name="S">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref S edit<S>(in U src)
            where S : unmanaged
                => ref @as<U,S>(src);

        [MethodImpl(Inline), Op]
        public static U maxval(W w)
            => U.Max;

        [MethodImpl(Inline), Op]
        public static U dec(U x)
            => !x.IsMin ? new U(Bytes.sub(x.Value, 1), false) : Z0.uint5.Max;

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
        /// Creates a 5-bit unsigned integer, equal to zero or one, if the source value is respectively false or true
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint5(bool src)
            => wrap5(@byte(src));

        /// <summary>
        /// Creates a 5-bit unsigned integer from the least 5 bits of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint5(byte src)
            => new U(src);

        /// <summary>
        /// Creates a 5-bit unsigned integer from the least 5 bits of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint5(sbyte src)
            => new U(src);

        /// <summary>
        /// Creates a 5-bit unsigned integer from the least 5 bits of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint5(ushort src)
            => new U(src);

        /// <summary>
        /// Creates a 5-bit unsigned integer from the least 5 bits of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint5(short src)
            => new U(src);

        /// <summary>
        /// Creates a 5-bit unsigned integer from the least 5 bits of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint5(int src)
            => new U(src);

        /// <summary>
        /// Creates a 5-bit unsigned integer from the least 5 bits of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint5(uint src)
            => new U(src);

        /// <summary>
        /// Creates a 5-bit unsigned integer from the least 5 bits of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint5(long src)
            => new U(src);

        /// <summary>
        /// Creates a 5-bit unsigned integer from the least 5 bits of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint5(ulong src)
            => new U((byte)((byte)src & U.MaxValue));

        [MethodImpl(Inline), Op]
        public static U inc(U x)
            => !x.IsMax ? new U(core.add(x.Value, 1), false) : U.Min;

        [MethodImpl(Inline), Op]
        public static U add(U x, U y)
        {
            var d = (byte)(x.Value + y.Value);
            var result = Bytes.gteq(d, U.Mod) ? Bytes.sub(d, U.Mod) : d;
            return new U(result, true);
        }

        [MethodImpl(Inline), Op]
        public static U sub(U x, U y)
        {
            var delta = x.Value - y.Value;
            if(delta < 0)
                return wrap5((byte)(delta + U.Mod));
            else
                return wrap5((byte)delta);
        }

        [MethodImpl(Inline), Op]
        public static U div (U a, U b)
            => wrap5((byte)(a.Value / b.Value));

        [MethodImpl(Inline), Op]
        public static U mod (U lhs, U rhs)
            => wrap5((byte)(lhs.Value % rhs.Value));

        [MethodImpl(Inline), Op]
        public static U mul(U lhs, U rhs)
            => reduce5((byte)(lhs.Value * rhs.Value));

        [MethodImpl(Inline), Op]
        public static U or(U a, U b)
            => wrap5((byte)(a.Value | b.Value));

        [MethodImpl(Inline), Op]
        public static U and(U a, U b)
            => wrap5((byte)(a.Value & b.Value));

        [MethodImpl(Inline), Op]
        public static U xor(U lhs, U rhs)
            => wrap5((byte)(lhs.Value ^ rhs.Value));

        [MethodImpl(Inline), Op]
        public static U srl(U lhs, byte rhs)
            => uint5(lhs.Value >> rhs);

        [MethodImpl(Inline), Op]
        public static U sll(U lhs, byte rhs)
            => uint5(lhs.Value << rhs);

        [MethodImpl(Inline)]
        public static bool eq(U x, U y)
            => Bytes.eq(x.Value, y.Value);

        [MethodImpl(Inline)]
        public static byte crop5(byte x)
            => (byte)(U.MaxValue & x);

        [MethodImpl(Inline), Op]
        internal static byte reduce5(byte x)
            => (byte)(x % U.Mod);

        [MethodImpl(Inline)]
        internal static U wrap5(uint src)
            => new U(src,false);

        [MethodImpl(Inline)]
        internal static U wrap5(int src)
            => new U((byte)src,false);

        static BitFormat FormatConfig5
            => BitFormat.limited(U.Width,U.Width);

        [MethodImpl(Inline)]
        public static string format(U src)
            => BitRender.gformat(src.Value, FormatConfig5);

        [MethodImpl(Inline)]
        public static string format(U src, BitFormat config)
            => BitRender.gformat(src.Value, config);

        [MethodImpl(Inline), False]
        public static U @false(U a, U b)
            => U.Min;

        [MethodImpl(Inline), True]
        public static U @true(U a, U b)
            => U.Max;

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

        [MethodImpl(Inline), Op]
        public static Span<bit> bits(U src)
        {
            var storage = 0ul;
            var dst = slice(@recover<byte,bit>(@bytes(storage)),0, U.Width);
            if(bit.test(src,0))
                seek(dst,0) = bit.On;
            if(bit.test(src,1))
                seek(dst,1) = bit.On;
            if(bit.test(src,2))
                seek(dst,2) = bit.On;
            if(bit.test(src,3))
                seek(dst,3) = bit.On;
            if(bit.test(src,4))
                seek(dst,4) = bit.On;
            return dst;
        }
    }
}