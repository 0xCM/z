//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace  Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes operational multiplication
        /// </summary>
        /// <typeparam name="T">The type subject to multiplication</typeparam>
        public interface IMultiplicative<T>
        {
            T Mul(T lhs, T rhs);
        }
    }
}