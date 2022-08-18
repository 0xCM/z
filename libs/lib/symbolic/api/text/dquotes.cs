//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        [Op]
        public static string dquote(string src)
            => nonempty(src) ? string.Concat(Chars.Quote, src, Chars.Quote) : EmptyString;

        [Op, Closures(Closure)]
        public static string dquote<T>(T src)
            => $"{Chars.Quote}{src}{Chars.Quote}";
   }
}