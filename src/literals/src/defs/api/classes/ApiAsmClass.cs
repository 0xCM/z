//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;

    using Id = ApiClassKind;

    [ApiClass, SymSource(api_classes)]
    public enum ApiAsmClass : ushort
    {
        None = 0,

        PAVGB = Id.PAVGB,

        PAVGW = Id.PAVGW,

        VPAVGB = Id.VPAVGB,

        VPAVGW = Id.VPAVGW,

        VPERMD = Id.VPERMD,

        VPERMPS = Id.VPERMPS,

        VPERMQ = Id.VPERMQ,

        VPERMPD = Id.VPERMPD,
    }
}