//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct bit
    {
        [MethodImpl(Inline), Op]
        public static ulong align(ulong bits, ulong factor)
            => bits + (bits % factor);

        [MethodImpl(Inline), Op]
        public static long align(long bits, long factor)
            => bits + (bits % factor);
    }
}