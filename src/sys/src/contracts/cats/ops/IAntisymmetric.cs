//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Specifies if a,b:T & a!=b then a ~ b & b ~ a => a = b
        /// </summary>
        /// <typeparam name="T">The element type</typeparam>
        public interface IAntisymmetric<T> : IBinaryRelation<T>
        {

        }
    }
}