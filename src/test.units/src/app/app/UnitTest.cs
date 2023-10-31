//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class UnitTest<U> : TestContext<U>, IUnitTest
        where U : UnitTest<U>
    {

        public static N1024 n1024 => default;

    }

    public abstract class UnitTest<U,V> : UnitTest<U>
        where U : UnitTest<U>
        where V : IClaimValidator
    {
        protected new abstract V Claim {get;}
    }

    public abstract class UnitTest<U,V,I> : UnitTest<U,I>
        where U : UnitTest<U>
        where V : struct, I
        where I : IClaimValidator
    {
        protected override I Claim => default(V);
    }
}