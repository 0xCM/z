//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISymbolDispenser : IAllocDispenser
    {
        LocatedSymbol Symbol(MemoryAddress location, string name);

        LocatedSymbol Symbol(SymAddress location, string name);
    }
}