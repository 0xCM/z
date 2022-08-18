//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        public interface INegatable<T>
        {
            /// <summary>
            /// Unary negation of input
            /// </summary>
            /// <param name="x">The input value</param>
            T Negate(T x);
        }
    }
}