//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using U = uint7;
    using W = W7;

    partial struct BitNumbers
    {
        [MethodImpl(Inline), Op]
        public static bit test(U src, byte pos)
            => bit.test(src,pos);

        [MethodImpl(Inline), Op]
        public static U set(U src, byte pos, bit state)
        {
            if(pos < U.Width)
                return wrap7(bit.set(src.Value, pos, state));
            else
                return src;
        }

        [MethodImpl(Inline), Op]
        public static void render(U src, uint offset, Span<char> dst)
            => render(src, 7, offset, dst);

        [MethodImpl(Inline), Op]
        public static void render(U src, Span<char> dst)
            => render(src, 7, 0, dst);

        [MethodImpl(Inline), Op]
        public static U maxval(W w)
            => U.Max;

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
        /// Reinterprets an input reference as a mutable <see cref='Z0.uint7'/> reference cell
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="dst">The target width selector</param>
        /// <typeparam name="S">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref U edit<S>(in S src, W dst)
            where S : unmanaged
                => ref @as<S,U>(src);

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
        public static ref K refine<K>(in uint7 src)
            where K : unmanaged, Enum
                => ref @as<uint7,K>(src);

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
        [MethodImpl(Inline), Op]
        public static U inject(byte src, W w)
            => new U(src, false);

        /// <summary>
        /// Creates a 7-bit unsigned integer, equal to zero or one, according to whether the source is respectively false or true
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint7(bool src)
            => new U(@byte(src));

        /// <summary>
        /// Creates a 7-bit unsigned integer from the least 7 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint7(byte src)
            => new U(src);

        /// <summary>
        /// Creates a 7-bit unsigned integer from the least 7 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint7(sbyte src)
            => new U(src);

        /// <summary>
        /// Creates a 7-bit unsigned integer from the least 7 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint7(ushort src)
            => new U(src);

        /// <summary>
        /// Creates a 7-bit unsigned integer from the least 7 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint7(short src)
            => new U(src);

        /// <summary>
        /// Creates a 7-bit unsigned integer from the least 7 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint7(int src)
            => new U(src);

        /// <summary>
        /// Creates a 7-bit unsigned integer from the least 7 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint7(uint src)
            => new U(src);

        /// <summary>
        /// Creates a 7-bit unsigned integer from the least 7 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint7(long src)
            => new U(src);

        /// <summary>
        /// Creates a 7-bit unsigned integer from the least 7 source bits
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static U uint7(ulong src)
            => new U((byte)((byte)src & U.MaxValue));

        /// <summary>
        /// Constructs a uint7 value from a sequence of bits ranging from low to high
        /// </summary>
        /// <param name="x0">The first/least bit value, if specified; otherwise, defaults to 0</param>
        /// <param name="x1">The second bit value, if specified; otherwise, defaults to 0</param>
        /// <param name="x2">The third bit value, if specified; otherwise, defaults to 0</param>
        /// <param name="x3">The fourth/highest bit value, if specified; otherwise, defaults to 0</param>
        [MethodImpl(Inline), Op]
        public static U uint7(bit x0, bit x1 = default, bit x2 = default, bit x3 = default, bit x4 = default, bit x5 = default, bit x6 = default)
             => wrap7(((uint)x0 << 0) | ((uint)x1 << 1) | ((uint)x2 << 2) | ((uint)x3 << 3) | ((uint)x4 << 4) | ((uint)x5 << 5) | ((uint)x6 << 6));

        [MethodImpl(Inline), Op]
        public static U add(U x, U y)
        {
            var sum = (byte)(x.Value + y.Value);
            return wrap7((sum >= U.Mod) ? (byte)(sum - U.Mod): sum);
        }

        [MethodImpl(Inline), Op]
        public static U sub(U a, U b)
        {
            var diff = (int)a - (int)b;
            return wrap7(diff < 0 ? (uint)(diff + U.Mod) : (uint)diff);
        }

        [MethodImpl(Inline), Op]
        public static U div (U a, U b)
            => wrap7((byte)(a.Value / b.Value));

        [MethodImpl(Inline), Op]
        public static U mod (U a, U b)
            => wrap7((byte)(a.Value % b.Value));

        [MethodImpl(Inline), Op]
        public static U mul(U a, U b)
            => reduce7((byte)(a.Value * b.Value));

        [MethodImpl(Inline), Op]
        public static U and(U a, U b)
            => wrap7((byte)(a.Value & b.Value));

        [MethodImpl(Inline), Op]
        public static U or(U a, U b)
            => wrap7((byte)(a.Value | b.Value));

        [MethodImpl(Inline), Op]
        public static U xor(U a, U b)
            => wrap7((byte)(a.Value ^ b.Value));

        [MethodImpl(Inline), Op]
        public static U srl(U a, byte b)
            => uint7(a.Value >> b);

        [MethodImpl(Inline), Op]
        public static U sll(U a, byte b)
            => uint7(a.Value << b);


        [MethodImpl(Inline)]
        public static bool eq(U x, U y)
            => x.Value == y.Value;

        [MethodImpl(Inline)]
        public static byte crop7(byte x)
            => (byte)(U.MaxValue & x);

        [MethodImpl(Inline), Op]
        internal static byte reduce7(byte x)
            => (byte)(x % U.Mod);

        [MethodImpl(Inline)]
        internal static U wrap7(byte src)
            => new U(src,false);

        [MethodImpl(Inline)]
        internal static U wrap7(uint src)
            => new U(src,false);

        static BitFormat FormatConfig7
            => BitFormatter.limited(U.Width, U.Width);

        [MethodImpl(Inline)]
        public static string format(U src)
            => BitRender.gformat(src.Value, FormatConfig7);

        [MethodImpl(Inline)]
        public static string format(U src, BitFormat config)
            => BitRender.gformat(src.Value, config);

        /// <summary>
        /// Promotes a <see cref='U2'/> to a <see cref='Z0.uint7'/>, as indicated by the <see cref='W7'/> selector
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint7 extend(W7 w, uint2 src)
            => new U(src.Value);

        [MethodImpl(Inline), Op]
        public static Span<bit> bits(uint24 src)
        {
            var storage = 0u;
            var dst = recover<bit>(bytes(storage));
            bits(src,dst);
            return slice(dst,0,3);
        }

        [MethodImpl(Inline), Op]
        public static uint bits(uint24 src, Span<bit> dst)
        {
            var input = @readonly((bytes((uint)src).ToBitString()[0,23]).BitSeq);
            //var input = @readonly(recover<bit>((((uint)src).ToBitVector32().ToBitString()[0,23]).BitSeq));
            seek64(dst,0) = skip64(input,0);
            seek64(dst,1) = skip64(input,1);
            seek64(dst,2) = skip64(input,2);
            return 24;
        }
    }
}