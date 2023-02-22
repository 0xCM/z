//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct BitVector<T>
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
    }
}