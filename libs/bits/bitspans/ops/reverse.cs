//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitSpans
    {
        [MethodImpl(Inline), Op]
        public static ref readonly BitSpan reverse(in BitSpan src)
        {
            src.Storage.Reverse();
            return ref src;
        }
    }
}