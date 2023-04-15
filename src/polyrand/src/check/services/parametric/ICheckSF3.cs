//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static sys;

    public interface ICheckSF<T0,T1,T2,R> : ICheckSF
        where T0 : unmanaged, IEquatable<T0>
        where T1 : unmanaged, IEquatable<T1>
        where T2 : unmanaged, IEquatable<T2>
        where R : unmanaged
    {
        void CheckMatch<F,G>(F f, G g)
            where F : IFunc<T0,T1,T2,R>
            where G : IFunc<T0,T1,T2,R>
        {
            var casename = SFxIdentity.name(Context.HostType, g);
            var succeeded = true;
            var clock = Time.counter(false);

            T0 next_x()
                => ExcludeZero ? Random.NonZ<T0>() : Random.Next<T0>();

            T1 next_y()
                => ExcludeZero ? Random.NonZ<T1>() : Random.Next<T1>();

            T2 next_z()
                => ExcludeZero ? Random.NonZ<T2>() : Random.Next<T2>();

            clock.Start();

            try
            {
                for(var i=0u; i<RepCount; i++)
                {
                    var x = next_x();
                    var y = next_y();
                    var z = next_z();
                    eq(f.Invoke(x,y,z), g.Invoke(x,y,z));
                }
            }
            catch(Exception e)
            {
                Error(e, casename);
                succeeded = false;
            }
            finally
            {
                Context.ReportCaseResult(casename,succeeded,clock);
            }
        }

        void CheckSpanMatch<F,G>(F f, G g)
            where F : IFunc<T0,T1,T2,R>
            where G : IFunc<T0,T1,T2,R>
        {
            var casename = TestCaseIdentity.identify(Context.HostType, $"{g.Id}_span");
            var succeeded = true;
            var count = RepCount;
            var clock = Time.counter(false);

            var inA = (ExcludeZero ? Random.NonZeroSpan<T0>(count) : Random.Span<T0>(count)).ReadOnly();
            ref readonly var inATarget = ref first(inA);

            var inB = (ExcludeZero ? Random.NonZeroSpan<T1>(count) : Random.Span<T1>(count)).ReadOnly();
            ref readonly var inBTarget = ref first(inB);

            var inC = (ExcludeZero ? Random.NonZeroSpan<T2>(count) : Random.Span<T2>(count)).ReadOnly();
            ref readonly var inCTarget = ref first(inC);

            var dst = span<R>(count);
            ref var target = ref first(dst);

            clock.Start();

            try
            {
                gcalc.apply(g, inA, inB, inC, dst);
                for(var i=0u; i<count; i++)
                    eq(f.Invoke(skip(inATarget, i), skip(inBTarget, i), skip(inCTarget, i)), skip(target, i));
            }
            catch(Exception e)
            {
                Error(e, casename);
                succeeded = false;
            }
            finally
            {
                Context.ReportCaseResult(casename, succeeded, clock);
            }
        }
    }
}