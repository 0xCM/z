//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a logical disjunction; i.e., the or connective that evaluates to true if and only if one or more of it's operands are true
    /// </summary>
    public sealed class Disjunction : Junction
    {
        public Disjunction(Junction Parent = null)
            : base(new IPredicateApplication[] { }, Parent)
        { }

        public Disjunction(IEnumerable<IPredicateApplication> Predicates, Junction Parent = null)
            : base(Predicates, Parent)
        { }

        protected override ILogicalOperator Connective
            => StandardOperators.Or;
    }
}