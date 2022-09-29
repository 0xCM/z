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
        public static C code(in asci8 src, Hex3Kind index)
            => (C)(src.Storage >> (byte)index);


        [MethodImpl(Inline), Op]
        public static void decode(in asci8 src, ref char dst)
        {
            var decoded = vpack.vinflate256x16u(cpu.vbytes(w128, src.Storage));
            cpu.vstore(decoded.GetLower(), ref @as<char,ushort>(dst));
        }

        /// <summary>
        /// Counts the number of characters that precede a null terminator, if any
        /// </summary>
        /// <param name="src">The asci source</param>
        [MethodImpl(Inline), Op]
        public static int length(in asci8 src)
            => foundnot(index(src, z8), src.Capacity);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in asci8 src)
            => slice(recover<char>(core.bytes(cpu.vlo(vpack.vinflate256x16u(cpu.vbytes(w128, src.Storage))))), 0, src.Length);

        [MethodImpl(Inline), Op]
        public static void decode(N8 n, ReadOnlySpan<byte> src, Span<char> dst)
            => cpu.vstore(vpack.vinflate256x16u(cpu.v8u(cpu.vscalar(w128, @as<ulong>(core.first(src))))), ref @as<ushort>(core.first(dst)));

        /// <summary>
        /// Presents the source content as a bytespan
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static Span<byte> bytes(in asci8 src)
            => core.cover(@as<byte>(src.Storage), src.Length);

        [MethodImpl(Inline), Op]
        public static ref readonly asci8 view(N8 n, in ulong src)
            => ref @as<ulong,asci8>(src);

        [MethodImpl(Inline), Op]
        public static void store(in asci8 src, Span<char> dst)
            => decode(src, ref first(dst));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciSymbol> symbols(in asci8 src)
            => recover<AsciSymbol>(core.bytes(src));

        [MethodImpl(Inline), Op]
        public static asci8 init(N8 n, AsciCode fill = AsciCode.Space)
            => new asci8(gcpu.vlo64(cpu.vbroadcast(w128, (byte)fill)));

        [MethodImpl(Inline), Op]
        public static asci8 init(N8 n, ReadOnlySpan<AsciCode> src)
            => new asci8(first(recover<AsciCode,asci8>(src)));

        [MethodImpl(Inline), Op]
        public static asci8 init(N8 n, ReadOnlySpan<byte> src)
            => view(n, first(recover<byte,uint>(src)));

        /// <summary>
        /// Returns the index of the first source element that matches a specified value
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="match">The value to match</param>
        [MethodImpl(Inline), Op]
        public static int index(in asci8 src, byte match)
            => search(@byte(edit(src)), src.Capacity, match);

        /// <summary>
        /// Returns the index of the first source element that matches a specified value
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="match">The value to match</param>
        [MethodImpl(Inline), Op]
        public static int index(in asci8 src, AsciCode match)
            => search(@byte(edit(src)), src.Capacity, (byte)match);

        [MethodImpl(Inline), Op]
        public static bool contains(asci8 src, char match)
            => AsciG.contains(src, (AsciCharSym)match);

        [MethodImpl(Inline), Op]
        public static char @char(in asci8 src, Hex3Kind index)
            => (char)code(src, index);

        /// <summary>
        /// Presents the leading source cell as a byte reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref byte @byte(in asci8 src)
            => ref @as<asci8,byte>(src);
    }
}