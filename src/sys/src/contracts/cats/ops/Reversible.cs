//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes operational reversiblity
        /// </summary>
        /// <typeparam name="T">The type for which a reverse operator is defined</typeparam>
        public interface IReversibleOps<T>
        {
            T Reverse(T src);
        }
    }
}