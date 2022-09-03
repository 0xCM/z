//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes a principal ideal domain
        /// </summary>
        /// <typeparam name="T">The individual type</typeparam>
        public interface IPrincipalIdealDomain<T> : IUniqueFactorDomain<T>
            where T : unmanaged, IPrincipalIdealDomain<T>
        {

        }
    }
}