
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISymbolHash : IAllocation<HashedSymbol>
    {
        bool HashSymbol(string src);
    }
}