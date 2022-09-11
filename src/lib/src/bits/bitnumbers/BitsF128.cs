//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiComplete]
    public struct BitsF128
    {
        Vector128<ulong> Data;

        public ulong LoBits
        {
            [MethodImpl(Inline)]
            get => Data.GetElement(0);
        }

        public ulong HiBits
        {
            [MethodImpl(Inline)]
            get => Data.GetElement(1);
        }

        [MethodImpl(Inline)]
        internal BitsF128(decimal src)
        {
            Data = sys.@as<decimal,Vector128<ulong>>(src);
        }
    }
}