//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct zUInt128
    {
        [MethodImpl(Inline), Dec]
        public static ref zUInt128 dec(ref zUInt128 x)
        {
            sub(ref x, (1ul,0ul));
            return ref x;
        }
    }
}