//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    public interface ICheckSpanBlocks : ICheckNumeric
    {
        /// <summary>
        /// Asserts content equality for two 128-bit blocks
        /// </summary>
        /// <param name="xb">The left span</param>
        /// <param name="yb">The right span</param>
        /// <param name="caller">The invoking function</param>
        /// <param name="file">The file in which the invoking function is defined </param>
        /// <param name="line">The file line number of invocation</param>
        /// <typeparam name="T">The element type</typeparam>
        void eq<T>(SpanBlock128<T> a, SpanBlock128<T> b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
        {
            for(var i = 0; i< a.CellCount; i++)
                if(!gmath.eq(a[i],b[i]))
                    throw AppErrors.ItemsNotEqual(i, a[i], b[i], caller, file, line);
        }

        /// <summary>
        /// Asserts content equality for two 256-bit blocks
        /// </summary>
        /// <param name="a">The left block</param>
        /// <param name="b">The right block</param>
        /// <param name="caller">The invoking function</param>
        /// <param name="file">The file in which the invoking function is defined </param>
        /// <param name="line">The file line number of invocation</param>
        /// <typeparam name="T">The element type</typeparam>
        void eq<T>(SpanBlock256<T> a, SpanBlock256<T> b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
        {
            for(var i = 0; i<length(a,b); i++)
                if(!gmath.eq(a[i],b[i]))
                    throw AppErrors.ItemsNotEqual(i, a[i], b[i], caller, file, line);
        }

        /// <summary>
        /// Asserts content equality for two 512-bit blocks
        /// </summary>
        /// <param name="a">The left block</param>
        /// <param name="b">The right block</param>
        /// <param name="caller">The invoking function</param>
        /// <param name="file">The file in which the invoking function is defined </param>
        /// <param name="line">The file line number of invocation</param>
        /// <typeparam name="T">The element type</typeparam>
        void eq<T>(SpanBlock512<T> a, SpanBlock512<T> b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
        {
            for(var i = 0; i<length(a,b); i++)
                if(!gmath.eq(a[i],b[i]))
                    throw AppErrors.ItemsNotEqual(i, a[i], b[i], caller, file, line);
        }

        /// <summary>
        /// Returns the length of equal-length blocks; otherwise raises an error
        /// </summary>
        /// <param name="lhs">The left span</param>
        /// <param name="rhs">The right span</param>
        private static int length<S,T>(in SpanBlock128<S> lhs, in SpanBlock128<T> rhs)
            where T : unmanaged
            where S : unmanaged
                => lhs.CellCount == rhs.CellCount ? lhs.CellCount : sys.@throw<int>(AppErrors.LengthMismatch(lhs.CellCount, rhs.CellCount));

        /// <summary>
        /// Returns the length of equal-length blocks; otherwise raises an error
        /// </summary>
        /// <param name="lhs">The left span</param>
        /// <param name="rhs">The right span</param>
        private static int length<S,T>(in SpanBlock256<S> lhs, in SpanBlock256<T> rhs)
            where T : unmanaged
            where S : unmanaged
                => lhs.CellCount == rhs.CellCount ? lhs.CellCount : sys.@throw<int>(AppErrors.LengthMismatch(lhs.CellCount, rhs.CellCount));

        /// <summary>
        /// Returns the length of equal-length blocks; otherwise raises an error
        /// </summary>
        /// <param name="lhs">The left span</param>
        /// <param name="rhs">The right span</param>
        private static int length<S,T>(in SpanBlock512<S> lhs, in SpanBlock512<T> rhs)
            where T : unmanaged
            where S : unmanaged
                => lhs.CellCount == rhs.CellCount ? lhs.CellCount : sys.@throw<int>(AppErrors.LengthMismatch(lhs.CellCount, rhs.CellCount));
    }
}