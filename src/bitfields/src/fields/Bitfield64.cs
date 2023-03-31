//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = Bitfields;
    using S = System.UInt64;

    public struct Bitfield64
    {
        public const byte Width = 64;

        S _State;

        [MethodImpl(Inline)]
        public Bitfield64(S state)
            => _State = state;

        public readonly S State
        {
            [MethodImpl(Inline)]
            get => _State;
        }

        public Bitfield32 Lo
        {
            [MethodImpl(Inline)]
            get => api.lo(this);
        }

        public Bitfield32 Hi
        {
            [MethodImpl(Inline)]
            get => api.hi(this);
        }

        public S this[byte min, byte max]
        {
            [MethodImpl(Inline)]
            get => Extract(min, max);

            [MethodImpl(Inline)]
            set => Store(value, min, max);
        }

        public bit this[byte pos]
        {
            [MethodImpl(Inline)]
            get => bits.test(_State, pos);

            [MethodImpl(Inline)]
            set => bits.set(_State, pos, value);
        }

        [MethodImpl(Inline)]
        public readonly S Extract(byte min, byte max)
            => bits.extract(_State, min, max);

        [MethodImpl(Inline)]
        public void Store(S src, byte min, byte max)
            => bits.store(src, min, max, ref _State);

        [MethodImpl(Inline)]
        public readonly V Extract<V>(byte min, byte max)
            => @as<S,V>(Extract(min,max));

        [MethodImpl(Inline)]
        public void Store<V>(V src, byte min, byte max)
            => Store(@as<V,S>(src),min,max);

        public override string ToString()
            => Format();

        public string Format()
            => api.format(this);

        [MethodImpl(Inline)]
        internal void Overwrite(S src)
            => _State = src;

        [MethodImpl(Inline)]
        public static implicit operator Bitfield64(S src)
            => new Bitfield64(src);

        [MethodImpl(Inline)]
        public static explicit operator S(Bitfield64 src)
            => src._State;
    }
}