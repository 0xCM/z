//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

/// <summary>
/// Base type for intrinsic tests
/// </summary>
/// <typeparam name="X">The concrete subtype</typeparam>
public abstract class t_inx<X> : UnitTest<X, CheckVectorsHost, ICheckVectors>
    where X : t_inx<X>
{
    protected t_inx()
    {
        CheckSVF =  new CheckSVF(Context);
    }

    protected readonly ICheckSVF CheckSVF;

    protected SVFChecks SVF {get; private set;}

    protected override void OnShellInjected(IWfRuntime wf)
    {
        SVF = SVFChecks.create(wf, Random);
    }

    protected void vbinop_bench<F,T>(W128 w, F f, T t = default, SystemCounter clock = default)
        where F : IBinaryOp128<T>
        where T : unmanaged
    {
        var last = gcpu.vzero<T>(w);
        var blocklen = Widths.div(w,t);
        var blockcount = RepCount/blocklen;
        var ops = 0;

        for(var cycle = 0; cycle<CycleCount; cycle++)
        {
            var lData = Random.SpanBlocks<T>(w,blockcount);
            var rData = Random.SpanBlocks<T>(w,blockcount);

            clock.Start();
            for(var block=0; block<blockcount; block++, ops++)
                last = f.Invoke(lData.LoadVector(block), rData.LoadVector(block));
            clock.Stop();
        }

        ReportBenchmark(f, ops, clock,w,t);
    }

    protected void vbinop_bench<F,T>(W256 w, F f, T t = default, SystemCounter clock = default)
        where F : IBinaryOp256<T>
        where T : unmanaged
    {
        var last = gcpu.vzero<T>(w);
        var blocklen = Widths.div(w,t);
        var blockcount = RepCount/blocklen;
        var ops = 0;

        for(var cycle = 0; cycle<CycleCount; cycle++)
        {
            var lData = Random.SpanBlocks<T>(w,blockcount);
            var rData = Random.SpanBlocks<T>(w,blockcount);

            clock.Start();
            for(var block=0; block<blockcount; block++, ops++)
                last = f.Invoke(lData.LoadVector(block), rData.LoadVector(block));
            clock.Stop();
        }

        ReportBenchmark(f, ops, clock,w,t);
    }

    protected void vshift_bench<F,T>(W128 w, F f, T t = default, SystemCounter clock = default)
        where F : IUnaryImm8Op128<T>
        where T : unmanaged
    {
        var last = gcpu.vzero(w,t);
        var blocklen = Widths.div(w,t);
        var blockcount = RepCount/blocklen;
        var bitlen = width<T>(w8);
        var ops = 0;

        for(var cycle = 0; cycle<CycleCount; cycle++)
        {
            var offset = Random.Next<byte>(2, (byte)(bitlen - 1));
            var data = Random.SpanBlocks<T>(w,blockcount);

            clock.Start();
            for(var block=0; block<blockcount; block++, ops++)
                last = f.Invoke(data.LoadVector(block),offset);
            clock.Stop();
        }

        ReportBenchmark(f, ops, clock,w,t);
    }

    protected void vshift_bench<F,T>(W256 w, F f, T t = default, SystemCounter clock = default)
        where F : IUnaryImm8Op256<T>
        where T : unmanaged
    {
        var last = gcpu.vzero(w,t);
        var blocklen = Widths.div(w,t);
        var blockcount = RepCount/blocklen;
        var bitlen = width<T>(w8);
        var ops = 0;

        for(var cycle = 0; cycle<CycleCount; cycle++)
        {
            var offset = Random.Next<byte>(2, (byte)(bitlen - 1));
            var data = Random.SpanBlocks<T>(w,blockcount);

            clock.Start();
            for(var block=0; block<blockcount; block++, ops++)
                last = f.Invoke(data.LoadVector(block),offset);
            clock.Stop();
        }

        ReportBenchmark(f, ops, clock,w,t);
    }
}
