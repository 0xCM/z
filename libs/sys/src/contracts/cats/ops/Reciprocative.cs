//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        public interface IReciprocative<T> : IUnital<T>, IMultiplicative<T>
        {
            /// <summary>
            /// Calculates the multiplicative inverse of a given element
            /// </summary>
            /// <param name="x">The individual for which an inverse will be calculated</param>
            T Recip(T x);
        }
    }
}