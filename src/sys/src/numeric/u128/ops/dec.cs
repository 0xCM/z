//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct UInt128
    {
        [MethodImpl(Inline), Dec]
        public static ref UInt128 dec(ref UInt128 x)
        {
            sub(ref x, (1ul,0ul));
            return ref x;
        }
    }
}