//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_vbyteswap : t_inx<t_vbyteswap>
    {
        public void vbyteswap_outline()
        {
            var x16 = cpu.vparts(n128,
                0b0000000011111111, 0b1111111100000000,
                0b1100110000110011, 0b0011001111001100,
                0b1000000000000000, 0b0000000010000000,
                0b0000011100000111, 0b0000011100000111
                );

            var y16 = cpu.vparts(n128,
                0b1111111100000000, 0b0000000011111111,
                0b0011001111001100, 0b1100110000110011,
                0b0000000010000000, 0b1000000000000000,
                0b0000011100000111, 0b0000011100000111
                );

            var z16 = cpu.vbyteswap(x16);
            var z16s = z16.ToSpan();

            Claim.veq(y16,z16);
            for(var i=0; i<z16s.Length; i+= 2)
                Claim.eq(bits.byteswap(z16s[i]), z16s[i+1]);

            var x32 = cpu.vparts(n128,
                0xFFFF0000, 0x0000FFFF,
                0xFF000000, 0x000000FF
                );
            var y32 = cpu.vparts(n128,
                0x0000FFFF, 0xFFFF0000,
                0x000000FF, 0xFF000000
                );

            var z32 = cpu.vbyteswap(x32);
            Claim.veq(y32,z32);
        }

        public void vbyteswap_check()
        {
            vbyteswap_check(n128);
            vbyteswap_check(n256);
        }

        void vbyteswap_check(N128 w)
        {
            vbyteswap_check(w,z16);
            vbyteswap_check(w,z32);
            vbyteswap_check(w,z64);
        }

        void vbyteswap_check(N256 w)
        {
            vbyteswap_check(w,z16);
            vbyteswap_check(w,z32);
            vbyteswap_check(w,z64);
        }

        void vbyteswap_check<T>(N128 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckUnaryOp(Calcs.vbyteswap<T>(w),w,t);

        void vbyteswap_check<T>(N256 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckUnaryOp(Calcs.vbyteswap<T>(w),w,t);
    }
}