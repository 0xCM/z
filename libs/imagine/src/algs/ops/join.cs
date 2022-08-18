//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        /// <summary>
        /// All of your streams belong to us
        /// </summary>
        /// <param name="src">The source streams</param>
        /// <typeparam name="T">The streamed element type</typeparam>
        [Op, Closures(Closure)]
        public static Deferred<T> join<T>(params IEnumerable<T>[] src)
            => src.SelectMany(x => x);
    }
}