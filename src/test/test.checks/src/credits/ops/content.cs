//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using D = CreditModel.DocFieldDelimiter;
    using F = CreditModel.DocField;

    partial class CreditBits
    {
        [MethodImpl(Inline), Op]
        public static ContentRef content(DocRef src)
            => (ushort)(((ulong)F.Content & (ulong)src) >> (int)D.Content);

        [MethodImpl(Inline), Op]
        public static DocRef content(ContentRef src)
            => (ulong)src << (byte)D.Content;

        public static string format(ContentRef src)
        {
            if(src.IsNonEmpty)
            {
                var l0 = (byte)src.Level0;
                var l1 = (byte)src.Level1;
                var l2 = (byte)src.Level2;
                return text.concat(src.ContentType, ':', l0, '.', l1, '.', l2);
            }
            else
                return string.Empty;
        }

        const char DotSep = (char)SymNotKind.Dot;

        const char UriSep = (char)SymNotKind.FSlash;
    }
}