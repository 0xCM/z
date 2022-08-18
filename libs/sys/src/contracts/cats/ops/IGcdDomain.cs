//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes a GCD domain
        /// </summary>
        /// <typeparam name="T">The individual type</typeparam>
        /// <remarks>See https://en.wikipedia.org/wiki/GCD_domain</remarks>
        public interface IGcdDomain<T> : IIntegralDomain<T>
            where T : unmanaged, IGcdDomain<T>
        {

        }
    }
}