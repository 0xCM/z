//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static AsciLineReader AsciLineReader(this FileUri src)
            => new AsciLineReader(new StreamReader(src.LocalPath));

        public static void AddRange<T>(this HashSet<T> dst, IEnumerable<T> src)
            => sys.iter(src, item=> dst.Add(item));

        [Op]
        public static LineReader Utf8LineReader(this FileUri src)
            => new LineReader(FileUriOps.reader(src, UTF8));

        [MethodImpl(Inline), Op]
        public static LineReader ToLineReader(this StreamReader src)
            => new LineReader(src);

        /// <summary>
        /// Reads the full content of a file into a byte array
        /// </summary>
        /// <param name="src">The file path</param>
        public static byte[] ReadBytes(this FileUri src)
            => src.Exists ? File.ReadAllBytes(src.Format()) : sys.empty<byte>();
    }

    partial class XTend
    {
        [MethodImpl(Inline)]
        public static int FirstIndexOf<T>(this T src, AsciCharSym match)
            where T : unmanaged,IAsciSeq
                => AsciSymbols.index(src, match);

        [MethodImpl(Inline)]
        public static bool Contains<T>(this T src, AsciCharSym match)
            where T : unmanaged,IAsciSeq
                => AsciSymbols.contains(src, match);

        public static string Format(this ReadOnlySpan<AsciCode> src)
            => AsciSymbols.format(src);

        public static string Format(this Span<AsciCode> src)
            => AsciSymbols.format(src);

        public static string Format(this ReadOnlySpan<AsciSymbol> src)
            => AsciSymbols.format(src);

        public static string Format(this Span<AsciSymbol> src)
            => AsciSymbols.format(src);
    }
}