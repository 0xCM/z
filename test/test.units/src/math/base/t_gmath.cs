//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class t_gmath<X> : UnitTest<X,NumericClaims,ICheckNumeric>
        where X : t_gmath<X>, new()
    {

    }
}