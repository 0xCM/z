//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        [MethodImpl(Inline), Op]
        public static Timestamp timestamp()
            => Timestamp.now();

        [MethodImpl(Inline), Op]
        public static Timestamp timestamp(ulong ticks)
            => new Timestamp(ticks);

        [MethodImpl(Inline), Op]
        public static Timestamp timestamp(long ticks)
            => new Timestamp((ulong)ticks);
    }
}