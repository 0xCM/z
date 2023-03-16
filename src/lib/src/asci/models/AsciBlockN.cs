//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = AsciCode;
    using S = AsciSymbol;
    using api = AsciBlocks;

    public readonly ref struct AsciBlock<N>
        where N : unmanaged, ITypeNat
    {
        readonly Span<S> Data;

        public static N Capacity => default;

        [MethodImpl(Inline)]
        internal AsciBlock(Span<S> data)
        {
            Data = data;
        }

        public AsciBlock<N> Alloc()
            => api.block<N>();

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => recover<S,byte>(Data);
        }

        public Span<C> Codes
        {
            [MethodImpl(Inline)]
            get => recover<C>(Bytes);
        }

        public Span<S> Symbols
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref S this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Data,index);
        }

        public ref S this[int index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Data,index);
        }

        public ReadOnlySpan<S> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public static implicit operator AsciBlock<N>(string src)
            => api.block<N>(src);
    }
}