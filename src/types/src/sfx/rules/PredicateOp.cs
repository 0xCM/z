//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class PredicateOp : PredicateOp<object>
    {
        public new static PredicateOp Empty => default;

        public PredicateOp(string name)
            : base(name)
        {
        }
    }
}