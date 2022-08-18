//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using api = BitVectors;

    public struct BitVector<T> : IBitVector<BitVector<T>,T>
        where T : unmanaged, IEquatable<T>
    {
        T _State;

        [MethodImpl(Inline)]
        public BitVector(in T state)
        {
            _State = state;
        }

        public T State
        {
            [MethodImpl(Inline)]
            get => _State;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => width<T>();
        }

        public string Format()
            => BitVectors.format(this);

        [MethodImpl(Inline)]
        public bool Equals(BitVector<T> src)
            => State.Equals(src.State);

        [MethodImpl(Inline)]
        public int CompareTo(BitVector<T> src)
            => bw64(this).CompareTo(bw64(src));

        Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(_State);
        }

        [MethodImpl(Inline)]
        Span<byte> Segment(uint offset)
            => slice(Bytes, offset);

        [MethodImpl(Inline)]
        public ref ScalarBits<byte> Scalar(W8 w, uint offset)
            => ref first(recover<ScalarBits<byte>>(Segment(offset)));

        [MethodImpl(Inline)]
        public ref ScalarBits<ushort> Scalar(W16 w, uint offset)
            => ref first(recover<ScalarBits<ushort>>(Segment(offset)));

        [MethodImpl(Inline)]
        public ref ScalarBits<uint> Scalar(W32 w, uint offset)
            => ref first(recover<ScalarBits<uint>>(Segment(offset)));

        [MethodImpl(Inline)]
        public ref ScalarBits<ulong> Scalar(W64 w, uint offset)
            => ref first(recover<ScalarBits<ulong>>(Segment(offset)));
    }
}