//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        [MethodImpl(Inline), Op]
        public static TypeCode ToTypeCode(this PrimalCode src)
            => (TypeCode)src;
    }
}