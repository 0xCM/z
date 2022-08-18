//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IPowered<B,E>
        where B : IPowered<B,E>, new()
    {
        B Pow(E exp);
    }

    public interface INaturallyPowered<S> : IPowered<S,int>
        where S : INaturallyPowered<S>, new()
    {
    }
}