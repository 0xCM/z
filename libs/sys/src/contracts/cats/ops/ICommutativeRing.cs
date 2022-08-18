//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes a commutative, unital ring
        /// </summary>
        public interface ICommutativeRing<T> : IRing<T>
            where T : unmanaged
        {

        }
    }
}