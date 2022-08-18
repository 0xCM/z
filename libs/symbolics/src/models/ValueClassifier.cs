//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines an indexed/labeled sequence that forms a partition over som domain
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public class ValueClassifier : IClassifier
    {
        public readonly Label Name;

        readonly ReadOnlySeq<Label> _ClassNames;

        readonly ReadOnlySeq<LabeledValue<ulong>> _Values;

        readonly Index<Sym> _Symbols;

        readonly ReadOnlySeq<ValueClass> _Classes;

        [MethodImpl(Inline)]
        public ValueClassifier(Label name, ReadOnlySeq<Label> names, Sym[] symbols, ReadOnlySeq<LabeledValue<ulong>> values, ReadOnlySeq<ValueClass> classes)
        {
            Name = name;
            _Symbols = symbols;
            _ClassNames = names;
            _Values = values;
            _Classes = classes;
        }

        [MethodImpl(Inline)]
        internal ref readonly Label SymName(uint index)
            => ref _ClassNames[index];

        [MethodImpl(Inline)]
        internal ref readonly LabeledValue<ulong> Value(uint index)
            => ref _Values[index];

        [MethodImpl(Inline)]
        internal ref Sym Sym(uint index)
            => ref _Symbols[index];

        [MethodImpl(Inline)]
        internal ref readonly ValueClass Class(uint index)
            => ref _Classes[index];

        public ref readonly ValueClass this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref _Classes[i];
        }

        public ref readonly ValueClass this[int i]
        {
            [MethodImpl(Inline)]
            get => ref _Classes[i];
        }

        public uint ClassCount
        {
            [MethodImpl(Inline)]
            get => _Classes.Count;
        }

        public ReadOnlySpan<Label> ClassNames
        {
            [MethodImpl(Inline)]
            get => _ClassNames.View;
        }

        public ReadOnlySpan<Sym> Symbols
        {
            [MethodImpl(Inline)]
            get => _Symbols.View;
        }

        public ReadOnlySpan<LabeledValue<ulong>> Values
        {
            [MethodImpl(Inline)]
            get => _Values.View;
        }

        public ReadOnlySpan<ValueClass> Classes
        {
            [MethodImpl(Inline)]
            get => _Classes.View;
        }

        Label IClassifier.Name
            => Name;
    }
}