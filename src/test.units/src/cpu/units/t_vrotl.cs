//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    public class t_vrotl : t_inx<t_vrotl>
    {
        public void vrotl_check()
        {
            vrotl_check(w128);
            vrotl_check(w256);
        }

        public void vrotl_bench()
        {
            rotl_bench(w128);
            rotl_bench(w256);
        }

        void vrotl_check(N128 w)
        {
            vrotl_check(w, z8);
            vrotl_check(w, z16);
            vrotl_check(w, z32);
            vrotl_check(w, z64);
        }

        void vrotl_check(N256 w)
        {
            vrotl_check(w, z8);
            vrotl_check(w, z16);
            vrotl_check(w, z32);
            vrotl_check(w, z64);
        }

        void rotl_bench(W128 w)
        {
            vshift_bench(w, Calcs.vrotl(w, z8), z8);
            vshift_bench(w, Calcs.vrotl(w, z16),z16);
            vshift_bench(w, Calcs.vrotl(w, z32), z32);
            vshift_bench(w, Calcs.vrotl(w, z64), z64);
        }

        void rotl_bench(W256 w)
        {
            vshift_bench(w, Calcs.vrotl(w, z8), z8);
            vshift_bench(w, Calcs.vrotl(w, z16),z16);
            vshift_bench(w, Calcs.vrotl(w, z32), z32);
            vshift_bench(w, Calcs.vrotl(w, z64), z64);
        }

        void vrotl_check<T>(N128 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckShiftOp(Calcs.vrotl(w,t), w,t);

        void vrotl_check<T>(N256 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckShiftOp(Calcs.vrotl(w,t), w,t);
    }
}