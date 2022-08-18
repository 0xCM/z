//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;

    public class t_vmax : t_inx<t_vmax>
    {
        public void vmax_check()
        {
            vmax_check(n128);
            vmax_check(n256);
        }

        void vmax_check(N128 w)
        {
            vmax_check(w,z8);
            vmax_check(w,z8i);
            vmax_check(w,z16);
            vmax_check(w,z16i);
            vmax_check(w,z32);
            vmax_check(w,z32i);
            vmax_check(w,z64);
            vmax_check(w,z64i);
            vmax_check(w,z32f);
            vmax_check(w,z64f);
        }

        void vmax_check(N256 w)
        {
            vmax_check(w,z8);
            vmax_check(w,z8i);
            vmax_check(w,z16);
            vmax_check(w,z16i);
            vmax_check(w,z32);
            vmax_check(w,z32i);
            vmax_check(w,z64);
            vmax_check(w,z64i);
            vmax_check(w,z32f);
            vmax_check(w,z64f);
        }

        void vmax_check<T>(N128 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckBinaryOp(Calcs.vmax<T>(w), w, t);

        void vmax_check<T>(N256 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckBinaryOp(Calcs.vmax<T>(w), w, t);
    }
}