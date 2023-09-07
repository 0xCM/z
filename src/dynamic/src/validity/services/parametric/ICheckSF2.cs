//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static sys;

    public interface ICheckSF<T0,T1,R> : ICheckSF
        where T0 : unmanaged, IEquatable<T0>
        where T1 : unmanaged, IEquatable<T1>
        where R : unmanaged
    {
        void CheckMatch<F,G>(F f, G g)
            where F : IFunc<T0,T1,R>
            where G : IFunc<T0,T1,R>
        {
            var casename = SFxIdentity.name(Context.HostType, g);
            var succeeded = true;
            var clock = Time.counter(false);

            T0 next_x()
                => ExcludeZero ? Random.NonZ<T0>() : Random.Next<T0>();

            T1 next_y()
                => ExcludeZero ? Random.NonZ<T1>() : Random.Next<T1>();

            clock.Start();
            try
            {
                for(var i=0; i<RepCount; i++)
                {
                    var x = next_x();
                    var y = next_y();
                    eq(f.Invoke(x,y), g.Invoke(x,y));
                }
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

        void CheckSpanMatch<F,G>(F f, G g)
            where F : IFunc<T0,T1,R>
            where G : IFunc<T0,T1,R>
        {
            var casename = TestCaseIdentity.identify(Context.HostType, $"{g.Id}_span");
            var succeeded = true;
            var count = RepCount;
            var clock = Time.counter(false);

            var lhs = (ExcludeZero ? Random.NonZeroSpan<T0>(count) : Random.Span<T0>(count)).ReadOnly();
            ref readonly var leftIn = ref first(lhs);

            var rhs = (ExcludeZero ? Random.NonZeroSpan<T1>(count) : Random.Span<T1>(count)).ReadOnly();
            ref readonly var rightIn = ref first(rhs);

            var dst = span<R>(count);
            ref var target = ref first(dst);

            clock.Start();

            try
            {
                gcalc.apply(g, lhs, rhs, dst);
                for(var i=0u; i<count; i++)
                    eq(f.Invoke(skip(leftIn, i), skip(rightIn, i)), skip(target, i));
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