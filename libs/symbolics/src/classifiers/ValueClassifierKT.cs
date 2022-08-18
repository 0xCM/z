//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines an indexed/labeled sequence that forms a partition over some domain
    /// </summary>
    public class ValueClassifier<K,T> : IClassifier
        where K : unmanaged
    {
        public readonly Label Name;

        internal ReadOnlySeq<Label> _ClassNames;

        internal ReadOnlySeq<LabeledValue<T>> _Values;

        internal ReadOnlySeq<ValueClass<K,T>> _Classes;

        Index<K> _Kinds;

        Index<Sym<K>> _Symbols;

        [MethodImpl(Inline)]
        public ValueClassifier(Label name, K[] kinds, Label[] names, Sym<K>[] symbols, ReadOnlySeq<LabeledValue<T>> values, ReadOnlySeq<ValueClass<K,T>> classes)
        {
            Name = name;
            _Symbols = symbols;
            _ClassNames = names;
            _Values = values;
            _Kinds = kinds;
            _Classes = classes;
        }

        public ref readonly ValueClass<K,T> this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref _Classes[i];
        }

        public ref readonly ValueClass<K,T> this[int i]
        {
            [MethodImpl(Inline)]
            get => ref _Classes[i];
        }

        public uint ClassCount
        {
            [MethodImpl(Inline)]
            get => _Classes.Count;
        }

        public ReadOnlySpan<K> Kinds
        {
            [MethodImpl(Inline)]
            get => _Kinds.View;
        }

        public ReadOnlySpan<Label> ClassNames
        {
            [MethodImpl(Inline)]
            get => _ClassNames.View;
        }

        public ReadOnlySpan<Sym<K>> Symbols
        {
            [MethodImpl(Inline)]
            get => _Symbols.View;
        }

        public ReadOnlySpan<LabeledValue<T>> Values
        {
            [MethodImpl(Inline)]
            get => _Values.View;
        }

        public ReadOnlySpan<ValueClass<K,T>> Classes
        {
            [MethodImpl(Inline)]
            get => _Classes.View;
        }

        Label IClassifier.Name
            => Name;

    }
}