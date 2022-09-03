//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Specifies that a ~ b iff b ~ a for every a,b:T
        /// </summary>
        /// <typeparam name="T">The element type</typeparam>
        public interface ISymmetric<T> : IBinaryRelation<T>
        {

        }
    }
}