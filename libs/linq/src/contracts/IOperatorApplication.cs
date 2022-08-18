//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System.Collections.Generic;

    /// <summary>
    /// Specifies the application of an n-ary operator to n operands
    /// </summary>
    public interface IOperatorApplication
    {
        /// <summary>
        /// The opererator to apply
        /// </summary>
        IOperator Operator { get; }

        /// <summary>
        /// The operands
        /// </summary>
        IReadOnlyList<object> Operands { get; }
    }
}