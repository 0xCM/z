//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes a set equipped with a partial order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <remarks>See https://en.wikipedia.org/wiki/Partially_ordered_set </remarks>
        public interface IPoset<T> : IPartialOrder<T>
            where T : unmanaged
        {
            /// <summary>
            /// Determines whether order may be adjudicated between two particluar elements
            /// </summary>
            /// <param name="x">The left element</param>
            /// <param name="y">The right element</param>
            /// <returns>Returns true if either a ~ b or b ~ a and false oterwise</returns>
            bool Comparable(T x, T y);
        }
    }
}