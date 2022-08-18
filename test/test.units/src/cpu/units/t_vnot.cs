//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_vnot : t_inx<t_vnot>
    {
        public void vnot_check()
        {
            vnot_check(n128);
            vnot_check(n256);
        }

        void vnot_check(N128 w)
        {
            vnot_check(w, z8);
            vnot_check(w, z8i);
            vnot_check(w, z16);
            vnot_check(w, z16i);
            vnot_check(w, z32);
            vnot_check(w, z32i);
            vnot_check(w, z64);
            vnot_check(w, z64i);
        }

        void vnot_check(N256 w)
        {
            vnot_check(w, z8);
            vnot_check(w, z8i);
            vnot_check(w, z16);
            vnot_check(w, z16i);
            vnot_check(w, z32);
            vnot_check(w, z32i);
            vnot_check(w, z64);
            vnot_check(w, z64i);
        }

        void vnot_check<T>(N128 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckUnaryOp(Calcs.vnot<T>(w),w,t);

        void vnot_check<T>(N256 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckUnaryOp(Calcs.vnot<T>(w),w,t);
  }
}