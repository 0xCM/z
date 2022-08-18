//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        [MethodImpl(Inline)]
        public static PrimalCode ToKind(this TypeCode src)
            => (PrimalCode)src;
    }
}