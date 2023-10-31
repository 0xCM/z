//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct grids
    {
        [MethodImpl(Inline), Op]
        public static GridRegion region(CellIndex upper, CellIndex lower)
            => new (upper, lower);

        [MethodImpl(Inline), Op]
        public static GridRegion region(uint upper, uint left, uint lower, uint right)
            => new (point(upper,left), point(lower,right));
    }
}