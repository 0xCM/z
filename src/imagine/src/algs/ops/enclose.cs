//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static EnclosedSpan<T> enclose<T>(SeqEnclosureKind kind, char delimiter, ReadOnlySpan<T> src)
            => new EnclosedSpan<T>(src, kind, delimiter);

        [MethodImpl(Inline)]
        public static EnclosedSpan<T> enclose<T>(ReadOnlySpan<T> src)
            => enclose(SeqEnclosureKind.Embraced, Chars.Comma, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static EnclosedSpan<T> enclose<T>(SeqEnclosureKind kind, char delimiter, Span<T> src)
            => new EnclosedSpan<T>(src, kind, delimiter);

        [MethodImpl(Inline)]
        public static EnclosedSpan<T> enclose<T>(Span<T> src)
            => enclose(SeqEnclosureKind.Embraced, Chars.Comma, src);
   }
}