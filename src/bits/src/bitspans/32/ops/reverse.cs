//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitSpans32
    {
        [MethodImpl(Inline), Op]
        public static ref readonly BitSpan32 reverse(in BitSpan32 src)
        {
            src.Edit.Reverse();
            return ref src;
        }
    }
}