//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct OptionSpecs<K> : IIndexedView<OptionSpecs<K>,ushort,OptionSpec<K>>
        where K : unmanaged
    {
        readonly Index<OptionSpec<K>> Data;

        [MethodImpl(Inline)]
        public OptionSpecs(OptionSpec<K>[] src)
            => Data = src;

        public OptionSpec<K>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<OptionSpec<K>> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public string Format()
            => Seq.format(Storage, Eol);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator OptionSpecs<K>(OptionSpec<K>[] src)
            => new OptionSpecs<K>(src);
    }
}