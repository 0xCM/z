//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        public static void exec(params Action[] src)
            => iter(src, a => a(), true);

        public static void exec(bool pll, params Action[] src)
            => iter(src, a => a(), pll);
    }
}