//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_vadd : t_inx<t_vadd>
    {
        public void vadd_check()
        {
            vadd_check(n128);
            vadd_check(n256);
        }

        void vadd_check(N128 w)
        {
            vadd_check(w, z8);
            vadd_check(w, z8i);
            vadd_check(w, z16);
            vadd_check(w, z16i);
            vadd_check(w, z32);
            vadd_check(w, z32i);
            vadd_check(w, z64);
            vadd_check(w, z64i);
        }

        void vadd_check(N256 w)
        {
            vadd_check(w, z8);
            vadd_check(w, z8i);
            vadd_check(w, z16);
            vadd_check(w, z16i);
            vadd_check(w, z32);
            vadd_check(w, z32i);
            vadd_check(w, z64);
            vadd_check(w, z64i);
        }

        void vadd_check<T>(N128 w, T t = default)
            where T : unmanaged
        {
            SVF.Checker<T>().CheckBinaryOp(w, Calcs.vadd<T>(w));
        }

        void vadd_check<T>(N256 w, T t = default)
            where T : unmanaged
        {
            //var svc = Calcs.vadd<T>(w);
            SVF.Checker<T>().CheckBinaryOp(w, Calcs.vadd<T>(w));
            //CheckSVF.CheckBinaryOp(svc,w,t);
        }
    }
}