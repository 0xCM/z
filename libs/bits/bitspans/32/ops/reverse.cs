//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

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