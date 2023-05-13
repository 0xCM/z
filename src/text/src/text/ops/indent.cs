//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        static string padding(uint width)
            => new string(Chars.Space, (int)width);

        public static string indent<T>(uint offset, T src)
            => string.Format("{0}{1}", padding(offset), src);
    }
}