//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes a Euclidean domain
        /// </summary>
        /// <typeparam name="T">The individual type</typeparam>
        public interface IEuclideanDomain<T> : IPrincipalIdealDomain<T>
            where T : unmanaged, IEuclideanDomain<T>
        {

        }
    }
}