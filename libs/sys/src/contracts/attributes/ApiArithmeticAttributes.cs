//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = ApiArithmeticClass;
    using A = OpKindAttribute;

    public sealed class AddAttribute : A { public AddAttribute() : base(K.Add) {} }

    public sealed class AddSAttribute : A { public AddSAttribute() : base(K.AddS) {} }

    public sealed class AddHAttribute : A { public AddHAttribute() : base(K.AddH) {} }

    public sealed class AddHSAttribute : A { public AddHSAttribute() : base(K.AddHS) {} }

    public sealed class SadAttribute : A { public SadAttribute() : base(K.Sad) {} }

    public sealed class SubAttribute : A { public SubAttribute() : base(K.Sub) {} }

    public sealed class SubHAttribute : A { public SubHAttribute() : base(K.SubH) {} }

    public sealed class SubHSAttribute : A { public SubHSAttribute() : base(K.SubHS) {} }

    public sealed class SubSAttribute : A { public SubSAttribute() : base(K.SubS) {} }

    public sealed class MulAttribute : A { public MulAttribute() : base(K.Mul) {} }

    public sealed class MulLoAttribute : A { public MulLoAttribute() : base(K.MulLo) {} }

    public sealed class MulHiAttribute : A { public MulHiAttribute() : base(K.MulHi) {} }

    public sealed class MulXAttribute : A { public MulXAttribute() : base(K.MulX) {} }

    public sealed class DivAttribute : A { public DivAttribute() : base(K.Div) {} }

    public sealed class ModAttribute : A { public ModAttribute() : base(K.Mod) {} }

    public sealed class ClampAttribute : A { public ClampAttribute() : base(K.Clamp) {} }

    public sealed class DistAttribute : A { public DistAttribute() : base(K.Dist) {} }

    public sealed class ClMulAttribute : A { public ClMulAttribute() : base(K.ClMul) {} }

    public sealed class DotAttribute : A { public DotAttribute() : base(K.Dot) {} }

    public sealed class IncAttribute : A { public IncAttribute() : base(K.Inc) {} }

    public sealed class DecAttribute : A { public DecAttribute() : base(K.Dec) {} }

    public sealed class NegateAttribute : A { public NegateAttribute() : base(K.Negate) {} }

    public sealed class AbsAttribute : A { public AbsAttribute() : base(K.Abs) {} }

    public sealed class SquareAttribute : A { public SquareAttribute() : base(K.Square) {} }

    public sealed class SqrtAttribute : A { public SqrtAttribute() : base(K.Sqrt) {} }

    public sealed class FmaAttribute : A { public FmaAttribute() : base(K.Fma) {} }

    public sealed class ModMulAttribute : A { public ModMulAttribute() : base(K.ModMul) {} }

    public sealed class DivModAttribute : A { public DivModAttribute() : base(K.DivMod) {} }

    public sealed class AvgzAttribute : A { public AvgzAttribute() : base(K.Avgz) {} }

    public sealed class AvgiAttribute : A { public AvgiAttribute() : base(K.Avgi) {} }

    public sealed class MaxAttribute : A { public MaxAttribute() : base(K.Max) {} }

    public sealed class MinAttribute : A { public MinAttribute() : base(K.Min) {} }

    public sealed class CeilAttribute : A { public CeilAttribute() : base(K.Ceil) {} }

    public sealed class FloorAttribute : A { public FloorAttribute() : base(K.Floor) {} }

    public sealed class RoundAttribute : A { public RoundAttribute() : base(K.Round) {} }

    public sealed class PowAttribute : A { public PowAttribute() : base(K.Pow) {} }

    public sealed class Log2Attribute : A { public Log2Attribute() : base(K.Log2) {} }

    public sealed class AddAssignAttribute : A { public AddAssignAttribute() : base(K.AddAssign) {} }

    public sealed class SubAssignAttribute : A { public SubAssignAttribute() : base(K.SubAssign) {} }

    public sealed class MulAssignAttribute : A { public MulAssignAttribute() : base(K.MulAssign) {} }

    public sealed class DivAssignAttribute : A { public DivAssignAttribute() : base(K.DivAssign) {} }
}