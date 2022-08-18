//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using A = OpKindAttribute;
    using K = ApiComparisonClass;

    public sealed class EqAttribute : A { public EqAttribute() : base(K.Eq) {} }

    public sealed class EqzAttribute : A { public EqzAttribute() : base(K.Eqz) {} }

    public sealed class NeqAttribute : A { public NeqAttribute() : base(K.Neq) {} }

    public sealed class LtAttribute : A { public LtAttribute() : base(K.Lt) {} }

    public sealed class LtzAttribute : A { public LtzAttribute() : base(K.Ltz) {} }

    public sealed class LtEqAttribute : A { public LtEqAttribute() : base(K.LtEq) {} }

    public sealed class GtAttribute : A { public GtAttribute() : base(K.Gt) {} }

    public sealed class GtzAttribute : A { public GtzAttribute() : base(K.Gtz) {} }

    public sealed class GtEqAttribute : A { public GtEqAttribute() : base(K.GtEq) {} }

    public sealed class DividesAttribute : A { public DividesAttribute() : base(K.Divides) {} }

    public sealed class BetweenAttribute : A { public BetweenAttribute() : base(K.Between) {} }

    public sealed class WithinAttribute : A { public WithinAttribute() : base(K.Within) {} }

    public sealed class NegativeAttribute : A { public NegativeAttribute() : base(K.Negative) {} }

    public sealed class PositiveAttribute : A { public PositiveAttribute () : base(K.Positive) {} }

    public sealed class NonzAttribute : A { public NonzAttribute () : base(K.Nonz) {} }

    public sealed class EqBAttribute : A { public EqBAttribute() : base(K.EqB) {} }

    public sealed class NeqBAttribute : A { public NeqBAttribute() : base(K.NeqB) {} }

    public sealed class LtBAttribute : A { public LtBAttribute() : base(K.LtB) {} }

    public sealed class LtEqBAttribute : A { public LtEqBAttribute() : base(K.LtEqB) {} }

    public sealed class GtBAttribute : A { public GtBAttribute() : base(K.GtB) {} }

    public sealed class GtEqBAttribute : A { public GtEqBAttribute() : base(K.GtEqB) {} }


}