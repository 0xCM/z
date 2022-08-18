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
            => new GridRegion(upper, lower);

        [MethodImpl(Inline), Op]
        public static GridRegion region(uint upper, uint left, uint lower, uint right)
            => new GridRegion(point(upper,left), point(lower,right));


    }
}