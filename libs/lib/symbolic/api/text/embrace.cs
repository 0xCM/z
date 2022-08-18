//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        public static string embrace<T>(T src)
            => $"{Chars.LBrace}{src}{Chars.RBrace}";
    }
}