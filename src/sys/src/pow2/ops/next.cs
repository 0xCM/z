//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Pow2
    {
        [MethodImpl(Inline), Op]
        public static ulong next(ulong src)
            => pow((byte)(log(src) + 1));
    }
}