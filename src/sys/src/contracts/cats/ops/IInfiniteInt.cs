//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes operations over unbound integers
        /// </summary>
        public interface IInfiniteInt<T> : IInteger<T>, IInfiniteOps<T>
            where T : unmanaged
        {

        }
    }
}