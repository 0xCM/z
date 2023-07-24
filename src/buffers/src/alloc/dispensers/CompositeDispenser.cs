//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class CompositeDispenser : Dispenser<CompositeDispenser>, ICompositeDispenser
    {
        readonly SymbolDispenser Symbols;

        readonly SourceDispenser Sources;

        readonly MemoryDispenser Memories;

        readonly LabelDispenser Labels;

        readonly NativeSigDispenser Sigs;

        readonly StringDispenser Strings;

        internal CompositeDispenser(MemoryDispenser memory, StringDispenser strings, LabelDispenser labels, SymbolDispenser symbols, SourceDispenser source)
            : base(false)
        {
            Symbols = symbols;
            Sources = source;
            Memories = memory;
            Labels = labels;
            Strings = strings;
            Sigs = Dispense.sigs(memory, strings, labels);
        }

        internal CompositeDispenser()
            : base(true)
        {
            Symbols = Dispense.symbols();
            Sources = Dispense.source();
            Memories = Dispense.memory();
            Labels = Dispense.labels();
            Strings = Dispense.strings();
            Sigs = Dispense.sigs(Memories, Strings, Labels);
        }

        protected override void Dispose()
        {
            (Symbols as IDisposable).Dispose();
            (Sources as IDisposable).Dispose();
            (Memories  as IDisposable).Dispose();
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
        public MemorySegment Memory(ByteSize size)
            => Memories.Memory(size);

        [MethodImpl(Inline)]
        public SourceText SourceText(string content)
            => Sources.SourceText(content);

        [MethodImpl(Inline)]
        public SourceLine SourceLine(TextLine src)
            => Sources.SourceLine(src);

        [MethodImpl(Inline)]
        public Label Label(string content)
            => Labels.Label(content);

        [MethodImpl(Inline)]
        public StringRef String(ReadOnlySpan<char> content)
            => Strings.String(content);

        [MethodImpl(Inline)]
        public SourceText SourceText(ReadOnlySpan<string> src)
            => Sources.SourceText(src);

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
}