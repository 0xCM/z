//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Lines
    {
        [MethodImpl(Inline), Op]
        public static LineRange range(uint min, uint max, TextLine[] src)
            => new LineRange(min, max, src);
    }
}