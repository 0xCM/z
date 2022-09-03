//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Specifies that a ~ a for every a:T
        /// </summary>
        /// <typeparam name="T">The element type</typeparam>
        public interface IReflexive<T> : IBinaryRelation<T>
        {

        }
    }
}