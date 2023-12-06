//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct zUInt128
    {
        [MethodImpl(Inline), Inc]
        public static ref zUInt128 inc(ref zUInt128 x)
        {
            add(ref x, (1ul,0ul));
            return ref x;
        }
    }
}