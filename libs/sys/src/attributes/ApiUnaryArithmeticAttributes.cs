//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using A = OpKindAttribute;
    using K = ApiUnaryArithmeticClass;

    public sealed class EvenAttribute : A { public EvenAttribute() : base(K.Even) {} }

    public sealed class OddAttribute : A { public OddAttribute() : base(K.Odd) {} }
}