//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISubtractive<S>
        where S : ISubtractive<S>, new()
    {
        /// <summary>
        /// Structural subtraction
        /// </summary>
        /// <param name="rhs">The right operand</param>
        S Sub(S rhs);
    }
}