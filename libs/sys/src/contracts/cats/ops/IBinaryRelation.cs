//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes a relation over a set
        /// </summary>
        /// <typeparam name="T">The element type</typeparam>
        public interface IBinaryRelation<T>
        {
            bool Related(T x, T y);
        }
    }
}