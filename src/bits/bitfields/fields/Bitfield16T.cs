//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using api = Bitfields;
    using S = System.UInt16;
    using W = W16;

    [StructLayout(LayoutKind.Sequential, Size=2)]
    public struct Bitfield16<T>
        where T : unmanaged
    {
        public const byte Width = 16;

        static W w => default;

        S _State;

        [MethodImpl(Inline)]
        public Bitfield16(T state)
            => _State = uint16(state);

        [MethodImpl(Inline)]
        public Bitfield16(S state)
            => _State = state;

        public readonly T State
        {
            [MethodImpl(Inline)]
            get => @as<uint,T>(_State);
        }

        internal readonly S State16u
        {
            [MethodImpl(Inline)]
            get => _State;
        }

        public readonly Bitfield8<T> Lo
        {
            [MethodImpl(Inline)]
            get => api.lo(this);
        }

        public readonly Bitfield8<T> Hi
        {
            [MethodImpl(Inline)]
            get => api.hi(this);
        }

        public readonly ReadOnlySpan<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(_State);
        }

        public bit this[byte pos]
        {
            [MethodImpl(Inline)]
            get => bits.test(_State, pos);

            [MethodImpl(Inline)]
            set => bits.set(_State, pos, value);
        }

        public T this[byte min, byte max]
        {
            [MethodImpl(Inline)]
            get => Extract(min, max);

            [MethodImpl(Inline)]
            set => Store(value, min, max);
        }

        public override string ToString()
            => Format();

        public readonly string Format()
            => api.format(this);

        [MethodImpl(Inline)]
        public readonly T Extract(byte offset, byte width)
            => api.seg(this, offset, width);

        [MethodImpl(Inline)]
        public void Store(T src, byte min, byte max)
            => bits.store(u16(src), min, max, ref _State);

        [MethodImpl(Inline)]
        public readonly V Extract<V>(byte min, byte max)
            => @as<T,V>(Extract(min,max));

        [MethodImpl(Inline)]
        public void Store<V>(V src, byte min, byte max)
            => Store(@as<V,T>(src),min,max);

        [MethodImpl(Inline)]
        internal void Overwrite(S src)
            => _State = src;

        [MethodImpl(Inline)]
        public static implicit operator Bitfield16<T>(T src)
            => new Bitfield16<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator Bitfield16<T>(S src)
            => new Bitfield16<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(Bitfield16<T> src)
            => src.State;

        [MethodImpl(Inline)]
        public static explicit operator S(Bitfield16<T> src)
            => src.State16u;

        [MethodImpl(Inline)]
        public static implicit operator Bitfield16(Bitfield16<T> src)
            => api.create(w, src.State16u);

    }
}