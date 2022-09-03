//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a logical conjunction; i.e., the and conective that evaluates to true if and only if all of its operands are true
    /// </summary>
    public sealed class Conjunction : Junction
    {
        public Conjunction(Junction parent = null)
            : base(new IPredicateApplication[] { }, parent)
        { }

        public Conjunction(IEnumerable<IPredicateApplication> predicates, Junction parent = null)
            : base(predicates, parent)
        { }

        protected override ILogicalOperator Connective
            => StandardOperators.And;
    }
}
