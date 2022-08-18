//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct SFx
    {
        /// <summary>
        /// Returns true if all source blocks satisfy a specified unary predicate
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="f">The reified predicate</param>
        /// <typeparam name="F">The predicate reification type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static bit all<F,T>(in SpanBlock128<T> src, F f)
            where T : unmanaged
            where F : IUnaryPred128<T>
        {
            var blocks = src.BlockCount;
            var result = bit.On;
            for(var block = 0; block<blocks; block++)
                result &= f.Invoke(src.LoadVector(block));
            return result;
        }

        /// <summary>
        /// Returns true if all source blocks satisfy a specified unary predicate
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="f">The reified predicate</param>
        /// <typeparam name="F">The predicate reification type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static bit all<F,T>(in SpanBlock256<T> src, F f)
            where T : unmanaged
            where F : IUnaryPred256<T>
        {
            var blocks = src.BlockCount;
            var result = bit.On;
            for(var block=0; block<blocks; block++)
                result &= f.Invoke(src.LoadVector(block));
            return result;
        }

        [MethodImpl(Inline)]
        public static bit all<F,T>(in SpanBlock128<T> a, in SpanBlock128<T> b, F f)
            where T : unmanaged
            where F : IBinaryPred128<T>
        {
            var blocks = a.BlockCount;
            var result = bit.On;
            for(var block = 0; block<blocks; block++)
                result &= f.Invoke(a.LoadVector(block), b.LoadVector(block));
            return result;
        }

        [MethodImpl(Inline)]
        public static bit all<F,T>(in SpanBlock256<T> a, in SpanBlock256<T> b, F f)
            where T : unmanaged
            where F : IBinaryPred256<T>
        {
            var blocks = a.BlockCount;
            var result = bit.On;
            for(var block = 0; block<blocks; block++)
                result &= f.Invoke(a.LoadVector(block), b.LoadVector(block));
            return result;
        }
    }
}