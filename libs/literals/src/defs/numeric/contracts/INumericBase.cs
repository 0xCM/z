//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface INumericBase
    {
        NumericBaseKind Kind {get;}

        NumericBaseIndicator Indicator {get;}
    }

    public interface INumericBase<F> : INumericBase
        where F : unmanaged, INumericBase<F>
    {

    }
}