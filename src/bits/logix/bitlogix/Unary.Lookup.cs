//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static LogicSig;
    using static BitLogix;

    using ULK = UnaryBitLogicKind;

    partial class BitLogixOps
    {
        [Op]
        public static UnaryOp<bit> lookup(ULK kind)
        {
            switch(kind)
            {
                case ULK.False: return @false;
                case ULK.Not: return not;
                case ULK.Identity: return identity;
                case ULK.True: return @true;
                default: throw Unsupported.value(sig(kind));
            }
        }
    }
}