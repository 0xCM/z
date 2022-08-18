//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes a type that defines both left and right distribution
        /// over addition
        /// </summary>
        public interface IDistributive<T> : ILeftDistributive<T>, IRightDistributive<T>
            where T : unmanaged
        {

        }
    }
}