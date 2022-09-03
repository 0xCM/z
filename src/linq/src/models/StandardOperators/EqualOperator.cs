//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents the equal operator
    /// </summary>
    public sealed class EqualOperator : ComparisonOperator<EqualOperator>
    {
        internal EqualOperator()
            : base("eq", "==")
        { }
    }

}