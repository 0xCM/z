//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using A = OpKindAttribute;
    using K = BitLogicClass;

    public sealed class AndAttribute : A { public AndAttribute() : base(K.And) {} }

    public sealed class CNonImplAttribute : A { public CNonImplAttribute() : base(K.CNonImpl) {} }

    public sealed class LProjectAttribute : A { public LProjectAttribute() : base(K.LProject) {} }

    public sealed class NonImplAttribute : A { public NonImplAttribute() : base(K.NonImpl) {} }

    public sealed class RProjectAttribute : A { public RProjectAttribute() : base(K.RProject) {} }

    public sealed class OrAttribute : A { public OrAttribute() : base(K.Or) {} }

    public sealed class XorAttribute : A { public XorAttribute() : base(K.Xor) {} }

    public sealed class NorAttribute : A { public NorAttribute() : base(K.Nor) {} }

    public sealed class XnorAttribute : A { public XnorAttribute() : base(K.Xnor) {} }

    public sealed class RNotAttribute : A { public RNotAttribute() : base(K.RNot) {} }

    public sealed class CImplAttribute : A { public CImplAttribute() : base(K.CImpl) {} }

    public sealed class NandAttribute : A { public NandAttribute() : base(K.Nand) {} }

    public sealed class TrueAttribute : A { public TrueAttribute() : base(K.True) {} }

    public sealed class ImplAttribute : A { public ImplAttribute() : base(K.Impl) {} }

    public sealed class LNotAttribute : A { public LNotAttribute() : base(K.LNot) {} }

    public sealed class FalseAttribute : A { public FalseAttribute() : base(K.False) {} }

    public sealed class SelectAttribute : A { public SelectAttribute() : base(K.Select) {} }

    public sealed class NotAttribute : A { public NotAttribute() : base(K.Not) {} }

    public sealed class XorNotAttribute : A { public XorNotAttribute() : base(K.XorNot) {} }
}