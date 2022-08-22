//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Seq
    {
        public static string format<T>(T[] src, char delimiter = Chars.Comma, int pad = 0)
            => Delimiting.delimit<T>(delimiter, pad, sys.@readonly(src)).Format();

        public static string format<T>(T[] src, string delimiter = ",", int pad = 0)
            => Delimiting.delimit(sys.@readonly(src), delimiter, pad);
    }
}