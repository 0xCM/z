//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Tables
    {
       [MethodImpl(Inline), Op]
        public static TableCell cell(object content)
            => new TableCell(content);
    }
}