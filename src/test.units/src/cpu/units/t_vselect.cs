//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_vselect : t_inx<t_vselect>
    {
        public void vselect_check()
        {
            vselect_check(n128);
            vselect_check(n256);
        }

        void vselect_check(N128 w)
        {
            vselect_check(w, z8);
            vselect_check(w, z16);
            vselect_check(w, z32);
            vselect_check(w, z64);
        }

        void vselect_check(N256 w)
        {
            vselect_check(w, z8);
            vselect_check(w, z16);
            vselect_check(w, z32);
            vselect_check(w, z64);
        }

        void vselect_check<T>(N128 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckTernaryOp(Calcs.vselect(w,t), w, t);

        void vselect_check<T>(N256 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckTernaryOp(Calcs.vselect(w,t), w, t);
     }
}
