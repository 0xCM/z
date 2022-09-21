//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_vnegate : t_inx<t_vnegate>
    {
        public void vnegate_check()
        {
            vnegate_check(n128);
            vnegate_check(n256);
        }

        void vnegate_check(N128 w)
        {
            vnegate_check(w,z8);
            vnegate_check(w,z8i);
            vnegate_check(w,z16);
            vnegate_check(w,z16i);
            vnegate_check(w,z32);
            vnegate_check(w,z32i);
            vnegate_check(w,z64);
            vnegate_check(w,z64i);
            vnegate_check(w,z32f);
            vnegate_check(w,z64f);
        }

        void vnegate_check(N256 w)
        {
            vnegate_check(w,z8);
            vnegate_check(w,z8i);
            vnegate_check(w,z16);
            vnegate_check(w,z16i);
            vnegate_check(w,z32);
            vnegate_check(w,z32i);
            vnegate_check(w,z64);
            vnegate_check(w,z64i);
            vnegate_check(w,z32f);
            vnegate_check(w,z64f);
        }

        void vnegate_check<T>(N128 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckUnaryOp(Calcs.vnegate(w,t), w, t);

        void vnegate_check<T>(N256 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckUnaryOp(Calcs.vnegate(w,t), w, t);
   }
}