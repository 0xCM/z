//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        [MethodImpl(Inline), Op]
        public static TextLine line(uint number, string src)
            => new TextLine(number, src);
    }
}