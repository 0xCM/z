//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using ULK = UnaryBitLogicKind;

    partial class BitLogixOps
    {
        [MethodImpl(Inline), Op]
        public static bit eval(ULK kind, bit a)
        {
            if(kind == ULK.False)
                return bit.Off;
            else if(kind == ULK.Not)
                return bit.not(a);
            else if(kind == ULK.Identity)
                return a;
            else if(kind == ULK.True)
                return bit.On;
            else
                return Unsupported.raise<bit>();
        }
    }
}