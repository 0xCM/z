//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static ErrorMsg;

    using api = ClaimValidator;
    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    [ApiHost(ApiNames.CheckClose)]
    public readonly struct CheckClose : ICheckClose
    {
        internal const double Tolerance = .1;

        internal const float Res32 = .0000001f;

        internal const double Res64 = .0000001;

        [Op]
        public static bool almost(float lhs, float rhs)
        {
            var dist = fmath.dist(lhs,rhs);
            if(dist.IsNaN() || dist.Infinite() || dist < Res32)
                return true;

            var err = fmath.relerr(lhs,rhs);
            var tolerance = .1f;
            return err < tolerance ? true : throw api.failed(ClaimKind.Close, NotClose(lhs, rhs, err, tolerance));
        }

        [Op]
        public static bool almost(double lhs, double rhs)
        {
            var dist = fmath.dist(lhs,rhs);
            if(dist.IsNaN() || dist.Infinite() || dist<Res64)
                return true;

            var err = fmath.relerr(lhs,rhs);
            var tolerance = .1f;
            return err < tolerance ? true : throw api.failed(ClaimKind.Close, NotClose(lhs, rhs, err, tolerance));
        }

        [Op, Closures(Floats)]
        public static void close<T>(T lhs, T rhs)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                almost(float32(lhs), float32(rhs));
            else if(typeof(T) == typeof(double))
                almost(float64(lhs), float64(rhs));
            else
                throw no<T>();
        }

        /// <summary>
        /// Asserts that corresponding elements of two source spans of the same length are "close" as determined by a specified tolerance
        /// </summary>
        /// <param name="lhs">The left span</param>
        /// <param name="rhs">The right span</param>
        /// <param name="tolerance">The acceptable difference between corresponding left/right elements</param>
        /// <param name="caller">The invoking function</param>
        /// <param name="file">The file in which the invoking function is defined </param>
        /// <param name="line">The file line number of invocation</param>
        /// <typeparam name="T">The element type</typeparam>
        [Op, Closures(AllNumeric)]
        public static void close<T>(Span<T> lhs, Span<T> rhs, T tolerance, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
        {
            var count = CheckLengths.length(lhs,rhs);
            for(var i=0; i<count; i++)
                if(!gmath.within(skip(lhs,i), skip(rhs,i),tolerance))
                    throw AppErrors.ItemsNotEqual(i, lhs[i], rhs[i], caller, file, line);
        }
    }
}