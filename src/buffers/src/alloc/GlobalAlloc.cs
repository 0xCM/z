//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static NativeSigs;

public sealed class GlobalAlloc : Alloc
{
    public static Label label(ReadOnlySpan<char> src)
        => Alloc.Labels().Label(src);

    public static StringRef @string(ReadOnlySpan<char> src)
        => Alloc.Strings().String(src);

    public static LocatedSymbol symbol(MemoryAddress location, ReadOnlySpan<char> name)
        => Alloc.Symbols().Symbol(location,name);

    public static NativeSigRef sig(NativeSig sig)
        => Alloc.Sig(sig);

    public static NativeSigRef sig(ReadOnlySpan<char> scope, ReadOnlySpan<char> name, NativeType ret, params Operand[] ops)
        => Alloc.Sig(scope,name,ret,ops);

    public static MemorySegment memory(ByteSize size)
        => Alloc.Memory().Memory(size);

    public static MemorySegment page()
        => Alloc.Pages().Page();

    public static SourceText source(ReadOnlySpan<char> src)
        => Alloc.Source().SourceText(src);
        
    static ref readonly GlobalAlloc Alloc => ref Instance;

    GlobalAlloc()
    {

    }

    static GlobalAlloc Instance = new();
}
