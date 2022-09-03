//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CreditBits
    {
        [MethodImpl(Inline), Op]
        public static ContentRef page(ushort n)
            => new ContentRef(bit.set(n, 15, bit.On));
    }
}