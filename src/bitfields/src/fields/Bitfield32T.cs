//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = Bitfields;
    using S = System.UInt32;
    using W = W32;

    /// <summary>
    /// Defines a 32-bit bitfield over a parametric type
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size=4)]
    public struct Bitfield32<T>
        where T : unmanaged
    {
        static W w => default;

        S _State;

        [MethodImpl(Inline)]
        public Bitfield32(T state)
            => _State = u32(state);

        [MethodImpl(Inline)]
        public Bitfield32(S state)
            => _State = state;

        public readonly Bitfield16<T> Lo
        {
            [MethodImpl(Inline)]
            get => api.lo(this);
        }

        public readonly Bitfield16<T> Hi
        {
            [MethodImpl(Inline)]
            get => api.hi(this);
        }

        public readonly T State
        {
            [MethodImpl(Inline)]
            get => @as<uint,T>(_State);
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

        [MethodImpl(Inline)]
        public readonly T Extract(byte offset, byte width)
            => api.extract(this, offset, width);

        [MethodImpl(Inline)]
        public void Store(T src, byte min, byte max)
            => bits.store(u32(src), min, max, ref _State);

        [MethodImpl(Inline)]
        public readonly V Extract<V>(byte min, byte max)
            => @as<T,V>(Extract(min,max));

        [MethodImpl(Inline)]
        public void Store<V>(V src, byte min, byte max)
            => Store(@as<V,T>(src),min,max);

        public override string ToString()
            => Format();

        public readonly string Format()
            => api.format(this);

        [MethodImpl(Inline)]
        internal void Overwrite(S src)
            => _State = src;

        internal readonly S State32u
        {
            [MethodImpl(Inline)]
            get => _State;
        }

        [MethodImpl(Inline)]
        public static implicit operator Bitfield32<T>(T src)
            => new Bitfield32<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator Bitfield32(Bitfield32<T> src)
            => api.create(w, src.State32u);

        [MethodImpl(Inline)]
        public static implicit operator Bitfield32<T>(S src)
            => new Bitfield32<T>(src);

        [MethodImpl(Inline)]
        public static explicit operator S(Bitfield32<T> src)
            => src.State32u;

        [MethodImpl(Inline)]
        public static implicit operator T(Bitfield32<T> src)
            => src.State;
    }
}