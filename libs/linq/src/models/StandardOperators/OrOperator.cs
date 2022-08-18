//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Linq;

    public sealed class OrOperator : BinaryOperator<OrOperator>, ILogicalOperator<OrOperator>
    {
        public OrOperator()
            : base("or", "||")
        {

        }
    }
}