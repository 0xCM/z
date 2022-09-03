//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static NumericClaims;

    public readonly struct Matches
    {
        /// <summary>
        /// Determines whether two unary structural functions agree over a sequence of points from a randomized domain
        /// </summary>
        /// <param name="context">The source context</param>
        /// <param name="f">The first function</param>
        /// <param name="g">The second function</param>
        /// <param name="nonz">Whether zero values should be excluded from the domain</param>
        /// <typeparam name="F">The first function type</typeparam>
        /// <typeparam name="G">The second function type</typeparam>
        /// <typeparam name="T">The domain type common to both functions</typeparam>
        /// <typeparam name="R">The range type common to both functions</typeparam>
        public static void points<F,G,T,R>(ITestContext context, F f, G g, bool nonz = false)
            where T : unmanaged
            where R : unmanaged
            where F : IFunc<T,R>
            where G : IFunc<T,R>
        {
            var casename = TestCaseIdentity.identify(context.HostType, $"{g.Id}_span");
            var succeeded = true;
            var clock = Time.counter(false);

            T next_x()
                => nonz ? context.Random.NonZ<T>() : context.Random.Next<T>();

            clock.Start();
            try
            {
                for(var i=0; i<context.RepCount; i++)
                {
                    var x = next_x();
                    eq(f.Invoke(x), g.Invoke(x));
                }
            }
            catch(Exception e)
            {
                 context.Error(e, casename);
                 succeeded = false;
            }
            finally
            {
                context.ReportCaseResult(casename,succeeded,clock);
            }
        }

        public static void spans<F,G,T,R>(ITestContext context,  F f, G g, bool nonz = false)
            where T : unmanaged, IEquatable<T>
            where R : unmanaged
            where F : IFunc<T,R>
            where G : IFunc<T,R>
        {
            var casename = SFxIdentity.name(context.HostType, g);
            var succeeded = true;
            var count = context.RepCount;
            var clock = Time.counter(false);
            var lhs = (nonz ? context.Random.NonZeroSpan<T>(count) : context.Random.Span<T>(count)).ReadOnly();
            ref readonly var leftIn = ref first(lhs);
            var dst = span<R>(count);
            ref var target = ref first(dst);

            clock.Start();
            try
            {
                gcalc.apply(g, lhs, dst);
                for(var i=0u; i<count; i++)
                    eq(f.Invoke(skip(leftIn, i)), skip(target, i));
            }
            catch(Exception e)
            {
                context.Error(e, casename);
                succeeded = false;
            }
            finally
            {
                context.ReportCaseResult(casename, succeeded, clock);
            }
        }
    }
}