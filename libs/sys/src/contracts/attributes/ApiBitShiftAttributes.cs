//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using A = OpKindAttribute;
    using K = BitShiftClass;

    public sealed class SllAttribute : A { public SllAttribute() : base(K.Sll) {} }

    public sealed class SllvAttribute : A { public SllvAttribute() : base(K.Sllv) {} }

    public sealed class SrlAttribute : A { public SrlAttribute() : base(K.Srl) {} }

    public sealed class SrlvAttribute : A { public SrlvAttribute() : base(K.Srlv) {} }

    public sealed class SalAttribute : A { public SalAttribute() : base(K.Sal) {} }

    public sealed class SraAttribute : A { public SraAttribute() : base(K.Sra) {} }

    public sealed class RotlAttribute : A { public RotlAttribute() : base(K.Rotl) {} }

    public sealed class RotlvAttribute : A { public RotlvAttribute() : base(K.Rotlv) {} }

    public sealed class RotrAttribute : A { public RotrAttribute() : base(K.Rotr) {} }

    public sealed class RotrvAttribute : A { public RotrvAttribute() : base(K.Rotrv) {} }

    public sealed class XorSlAttribute : A { public XorSlAttribute() : base(K.XorSl) {} }

    public sealed class XorSrAttribute : A { public XorSrAttribute() : base(K.XorSr) {} }

    public sealed class XorsAttribute : A { public XorsAttribute() : base(K.Xors) {} }

    public sealed class BsllAttribute : A { public BsllAttribute() : base(K.Bsll) {} }

    public sealed class BsrlAttribute : A { public BsrlAttribute() : base(K.Bsrl) {} }

    public sealed class RotlxAttribute : A { public RotlxAttribute() : base(K.Rotlx) {} }

    public sealed class RotrxAttribute : A { public RotrxAttribute() : base(K.Rotrx) {} }

    public sealed class SllxAttribute : A { public SllxAttribute() : base(K.Sllx) {} }

    public sealed class SrlxAttribute : A { public SrlxAttribute() : base(K.Srlx) {} }
}