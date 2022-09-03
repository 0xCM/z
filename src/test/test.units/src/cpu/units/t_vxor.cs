//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    public class t_vxor : t_inx<t_vxor>
    {
        public void vxor_check()
        {
            vxor_check(n128);
            vxor_check(n256);
        }

        public void vxor_bench()
        {
            vxor_bench(w128);
            vxor_bench(w256);
        }

        void vxor_bench(W128 w)
        {
            vxor_bench(w, z8);
            vxor_bench(w, z16);
            vxor_bench(w, z32);
            vxor_bench(w, z64);
        }

        void vxor_bench(W256 w)
        {
            vxor_bench(w, z8);
            vxor_bench(w, z16);
            vxor_bench(w, z32);
            vxor_bench(w, z64);
        }

        void vxor_bench<T>(W128 w, T t)
            where T : unmanaged
                => vbinop_bench(w, Calcs.vxor(w,t),t);

        void vxor_bench<T>(W256 w, T t)
            where T : unmanaged
                => vbinop_bench(w, Calcs.vxor(w,t),t);

        void vxor_check(N128 w)
        {
            vxor_check(w, z8);
            vxor_check(w, z8i);
            vxor_check(w, z16);
            vxor_check(w, z16i);
            vxor_check(w, z32);
            vxor_check(w, z32i);
            vxor_check(w, z64);
            vxor_check(w, z64i);
        }

        void vxor_check(N256 w)
        {
            vxor_check(w, z8);
            vxor_check(w, z8i);
            vxor_check(w, z16);
            vxor_check(w, z16i);
            vxor_check(w, z32);
            vxor_check(w, z32i);
            vxor_check(w, z64);
            vxor_check(w, z64i);
        }

        void vxor_check<T>(N128 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckBinaryOp(Calcs.vxor(w,t),w,t);

        void vxor_check<T>(N256 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckBinaryOp(Calcs.vxor(w,t),w,t);
     }
}
