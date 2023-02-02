//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = AsciCode;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static int store(in asci4 src, Span<char> dst)
        {
            var data = Asci.symbols(src);
            seek(dst,0) = skip(data,0);
            seek(dst,1) = skip(data,1);
            seek(dst,2) = skip(data,2);
            seek(dst,3) = skip(data,3);
            return 4;
        }

        [MethodImpl(Inline), Op]
        public static asci4 init(N4 n)
            => new asci4(0x20202020);

        [MethodImpl(Inline), Op]
        public static asci4 init(N4 n, ReadOnlySpan<AsciCode> src)
            => new asci4(first(recover<AsciCode,asci4>(src)));

        [MethodImpl(Inline), Op]
        public static ref readonly asci4 view(N4 n, in uint src)
            => ref @as<uint,asci4>(src);

        [MethodImpl(Inline), Op]
        public static asci4 init(N4 n, ReadOnlySpan<byte> src)
            => view(n, first(recover<byte,uint>(src)));

        /// <summary>
        /// Counts the number of characters that precede a null terminator, if any
        /// </summary>
        /// <param name="src">The asci source</param>
        [MethodImpl(Inline), Op]
        public static int length(in asci4 src)
            => foundnot(index(src, z8), src.Capacity);

        /// <summary>
        /// Presents the source content as a bytespan
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static Span<byte> bytes(in asci4 src)
            => core.cover(@as<byte>(src.Storage), src.Length);

        /// <summary>
        /// Presents the leading source cell as a byte reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref byte @byte(in asci4 src)
            => ref @as<asci4,byte>(src);

        [MethodImpl(Inline), Op]
        public static char @char(in asci4 src, Hex2Kind index)
            => (char)code(src, index);

        [MethodImpl(Inline), Op]
        public static C code(in asci4 src, Hex2Kind index)
            => (C)(src.Storage >> (byte)index);

        [MethodImpl(Inline), Op]
        public static bool contains(asci4 src, char match)
            => AsciG.contains(src, (AsciCharSym)match);

        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci4 src, ref byte dst)
            => @as<byte,uint>(dst) = src.Storage;

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciSymbol> symbols(in asci4 src)
            => recover<AsciSymbol>(core.bytes(src));

        /// <summary>
        /// Encodes a 3-character asci sequence
        /// </summary>
        /// <param name="a">The first asci code</param>
        /// <param name="b">The second asci code</param>
        /// <param name="c">The third asci code</param>
        [MethodImpl(Inline), Op]
        public static asci4 define(AsciCode a, AsciCode b, AsciCode c)
            => new asci4(pack(a, b, c, out var _ ));

        /// <summary>
        /// Encodes a 4-character asci sequence
        /// </summary>
        /// <param name="a">The first asci code</param>
        /// <param name="b">The second asci code</param>
        /// <param name="c">The third asci code</param>
        /// <param name="d">The fourth asci code</param>
        [MethodImpl(Inline), Op]
        public static asci4 define(AsciCode c0, AsciCode c1, AsciCode c2, AsciCode c3)
            => new asci4(pack(c0,c1,c2,c3, out var dst));
   }
}