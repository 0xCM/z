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
        public static C code(in asci32 src, Hex5Kind index)
            => (C)skip(bytes(src), (byte)index);

        [MethodImpl(Inline), Op]
        public static asci32 init(N32 n, AsciCode fill = AsciCode.Space)
            => new asci32(cpu.vbroadcast(w256, (byte)fill));

        [MethodImpl(Inline), Op]
        public static asci32 init(N32 n, ReadOnlySpan<AsciCode> src)
            => new asci32(recover<AsciCode,byte>(src));

        /// <summary>
        /// Populates a 32-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static asci32 encode(N32 n, ReadOnlySpan<char> src)
            => encode(src, out asci32 dst);

        /// <summary>
        /// Presents the source content as a bytespan
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static Span<byte> bytes(in asci32 src)
            => src.Storage.ToSpan();

        /// <summary>
        /// Presents the leading source cell as a byte reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref byte @byte(in asci32 src)
            => ref @as<asci32,byte>(src);

        [MethodImpl(Inline), Op]
        public static bool contains(in asci32 src, char match)
            => AsciG.contains(src, (AsciCharSym)match);

        /// <summary>
        /// Returns the index of the first source element that matches a specified value
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="match">The value to match</param>
        [MethodImpl(Inline), Op]
        public static int index(in asci32 src, char match)
            => search(@byte(edit(src)), src.Capacity, (byte)match);

        /// <summary>
        /// Returns the index of the first source element that matches a specified value
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="match">The value to match</param>
        [MethodImpl(Inline), Op]
        public static int index(in asci32 src, byte match)
            => search(@byte(edit(src)), src.Capacity, match);

        /// <summary>
        /// Returns the index of the first source element that matches a specified value
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="match">The value to match</param>
        [MethodImpl(Inline), Op]
        public static int index(in asci32 src, AsciCode match)
            => search(@byte(edit(src)), src.Capacity, (byte)match);

        /// <summary>
        /// Counts the number of characters that precede a null terminator, if any
        /// </summary>
        /// <param name="src">The asci source</param>
        [MethodImpl(Inline), Op]
        public static int length(in asci32 src)
            => foundnot(index(src, z8), src.Capacity);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciSymbol> symbols(in asci32 src)
            => recover<AsciSymbol>(core.bytes(src));

        [MethodImpl(Inline), Op]
        public static void store(in asci32 src, Span<char> dst)
            => decode(src, ref first(dst));
    }
}