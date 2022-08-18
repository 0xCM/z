//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILogarithmic<S>
        where S : ILogarithmic<S>, new()
    {
        /// <summary>
        /// Computes the natural logarithm
        /// </summary>
        /// <param name="x">The input value</param>
        S Ln();

        /// <summary>
        /// Computes the base-10 logarithm
        /// </summary>
        /// <param name="x">The input value</param>
        S Log();

        /// <summary>
        /// Computes a logarithm at a specified base
        /// </summary>
        /// <param name="x">The input value</param>
        /// <param name="@base">The logarithm base</param>
        S LogB(S @base);
    }
}