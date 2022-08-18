//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_vgt : t_inx<t_vgt>
    {
        public void vgt_check()
        {
            vgt_check(n128);
            vgt_check(n256);
        }

        void vgt_check(N128 w)
        {
            v_check(w, z8);
            v_check(w, z8i);
            v_check(w, z16);
            v_check(w, z16i);
            v_check(w, z32);
            v_check(w, z32i);
            v_check(w, z64);
            v_check(w, z64i);
        }

        void vgt_check(N256 w)
        {
            v_check(w, z8);
            v_check(w, z8i);
            v_check(w, z16);
            v_check(w, z16i);
            v_check(w, z32);
            v_check(w, z32i);
            v_check(w, z64);
            v_check(w, z64i);
        }

        void v_check<T>(N128 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckBinaryOp(Calcs.vgt<T>(w), w, t);

        void v_check<T>(N256 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckBinaryOp(Calcs.vgt<T>(w), w, t);
    }
}