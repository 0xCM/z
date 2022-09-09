//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Options), Op]
        public static void prepare(RuntimeMethodHandle src)
            => RuntimeHelpers.PrepareMethod(src);

        [MethodImpl(Options), Op]
        public static void prepare(Delegate src)
            => RuntimeHelpers.PrepareDelegate(src);
    }
}