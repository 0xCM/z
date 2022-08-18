//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using A = OpKindAttribute;
    using K = ApiAggregateClass;

    public sealed class SumAttribute : A { public SumAttribute() : base(K.Sum) {} }

    public sealed class AvgAttribute : A { public AvgAttribute() : base(K.Avg) {} }

    public sealed class AggMaxAttribute : A { public AggMaxAttribute() : base(K.AggMax) {} }

    public sealed class AggMinAttribute : A { public AggMinAttribute() : base(K.AggMin) {} }
}