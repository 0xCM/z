//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitPatterns
    {
        [Op]
        public static Type datatype(in BitPattern src)
        {
            var w = bitwidth(src);
            var dst = typeof(void);
            if(w <= 8)
                dst = typeof(byte);
            else if(w <= 16)
                dst = typeof(ushort);
            else if(w <= 32)
                dst = typeof(uint);
            else if(w <= 64)
                dst = typeof(ulong);
            else if(w <= 128)
                dst = typeof(BitVector128<ulong>);
            else
                Throw.message("Width unsupported");
            return dst;
        }
    }
}