//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        [Op]
        public static string enquote(string src)
            => sys.nonempty(src) ? string.Concat(Chars.Quote, src, Chars.Quote) : EmptyString;
   }
}