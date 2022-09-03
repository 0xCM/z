//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Lines
    {
        [MethodImpl(Inline), Op]
        public static LineBlock block(in TextArea area, TextLine[] lines)
            => LineBlock.create(area,lines);

        [MethodImpl(Inline), Op]
        public static LineBlocks blocks(TextArea[] areas, TextLine[] lines)
            => LineBlocks.create(areas,lines);
    }
}