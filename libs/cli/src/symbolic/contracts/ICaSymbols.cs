//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using Microsoft.CodeAnalysis;

    public interface ICaSymbols<T> : IIndex<T>
        where T : ISymbol
    {
        CaSymbol<T> Symbol(uint index);
    }

    public interface ICaSymbols<H,T> : ICaSymbols<T>
        where T : ISymbol
        where H : new()
    {
        new CaSymbol<H,T> Symbol(uint index);

        CaSymbol<T> ICaSymbols<T>.Symbol(uint index)
            => Symbol(index);
    }
}