//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = Bitfields;
    using S = System.UInt64;
    using W = W64;

    [StructLayout(LayoutKind.Sequential, Size=8)]
    public struct Bitfield64<T>
        where T : unmanaged
    {
        static W w => default;

        S _State;

        [MethodImpl(Inline)]
        public Bitfield64(T state)
            => _State = bw64(state);

        [MethodImpl(Inline)]
        public Bitfield64(S state)
            => _State = state;

        [MethodImpl(Inline)]
        public readonly T Extract(byte min, byte max)
            => api.seg(this, min, max);

        public Bitfield32<T> Lo
        {
            [MethodImpl(Inline)]
            get => api.lo(this);
        }

        public Bitfield32<T> Hi
        {
            [MethodImpl(Inline)]
            get => api.hi(this);
        }


        public bit this[byte pos]
        {
            [MethodImpl(Inline)]
            get => bits.test(_State, pos);

            [MethodImpl(Inline)]
            set => bits.set(_State, pos, value);
        }

        public override string ToString()
            => Format();

        public string Format()
            => api.format(this);

        [MethodImpl(Inline)]
        internal void Overwrite(S src)
            => _State = src;

        internal S State
        {
            [MethodImpl(Inline)]
            get => _State;
        }

        [MethodImpl(Inline)]
        public static implicit operator Bitfield64<T>(T src)
            => new Bitfield64<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator Bitfield64<T>(S src)
            => new Bitfield64<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator Bitfield64(Bitfield64<T> src)
            => api.create(w, src.State);

        [MethodImpl(Inline)]
        public static explicit operator S(Bitfield64<T> src)
            => src._State;
    }
}