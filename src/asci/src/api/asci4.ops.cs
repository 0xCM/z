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
        /// <summary>
        /// Encodes a 3-character asci sequence as a <see cref='asci4'/> value
        /// </summary>
        /// <param name="a">The first asci character</param>
        /// <param name="b">The second asci character</param>
        /// <param name="c">The third asci character</param>
        [MethodImpl(Inline), Op]
        public static asci4 encode(N4 n, char a, char b, char c)
            => new asci4(AsciSymbols.pack((AsciCode)a, (AsciCode)b, (AsciCode)c, out var _ ));

        /// <summary>
        /// Encodes a 4-character asci sequence as a <see cref='asci4'/> value
        /// </summary>
        /// <param name="a">The first asci character</param>
        /// <param name="b">The second asci character</param>
        [MethodImpl(Inline), Op]
        public static asci4 encode(N4 n, char a, char b, char c, char d)
            => new asci4(AsciSymbols.pack((AsciCode)a, (AsciCode)b, (AsciCode)c, (AsciCode)d, out var _ ));

        /// <summary>
        /// Populates an asci target with a specified number of source characters
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of characters to encode</param>
        /// <param name="dst">The receiver</param>
        [MethodImpl(Inline), Op]
        public static asci4 encode(in char src, byte count, out asci4 dst)
        {
            dst = asci4.Null;
            ref var storage = ref Unsafe.As<asci4,AsciCode>(ref dst);
            AsciSymbols.codes(src, (byte)count, ref storage);
            return dst;
        }

        /// <summary>
        /// Populates a 4-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        [MethodImpl(Inline), Op]
        public static asci4 encode(ReadOnlySpan<char> src, out asci4 dst)
        {
            dst = default;
            AsciSymbols.codes(src, span<asci4,AsciCode>(ref dst));
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static asci4 render2(byte src, out asci4 dst)
        {
            dst = new asci4(
                BitRender.bitchar(src, 1),
                BitRender.bitchar(src, 0)
            );
            return dst;
        }

        /// <summary>
        /// Populates a 4-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static asci4 encode(N4 n, ReadOnlySpan<char> src)
            => encode(src, out asci4 dst);

        [MethodImpl(Inline), Op]
        public static string decode(asci4 src)
        {
            var storage = 0ul;
            ref var dst = ref @as<ulong,char>(storage);
            seek(dst, 0) = (char)(byte)(src.Storage >> 0);
            seek(dst, 1) = (char)(byte)(src.Storage >> 8);
            seek(dst, 2) = (char)(byte)(src.Storage >> 16);
            seek(dst, 3) = (char)(byte)(src.Storage >> 24);
            return sys.@string(slice(sys.cover(dst, asci4.Size),0, src.Length));
        }


        [MethodImpl(Inline), Op]
        public static int store(asci4 src, Span<char> dst)
        {
            var data = Asci.symbols(src);
            seek(dst,0) = skip(data,0);
            seek(dst,1) = skip(data,1);
            seek(dst,2) = skip(data,2);
            seek(dst,3) = skip(data,3);
            return 4;
        }

        [MethodImpl(Inline)]
        public static ref readonly asci4 cast<A>(N4 n, in A src)
            where A : unmanaged, IByteSeq
                => ref @as<A,asci4>(src);


        /// <summary>
        /// Returns the index of the first source element that matches a specified value
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="match">The value to match</param>
        [MethodImpl(Inline), Op]
        public static int index(in asci4 src, byte match)
            => AsciSymbols.search(@byte(edit(src)), src.Capacity, match);

        /// <summary>
        /// Returns the index of the first source element that matches a specified value
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="match">The value to match</param>
        [MethodImpl(Inline), Op]
        public static int index(in asci4 src, char match)
            => AsciSymbols.search(@byte(edit(src)), src.Capacity, (byte)match);

        /// <summary>
        /// Returns the index of the first source element that matches a specified value
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="match">The value to match</param>
        [MethodImpl(Inline), Op]
        public static int index(in asci4 src, AsciCode match)
            => AsciSymbols.search(@byte(edit(src)), src.Capacity, (byte)match);

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
            => sys.cover(@as<byte>(src.Storage), src.Length);

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
            => AsciSymbols.contains(src, (AsciCharSym)match);

        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci4 src, ref byte dst)
            => @as<byte,uint>(dst) = src.Storage;

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciSymbol> symbols(in asci4 src)
            => recover<AsciSymbol>(sys.bytes(src));

        /// <summary>
        /// Encodes a 3-character asci sequence
        /// </summary>
        /// <param name="a">The first asci code</param>
        /// <param name="b">The second asci code</param>
        /// <param name="c">The third asci code</param>
        [MethodImpl(Inline), Op]
        public static asci4 define(AsciCode a, AsciCode b, AsciCode c)
            => new asci4(AsciSymbols.pack(a, b, c, out var _ ));

        /// <summary>
        /// Encodes a 4-character asci sequence
        /// </summary>
        /// <param name="a">The first asci code</param>
        /// <param name="b">The second asci code</param>
        /// <param name="c">The third asci code</param>
        /// <param name="d">The fourth asci code</param>
        [MethodImpl(Inline), Op]
        public static asci4 define(AsciCode c0, AsciCode c1, AsciCode c2, AsciCode c3)
            => new asci4(AsciSymbols.pack(c0,c1,c2,c3, out var dst));
   }
}