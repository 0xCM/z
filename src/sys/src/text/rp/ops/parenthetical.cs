//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        /// <summary>
        /// Encloses content between '(' and ')' characters
        /// </summary>
        /// <param name="content">The items to be enclosed</param>
        [Op]
        public static string parenthetical(params object[] content)
            => enclose(string.Concat(content.Select(x => x.ToString())), Chars.LParen, Chars.RParen);

        public static Fence<char> Parenthetical => fence(Chars.LBrace, Chars.RBrace);

    }
}