//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;


    public class t_bitstring_convert : t_bits<t_bitstring_convert>
    {
        /// <summary>
        /// Loads a bitblock from a bitstring
        /// </summary>
        /// <param name="src">The bitstring source</param>
        [MethodImpl(Inline)]
        public static BitBlock<T> biblock<T>(BitString src)
            where T : unmanaged
                => BitBlocks.load<T>(src.ToPackedBytes(), (uint)src.Length);

        public void bitspan_from_bitstring_check<T>()
            where T : unmanaged
        {
            for(var i=0; i< RepCount; i++)
            {
                var bs = Random.BitString(5,233);
                var bc = biblock<T>(bs);
                Claim.eq(bs.Length, bc.BitCount);
                for(var j=0; j<bs.Length; j++)
                {
                    if(bc[j] != bs[j])
                    {
                        Trace("bs", bs.Format());
                        Trace("bc", bc.Format());
                    }
                    Claim.eq(bc[j],bs[j]);
                }
            }
        }

        public void bsp_16u_from_bs()
            => bitspan_from_bitstring_check<ushort>();

        public void bsp_32u_from_bs()
            => bitspan_from_bitstring_check<uint>();

        public void bsp_64u_from_bs()
            => bitspan_from_bitstring_check<ulong>();
    }
}