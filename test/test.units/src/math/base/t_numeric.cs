//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class t_numeric<X> : UnitTest<X,CheckVectorsHost, ICheckVectors>
        where X : t_numeric<X>, new()
    {
        protected new ICheckNumeric Claim => NumericClaims.Checker;
    }
}