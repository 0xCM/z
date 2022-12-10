//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class CompositeDispenser : Dispenser<CompositeDispenser>, ICompositeDispenser
    {
        SymbolDispenser Symbols;

        SourceDispenser Sources;

        MemoryDispenser Memory;

        LabelDispenser Labels;

        NativeSigDispenser Sigs;

        StringDispenser Strings;

        internal CompositeDispenser(MemoryDispenser memory, StringDispenser strings, LabelDispenser labels, SymbolDispenser symbols, SourceDispenser source)
            : base(false)
        {
            Symbols = symbols;
            Sources = source;
            Memory = memory;
            Labels = labels;
            Strings = strings;
            Sigs = Dispense.sigs(memory, strings, labels);
        }

        internal CompositeDispenser()
            : base(true)
        {
            Symbols = Dispense.symbols();
            Sources = Dispense.source();
            Memory = Dispense.memory();
            Labels = Dispense.labels();
            Strings = Dispense.strings();
            Sigs = Dispense.sigs(Memory, Strings, Labels);
        }

        protected override void Dispose()
        {
            (Symbols as IDisposable).Dispose();
            (Sources as IDisposable).Dispose();
            (Memory  as IDisposable).Dispose();
            (Labels as IDisposable).Dispose();
            (Strings as IDisposable).Dispose();
        }

        [MethodImpl(Inline)]
        public NativeSigRef Sig(string scope, string name, NativeType ret, params NativeOpDef[] ops)
            => Sigs.Sig(scope, name, ret, ops);

        [MethodImpl(Inline)]
        public NativeSigRef Sig(NativeSigSpec spec)
            => Sigs.Sig(spec);

        [MethodImpl(Inline)]
        public LocatedSymbol Symbol(MemoryAddress location, string name)
            => Symbols.Symbol(location, name);

        [MethodImpl(Inline)]
        public LocatedSymbol Symbol(SymAddress location, string name)
            => Symbols.Symbol(location,name);

        [MethodImpl(Inline)]
        public HexRef Reserve(ByteSize size)
            => Memory.Memory(size);

        [MethodImpl(Inline)]
        public SourceText Source(string content)
            => Sources.Source(content);

        [MethodImpl(Inline)]
        public Label Label(string content)
            => Labels.Label(content);

        [MethodImpl(Inline)]
        public StringRef String(string content)
            => Strings.String(content);

        [MethodImpl(Inline)]
        public SourceText Source(ReadOnlySpan<string> src)
            => Sources.Source(src);

        [MethodImpl(Inline)]
        public HexRef Store(ReadOnlySpan<byte> src)
        {
            var size = src.Length;
            var hex = Reserve(size);
            var dst = hex.Edit;
            for(var j=0; j<size; j++)
                seek(dst,j) = skip(src,j);
            return hex;
        }

        MemorySeg IMemoryDispenser.Memory(ByteSize size)
            => Memory.Memory(size);
    }
}