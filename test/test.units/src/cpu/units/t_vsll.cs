//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    public class t_vsll : t_inx<t_vsll>
    {
        public void vsll_check()
        {
            vsll_check(w128);
            vsll_check(w256);
        }

        public void vsll_bench()
        {
            vsll_bench(w128);
            vsll_bench(w256);
        }

        void vsll_bench(W128 w)
        {
            vshift_bench(w,Calcs.vsll(w, z8), z8);
            vshift_bench(w,Calcs.vsll(w, z16), z16);
            vshift_bench(w,Calcs.vsll(w, z32), z32);
            vshift_bench(w,Calcs.vsll(w, z64), z64);
        }

        void vsll_bench(N256 w)
        {

            vshift_bench(w,Calcs.vsll(w, z8), z8);
            vshift_bench(w,Calcs.vsll(w, z16), z16);
            vshift_bench(w,Calcs.vsll(w, z32), z32);
            vshift_bench(w,Calcs.vsll(w, z64), z64);
        }

        void vsll_check(W128 w)
        {
            vsll_check(w, z8);
            vsll_check(w, z8i);
            vsll_check(w, z16);
            vsll_check(w, z16i);
            vsll_check(w, z32);
            vsll_check(w, z32i);
            vsll_check(w, z64);
            vsll_check(w, z64i);
        }

        void vsll_check(W256 w)
        {
            vsll_check(w, z8);
            vsll_check(w, z8i);
            vsll_check(w, z16);
            vsll_check(w, z16i);
            vsll_check(w, z32);
            vsll_check(w, z32i);
            vsll_check(w, z64);
            vsll_check(w, z64i);
        }

        void vsll_check<T>(W128 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckShiftOp(Calcs.vsll(w,t),w,t);

        void vsll_check<T>(W256 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckShiftOp(Calcs.vsll(w,t),w,t);
    }
}