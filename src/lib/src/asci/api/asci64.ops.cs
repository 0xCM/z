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
        public static asci64 init(N64 n, ReadOnlySpan<AsciCode> src)
            => new asci64(recover<AsciCode,byte>(src));

        [MethodImpl(Inline), Op]
        public static asci64 init(N64 n, AsciCode fill = AsciCode.Space)
            => new asci64(cpu.vbroadcast(w512, (byte)fill));

        [MethodImpl(Inline), Op]
        public static C code(in asci64 src, Hex6Kind index)
            => (C)skip(bytes(src), (byte)index);

        /// <summary>
        /// Presents the source content as a bytespan
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static Span<byte> bytes(in asci64 src)
            => src.Storage.ToSpan();

        [MethodImpl(Inline), Op]
        public static bool contains(in asci64 src, char match)
            => contains(src, (AsciCharSym)match);

        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci64 src, ref byte dst)
            => vcpu.vstore(src.Storage, ref dst);

        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci64 src, Span<byte> dst)
            => vcpu.vstore(src.Storage, dst);

        /// <summary>
        /// Presents the leading source cell as a byte reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref byte @byte(in asci64 src)
            => ref @as<asci64,byte>(src);

        /// <summary>
        /// Counts the number of characters that precede a null terminator, if any
        /// </summary>
        /// <param name="src">The asci source</param>
        [MethodImpl(Inline), Op]
        public static int length(in asci64 src)
            => foundnot(index(src, z8), src.Capacity);

        [MethodImpl(Inline), Op]
        public static void store(in asci64 src, Span<char> dst)
            => decode(src, ref first(dst));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciSymbol> symbols(in asci64 src)
            => recover<AsciSymbol>(sys.bytes(src));
    }
}