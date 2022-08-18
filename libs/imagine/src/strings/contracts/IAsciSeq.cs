//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IAsciSeq : ICharSeq
    {

    }

    [Free]
    public interface IAsciSeq<S> : IAsciSeq, IComparable<S>, IEquatable<S>, IHashed, IContented<S>
        where S : IAsciSeq<S>
    {
        S IContented<S>.Content
            => (S)this;

        int IByteSeq.Length
            => Content.Length;

        int IByteSeq.Capacity
            => Content.Capacity;

        ReadOnlySpan<byte> IByteSeq.View
            => Content.View;

        bool INullity.IsEmpty
            => Content.IsEmpty;
    }

    [Free]
    public interface IAsciSeq<S,N> : IAsciSeq<S>, INatBytes<S,N>
        where N : unmanaged, ITypeNat
        where S : struct, IAsciSeq<S,N>
    {
        S IContented<S>.Content
            => (S)this;

        BitWidth ISized.BitWidth
            => Typed.nat32u<N>()*8;

        ByteSize ISized.ByteCount
            => Typed.nat32u<N>();

        int IByteSeq.Length
            => Content.Length;

        int IByteSeq.Capacity
            => Content.Capacity;

        ReadOnlySpan<byte> IByteSeq.View
            => Content.View;

        bool INullity.IsEmpty
            => Content.IsEmpty;
    }
}