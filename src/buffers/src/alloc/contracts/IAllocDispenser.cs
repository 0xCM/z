//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static NativeSigs;

[Free]
public interface IAllocDispenser : IDisposable
{

}

[Free]
public interface ILabelDispenser : IAllocDispenser
{
    Label Label(ReadOnlySpan<char> content);
}

[Free]
public interface ISourceDispenser : IAllocDispenser
{
    SourceText SourceText(ReadOnlySpan<char> src);

    SourceText SourceText(ReadOnlySpan<string> src);
}


[Free]
public interface ISymbolDispenser : IAllocDispenser
{
    LocatedSymbol Symbol(MemoryAddress location, ReadOnlySpan<char> name);

    LocatedSymbol Symbol(SymAddress location, ReadOnlySpan<char> name);
}

[Free]
public interface ISigDispenser : IAllocDispenser
{
    NativeSigRef Sig(ReadOnlySpan<char> scope, ReadOnlySpan<char> name, NativeType ret, params Operand[] ops);

    NativeSigRef Sig(NativeSig spec);
}    

[Free]
public interface IMemoryDispenser : IAllocDispenser
{
    MemorySegment Memory(ByteSize size);
}

[Free]
public interface IPageDispenser : IAllocDispenser
{
    MemorySegment Page();
}

[Free]
public interface IStringDispenser : IAllocDispenser
{
    StringRef String(ReadOnlySpan<char> content);
}

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
