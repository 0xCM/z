//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct UInt128
    {
        [MethodImpl(Inline), Inc]
        public static ref UInt128 inc(ref UInt128 x)
        {
            add(ref x, (1ul,0ul));
            return ref x;
        }
    }
}