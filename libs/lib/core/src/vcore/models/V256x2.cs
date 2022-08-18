//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;

    public struct V256x2
    {
        Vector256<ushort> X0;

        Vector256<ushort> X1;

        [MethodImpl(Inline), Op]
        public V256x2(Vector256<ushort> x0, Vector256<ushort> x1)
        {
            X0 = x0;
            X1 = x1;
        }
    }
}