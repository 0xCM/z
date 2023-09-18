//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Lines
    {
        [MethodImpl(Inline), Op]
        public static TextLine line(uint number, string content)
            => new (number, content);
    }
}