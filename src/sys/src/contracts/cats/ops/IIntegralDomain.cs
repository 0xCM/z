//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes an integral domain, which is a nonzero commutative ring
        /// such that for every pair of nonzero elements a and b, the product
        /// ab is nonzero, i.e., ab = 0 iff a = 0 or b = 0
        /// </summary>
        /// <typeparam name="T">The individual type</typeparam>
        /// <remarks>See https://en.wikipedia.org/wiki/Integral_domain</remarks>
        public interface IIntegralDomain<T> : ICommutativeRing<T>
            where T : unmanaged
        {

        }
    }
}