//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IBitPredicate<T> : IFunc<T,bit>, IExprDeprecated
    {


    }

    [Free]
    public interface IBitPredicate : IFunc<object,bit>, IExprDeprecated
    {

    }
}