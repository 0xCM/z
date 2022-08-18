//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Specifies a ~ b & b ~ c => a ~ c for every a,b,c:T
        /// </summary>
        /// <typeparam name="T">The element type</typeparam>
        public interface ITransitive<T> : IBinaryRelation<T>
        {

        }
    }
}