//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static NativeSigs;

public class CompositeDispenser : Dispenser<CompositeDispenser>, ICompositeDispenser
{
    readonly SymbolDispenser Symbols;

    readonly MemoryDispenser Memories;

    readonly LabelDispenser Labels;

    readonly SigDispenser Sigs;

    readonly StringDispenser Strings;

    internal CompositeDispenser(MemoryDispenser memory, StringDispenser strings, LabelDispenser labels, SymbolDispenser symbols)
        : base(false)
    {
        Symbols = symbols;
        Memories = memory;
        Labels = labels;
        Strings = strings;
        Sigs = Dispense.sigs(memory, strings, labels);
    }

    internal CompositeDispenser()
        : base(true)
    {
        Symbols = Dispense.symbols();
        Memories = Dispense.memory();
        Labels = Dispense.labels();
        Strings = Dispense.strings();
        Sigs = Dispense.sigs(Memories, Strings, Labels);
    }

    protected override void Dispose()
    {
        (Symbols as IDisposable).Dispose();
        (Memories  as IDisposable).Dispose();
        (Labels as IDisposable).Dispose();
        (Strings as IDisposable).Dispose();
        (Sigs as IDisposable).Dispose();
    }

    [MethodImpl(Inline)]
    public NativeSigRef Sig(ReadOnlySpan<char> scope, ReadOnlySpan<char> name, NativeType ret, params Operand[] ops)
        => Sigs.Sig(scope, name, ret, ops);

    [MethodImpl(Inline)]
    public NativeSigRef Sig(NativeSig spec)
        => Sigs.Sig(spec);

    [MethodImpl(Inline)]
    public LocatedSymbol Symbol(MemoryAddress location, ReadOnlySpan<char> name)
        => Symbols.Symbol(location, name);

    [MethodImpl(Inline)]
    public LocatedSymbol Symbol(SymAddress location, ReadOnlySpan<char> name)
        => Symbols.Symbol(location,name);

    [MethodImpl(Inline)]
    public MemorySegment Memory(ByteSize size)
        => Memories.Memory(size);

    [MethodImpl(Inline)]
    public Label Label(ReadOnlySpan<char> src)
        => Labels.Label(src);

    [MethodImpl(Inline)]
    public StringRef String(ReadOnlySpan<char> content)
        => Strings.String(content);

    [MethodImpl(Inline)]
    public MemorySegment Store(ReadOnlySpan<byte> src)
    {
        var size = src.Length;
        var dst = Memory(size);
        var edit = dst.Edit;
        for(var j=0; j<size; j++)
            seek(edit,j) = skip(src,j);
        return dst;
    }
}
