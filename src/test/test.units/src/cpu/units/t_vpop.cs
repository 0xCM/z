//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;
    using static Intervals;

    public class t_vpop : t_inx<t_vpop>
    {
        public void vpop_check()
        {
            vpop_check(n128);
            vpop_check(n256);
        }

        public void vpop_bench()
        {
            vpop_bench_ref();
            vpop_bench(w128);
            vpop_bench(w256);
        }

        void vpop_bench(N256 n, SystemCounter counter = default)
        {
            var total = 0ul;
            var opcount = 0;
            for(var cycle = 0; cycle < CycleCount; cycle++)
            {
                var x = Random.CpuVector<ulong>(n);
                var y = Random.CpuVector<ulong>(n);
                var z = Random.CpuVector<ulong>(n);
                counter.Start();
                for(var i=0; i<RepCount; i++)
                    total += cpu.vpop(x,y,z);
                counter.Stop();
                opcount += (4 * 3 * RepCount);
            }
            ReportBenchmark($"vpop_3x256", opcount,counter);
        }

        void vpop_bench(W128 n, SystemCounter counter = default)
        {
            var total = 0ul;
            var opcount = 0;
            for(var cycle = 0; cycle < CycleCount; cycle++)
            {
                var x = Random.CpuVector<ulong>(n);
                var y = Random.CpuVector<ulong>(n);
                var z = Random.CpuVector<ulong>(n);
                counter.Start();
                for(var i=0; i<RepCount; i++)
                    total += cpu.vpop(x,y,z);
                counter.Stop();
                opcount += (2 * 3 * RepCount);
            }
            ReportBenchmark($"vpop_3x128", opcount,counter);
        }

        void vpop_bench_ref(SystemCounter counter = default)
        {
            var total = 0u;
            var opcount = 0;
            Span<ulong> samples = stackalloc ulong[RepCount];
            ref readonly var src = ref first(samples);
            for(var cycle = 0; cycle < CycleCount; cycle++)
            {
                Random.Fill(RepCount, ref first(samples));
                counter.Start();
                for(var i=0; i<RepCount; i++)
                    total += bits.pop(skip(first(samples), i));
                counter.Stop();
                opcount += RepCount;
            }
            ReportBenchmark($"vpop_1x64_ref", opcount, counter);
        }
        void vpop_check(N128 w)
        {
            vpop_check(w,z8);
            vpop_check(w,z16);
            vpop_check(w,z32);
            vpop_check(w,z64);
        }

        void vpop_check(N256 w)
        {
            vpop_check(w,z8);
            vpop_check(w,z16);
            vpop_check(w,z32);
            vpop_check(w,z64);
        }

        void vpop_check<T>(N128 w, T t = default)
            where T : unmanaged
        {
            var f = Calcs.vpop(w,t);

            void check()
            {
                var zed = zero<T>();
                var src = Random.SpanBlocks<T>(w, closed(zed, Limits.maxval<T>()),3);

                (var x0, var x1, var x2) = src.LoadVectors(0,1,2);

                var vlen = cpu.vcount(w,t);
                var expect = 0u;

                for(byte i=0; i<vlen; i++)
                    expect += f.Invoke(cpu.vcell(x0,i), cpu.vcell(x1,i), cpu.vcell(x2,i));

                var result = f.Invoke(x0,x1,x2);
                Claim.eq(expect,result);
            }

            CheckAction(check, CaseName(f));
        }

        void vpop_check<T>(N256 w, T t = default)
            where T : unmanaged
        {
            var f = Calcs.vpop(w,t);

            void check()
            {
                var zed = default(T);
                var src = Random.SpanBlocks<T>(w, closed(zed, Limits.maxval(t)),3);

                (var x0, var x1, var x2) = src.LoadVectors(0,1,2);

                var vlen = cpu.vcount(w,t);
                var expect = 0u;

                for(byte i=0; i<vlen; i++)
                    expect += f.Invoke(cpu.vcell(x0,i), cpu.vcell(x1,i), cpu.vcell(x2,i));

                var result = f.Invoke(x0,x1,x2);
                Claim.eq(expect,result);
            }

            CheckAction(check, CaseName(f));
        }
    }
}