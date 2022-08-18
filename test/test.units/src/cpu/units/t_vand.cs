//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;
    using static cpu;

    public class t_vand : t_inx<t_vand>
    {
        public void vand_check()
        {
            vand_check(n128);
            vand_check(n256);

            for(var i=0; i<RepCount; i++)
            {
                var x = Random.CpuVector(n128,z32);
                var y = Random.CpuVector(n128,z32);
                Claim.require(vand(x,y));
            }
        }

        public void vand_bench()
        {
            vand_bench(w128);
            vand_bench(w256);
        }

        void vand_check(N128 w)
        {
            vand_check(w, z8);
            vand_check(w, z8i);
            vand_check(w, z16);
            vand_check(w, z16i);
            vand_check(w, z32);
            vand_check(w, z32i);
            vand_check(w, z64);
            vand_check(w, z64i);
        }

        void vand_check(N256 w)
        {
            vand_check(w, z8);
            vand_check(w, z8i);
            vand_check(w, z16);
            vand_check(w, z16i);
            vand_check(w, z32);
            vand_check(w, z32i);
            vand_check(w, z64);
            vand_check(w, z64i);
        }

        void vand_bench(W128 w)
        {
            vand_bench(w, z8);
            vand_bench(w, z16);
            vand_bench(w, z32);
            vand_bench(w, z64);
        }

        void vand_bench<T>(W128 w, T t)
            where T : unmanaged
                => vbinop_bench(w, Calcs.vand<T>(w),t);

        void vand_bench(W256 w)
        {
            vand_bench(w, z8);
            vand_bench(w, z16);
            vand_bench(w, z32);
            vand_bench(w, z64);
        }

        void vand_bench<T>(W256 w, T t)
            where T : unmanaged
                => vbinop_bench(w, Calcs.vand<T>(w),t);

        static bit vand<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            var w = w128;
            var svc = Calcs.bitlogic<T>();
            var v1 = Calcs.vbitlogic<T>(w).and(x,y);
            var storage = Cells.alloc(w128);

            ref var dst = ref first<T>(storage.Bytes);
            var count = cpu.vcount<T>(w);

            for(byte i=0; i< count; i++)
                seek(dst, i) = svc.and(vcell(x,i), vcell(y,i));
            var v2 = gcpu.vload(w, dst);
            return gcpu.vsame(v1, v2);
        }

        void vand_check<T>(N128 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckBinaryOp(Calcs.vand<T>(w), w, t);

        void vand_check<T>(N256 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckBinaryOp(Calcs.vand<T>(w), w, t);
     }
}
