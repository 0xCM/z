//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    public class t_vlt : t_inx<t_vlt>
    {
        public void vlt_check()
        {

            check(n128);
            check(n256);
        }

        void check(N128 w)
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

        void check(N256 w)
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
                => CheckSVF.CheckBinaryOp(Calcs.vlt<T>(w), w, t);

        void v_check<T>(N256 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckBinaryOp(Calcs.vlt<T>(w), w, t);
    }
}