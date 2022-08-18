//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    public class t_vblock_add : UnitTest<t_vblock_add>
    {
        static NatSeq<N1,N2,N3> L => default;

        public void vblock_add_123x8i()
            => vblock_add_check(L,z8i);

        public void vblock_add_123x8u()
            => vblock_add_check(L,z8);

        public void vblock_add_123x16i()
            => vblock_add_check(L,z16i);

        public void vblock_add_123x16u()
            => vblock_add_check(L,z16);

        public void vblock_add_123x32i()
            => vblock_add_check(L,z32i);

        public void vblock_add_123x32()
            => vblock_add_check(L,z32);

        public void vblock_add_123x64i()
            => vblock_add_check(L,z64i);

        public void vblock_add_123x64()
            => vblock_add_check(L,z64);

        public void vblock_add_123x32f()
            => vblock_add_check(L,z32f);

        public void vblock_add_123x64f()
            => vblock_add_check(L,z64f);

        public void vblock_add_123x8i_bench()
            => vblock_add_bench(L,z8i);

        public void vblock_add_123x16i_bench()
            => vblock_add_bench(L,z16i);

        public void vblock_add_123x16_bench()
            => vblock_add_bench(L,z16);

        public void vblock_add_123x8_bench()
            => vblock_add_bench(L,z8);

        public void vblock_add_123x32i_bench()
            => vblock_add_bench(L,z32i);

        public void vblock_add_123x32_bench()
            => vblock_add_bench(L,z32);

        public void vblock_add_123x64i_bench()
            => vblock_add_bench(L,z64i);

        public void vblock_add_123x64_bench()
            => vblock_add_bench(L,z64);

        public void vblock_add_123x32f_bench()
            => vblock_add_bench(L,z32f);

        public void vblock_add_123x64f_bench()
            => vblock_add_bench(L,z64f);

        public Span<T> add<T>(Span<T> lhs, ReadOnlySpan<T> rhs)
            where T : unmanaged
        {
            for(var i=0; i< Claim.length(lhs,rhs); i++)
                lhs[i] = gmath.add(lhs[i], rhs[i]);
            return lhs;
        }

        protected void vblock_add_check<N,T>(N n = default, T t = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var v4 = RowVectors.blockalloc<N,T>();
            for(var i=0; i< CycleCount; i++)
            {
                var v1 = Random.VectorBlock<N,T>();
                var v2 = Random.VectorBlock<N,T>();
                var v3 = RowVectors.blockload(add(v1.Unsized,v2.Unsized), n);
                Calcs.add(ref v1, v2);
                Claim.require(v3 == v1);
            }
        }

        void vblock_add_bench<N,T>(N n = default, T t = default)
            where T : unmanaged
            where N : unmanaged, ITypeNat
        {
            var opcount = CycleCount*RoundCount;
            var sw = stopwatch(false);
            var opname = $"vblock_add_{n}x{width<T>()}";
            var dst = RowVectors.blockalloc<N,T>();
            for(var i=0; i<opcount; i++)
            {
                var v1 = Random.VectorBlock<N,T>();
                var v2 = Random.VectorBlock<N,T>();
                sw.Start();
                Calcs.add(ref v1, v2);
                sw.Stop();
            }
            ReportBenchmark(opname, opcount, sw.Elapsed);
        }
    }
}