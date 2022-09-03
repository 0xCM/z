//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a multiplicative and unitial structure S such that
    /// s:S => s * recip(s) = 1
    /// </summary>
    /// <typeparam name="S"></typeparam>
    public interface IReciprocative<S> :  IUnital<S>, IMultiplicative<S>
        where S : IReciprocative<S>, new()
    {
        /// <summary>
        /// Calculates the structure's multiplicative inverse
        /// </summary>
        S Recip();
    }
}