//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        /// <summary>
        /// Encloses text content between left and right braces
        /// </summary>
        /// <param name="src">The content to be embraced</param>
        [MethodImpl(Inline), Op]
        public static string embrace<T>(T src)
            => $"{Chars.LBrace}{src}{Chars.RBrace}";
    }
}