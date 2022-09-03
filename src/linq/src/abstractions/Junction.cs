//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    /// <summary>
    /// Represents a logical connective where each constituent is a member predicate
    /// </summary>
    public abstract class Junction : IJunction
    {
        protected Junction(IEnumerable<IPredicateApplication> Criteria, Junction Parent = null)
        {
            this.Criteria = Criteria.ToList();
            this.Parent = Parent;
            this.Children = new List<Junction>();
        }

        protected abstract ILogicalOperator Connective { get; }

        public List<IPredicateApplication> Criteria { get; }

        public Option<Junction> Parent { get; }

        public List<Junction> Children { get; }

        IReadOnlyList<IPredicateApplication> IJunction.Criteria
            => Criteria;

        public void Flatten()
        {
            if (Children.Count == 1 && Children[0].Connective == Connective)
            {
                var child = Children[0];
                Criteria.AddRange(child.Criteria);
                Children.Clear();
                Children.AddRange(child.Children);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Parent.Exists)
                sb.Append("(");
            try
            {
                for (int i = 0; i < Criteria.Count; i++)
                {
                    var p = Criteria[i];
                    if (i == 0)
                        sb.Append($"{p} {Connective.Symbol}");
                    else if (i != Criteria.Count - 1)
                        sb.Append($" {p} {Connective.Symbol}");
                    else
                        sb.Append($" {p}");
                }
                if (Children.Count != 0)
                {
                    foreach (var child in Children)
                    {
                        sb.Append(child.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                sb.Append(e.Message);
            }

            if (Parent.Exists)
                sb.Append(")");

            return sb.ToString();
        }
    }
}