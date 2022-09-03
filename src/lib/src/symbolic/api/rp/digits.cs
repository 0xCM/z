//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct RpOps
    {
        /// <summary>
        /// Encloses text content between left and right braces
        /// </summary>
        /// <param name="src">The content to be embraced</param>
        [MethodImpl(Inline), Op]
        public static string embrace<T>(T src)
            => $"{Chars.LBrace}{src}{Chars.RBrace}";

        [Op]
        public static string digits(byte n)
            => embrace($"0:D{n}");

        public static string digits(byte index, byte n)
            => Chars.LBrace + $"{index}:D{n}" + Chars.RBrace;
    }
}