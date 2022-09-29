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
        public static C code(in asci2 src, Hex1Kind index)
            => (C)(src.Storage >> (byte)index);

        /// <summary>
        /// Presents the source content as a bytespan
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static Span<byte> bytes(in asci2 src)
            => cover(@as<byte>(src.Storage), src.Length);

        /// <summary>
        /// Encodes a 2-character asci sequence
        /// </summary>
        /// <param name="a">The first asci code</param>
        /// <param name="b">The second asci code</param>
        [MethodImpl(Inline), Op]
        public static asci2 define(AsciCode a, AsciCode b)
            => new asci2(Asci.pack(a,b));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciSymbol> symbols(in asci2 src)
            => recover<AsciSymbol>(core.bytes(src));

        /// <summary>
        /// Counts the number of characters that precede a null terminator, if any
        /// </summary>
        /// <param name="src">The asci source</param>
        [MethodImpl(Inline), Op]
        public static int length(in asci2 src)
            => foundnot(search(src, z8), src.Capacity);

        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci2 src, ref byte dst)
            => @as<byte,ushort>(dst) = src.Storage;

        [MethodImpl(Inline), Op]
        public static char @char(in asci2 src, Hex1Kind index)
            => (char)code(src, index);

        [MethodImpl(Inline), Op]
        public static ref readonly asci2 view(N2 n, in ushort src)
            => ref @as<ushort,asci2>(src);

        [MethodImpl(Inline), Op]
        public static asci2 init(N2 n)
            => new asci2(0x2020);

        [MethodImpl(Inline)]
        public static asci2 init(N2 n, ReadOnlySpan<AsciCode> src)
            => new asci2(first(recover<AsciCode,ushort>(src)));

        [MethodImpl(Inline), Op]
        public static asci2 init(N2 n, ReadOnlySpan<byte> src)
            => view(n, first(recover<byte,ushort>(src)));

        [MethodImpl(Inline), Op]
        public static int store(in asci2 src, Span<char> dst)
        {
            var data = Asci.symbols(src);
            seek(dst,0) = skip(data,0);
            seek(dst,1) = skip(data,1);
            return 2;
        }

        /// <summary>
        /// Encodes a 2-character asci sequence
        /// </summary>
        /// <param name="a">The first asci character</param>
        /// <param name="b">The second asci character</param>
        [MethodImpl(Inline), Op]
        public static asci2 encode(char a, char b)
            => new asci2(Asci.pack((AsciCode)a, (AsciCode)b));

        /// <summary>
        /// Populates a 2-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static asci2 encode(N2 n, ReadOnlySpan<char> src)
            => encode(src, out asci2 dst);

        /// <summary>
        /// Populates an asci target with a specified number of source characters
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of characters to encode</param>
        /// <param name="dst">The receiver</param>
        [MethodImpl(Inline), Op]
        public static ref readonly asci2 encode(in char src, byte count, out asci2 dst)
        {
            dst = asci2.Null;
            ref var codes = ref Unsafe.As<asci2,AsciCode>(ref dst);
            AsciSymbols.codes(src, (byte)count, ref codes);
            return ref dst;
        }

        /// <summary>
        /// Populates a 2-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        [MethodImpl(Inline), Op]
        public static ref readonly asci2 encode(ReadOnlySpan<char> src, out asci2 dst)
        {
            dst = default;
            AsciSymbols.codes(src, span<asci2,AsciCode>(ref dst));
            return ref dst;
        }

        /// <summary>
        /// Presents the leading source cell as a byte reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref byte @byte(in asci2 src)
            => ref @as<asci2,byte>(src);
    }
}