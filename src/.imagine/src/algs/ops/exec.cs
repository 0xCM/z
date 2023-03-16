//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        [MethodImpl(Inline), Op]
        public static void exec(params Action[] src)
            => iter(src, a => a(), true);

        [MethodImpl(Inline), Op]
        public static void exec(bool pll, params Action[] src)
            => iter(src, a => a(), pll);
    }
}