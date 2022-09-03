//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes a **unique** factorization domain
        /// </summary>
        /// <typeparam name="T">The individual type</typeparam>
        public interface IUniqueFactorDomain<T> : IGcdDomain<T>
            where T : unmanaged, IUniqueFactorDomain<T>
        {

        }
    }
}