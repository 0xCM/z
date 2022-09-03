//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    public class t_vrotr : t_inx<t_vrotr>
    {
        public void vrotr_check()
        {
            vrotr_check(n128);
            vrotr_check(n256);
        }

        public void vrotr_bench()
        {
            vrotr_bench(w128);
            vrotr_bench(w256);
        }

        void vrotr_bench(W128 w)
        {
            vshift_bench(w, Calcs.vrotr(w, z8), z8);
            vshift_bench(w, Calcs.vrotr(w, z16),z16);
            vshift_bench(w, Calcs.vrotr(w, z32), z32);
            vshift_bench(w, Calcs.vrotr(w, z64), z64);
        }

        void vrotr_bench(W256 w)
        {
            vshift_bench(w, Calcs.vrotr(w, z8), z8);
            vshift_bench(w, Calcs.vrotr(w, z16),z16);
            vshift_bench(w, Calcs.vrotr(w, z32), z32);
            vshift_bench(w, Calcs.vrotr(w, z64), z64);
        }


        void vrotr_check(N128 w)
        {
            vrotr_check(w, z8);
            vrotr_check(w, z16);
            vrotr_check(w, z32);
            vrotr_check(w, z64);
        }

        void vrotr_check(N256 w)
        {
            vrotr_check(w, z8);
            vrotr_check(w, z16);
            vrotr_check(w, z32);
            vrotr_check(w, z64);
        }

        void vrotr_check<T>(N128 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckShiftOp(Calcs.vrotr(w,t), w,t);

        void vrotr_check<T>(N256 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckShiftOp(Calcs.vrotr(w,t), w,t);

    }
}