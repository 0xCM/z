//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public static class PolySeq
    {
        const NumericKind Closure = AllNumeric;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T next<T>(ISource src)
            where T : struct
                => src.Next<T>();

        /// <summary>
        /// Produces the next value from a specified <see cref='IBoundSource'/> source subject to specified domain constraints
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="max">The maximum value to produce</param>
        /// <typeparam name="T">The value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T next<T>(IBoundSource src, T max)
            where T : unmanaged
                => src.Next<T>(max);

        /// <summary>
        /// Produces the next value from a specified <see cref='IBoundSource'/> source subject to specified domain constraints
        /// </summary>
        /// <param name="src">The value source</param>
        /// <param name="min">The minimum value to produce</param>
        /// <param name="max">The maximum value to produce</param>
        /// <typeparam name="T">The value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T next<T>(IBoundSource src, T min, T max)
            where T : unmanaged
                => src.Next<T>(min, max);
    }
}