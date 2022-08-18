//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_vinc : t_inx<t_vinc>
    {
        public void vinc_check()
        {
            vinc_check(n128);
            vinc_check(n256);
        }

        void vinc_check(N128 w)
        {
            vinc_check(w, z8);
            vinc_check(w, z8i);
            vinc_check(w, z16);
            vinc_check(w, z16i);
            vinc_check(w, z32);
            vinc_check(w, z32i);
            vinc_check(w, z64);
            vinc_check(w, z64i);
        }

        void vinc_check(N256 w)
        {
            vinc_check(w, z8);
            vinc_check(w, z8i);
            vinc_check(w, z16);
            vinc_check(w, z16i);
            vinc_check(w, z32);
            vinc_check(w, z32i);
            vinc_check(w, z64);
            vinc_check(w, z64i);
        }

        void vinc_check<T>(N128 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckUnaryOp(Calcs.vinc<T>(w),w,t);

        void vinc_check<T>(N256 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckUnaryOp(Calcs.vinc<T>(w),w,t);
    }
}