//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Seq
    {
        public static string format<T>(T[] src, string delimiter = ",", int pad = 0, Fence<char>? fence = null)
            => Delimiting.format(sys.@readonly(src), delimiter, pad);
    }
}