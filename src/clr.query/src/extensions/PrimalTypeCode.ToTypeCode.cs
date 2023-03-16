//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        [MethodImpl(Inline)]
        public static EcmaHandleData Data(this Handle src)
            => EcmaHandleData.from(src);

        [MethodImpl(Inline), Op]
        public static TypeCode ToTypeCode(this PrimalCode src)
            => (TypeCode)src;
    }
}