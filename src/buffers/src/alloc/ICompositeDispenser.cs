//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICompositeDispenser :
        ISigDispenser,
        IMemoryDispenser,
        ILabelDispenser,
        ISourceDispenser,
        IStringDispenser,
        ISymbolDispenser
    {

    }
}