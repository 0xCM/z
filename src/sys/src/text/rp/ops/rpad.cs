//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        [MethodImpl(Inline), Op]
        public static string rpad(string src, int width, char c = ' ')
            => src.PadRight(width, c);

        [MethodImpl(Inline), Op]
        public static string rspace(object content)
            => $"{content} ";
    }
}