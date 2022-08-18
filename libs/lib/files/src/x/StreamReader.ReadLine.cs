//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static TextLine ReadLine(this StreamReader src, uint number)
            => new TextLine(number, src.ReadLine());
    }
}