//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;

    /// <summary>
    /// Represents the logical and operator
    /// </summary>
    public sealed class AndOperator : BinaryOperator<AndOperator>, ILogicalOperator
    {
        public AndOperator()
            : base("and", "&&")
        {

        }
    }
}