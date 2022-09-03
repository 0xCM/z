//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using api = Bitfields;
    using S = System.UInt32;

    /// <summary>
    /// Defines a 32-bit bitfield over a 32-bit integral type
    /// </summary>
    public struct Bitfield32
    {
        public const byte Width = 32;

        S _State;

        [MethodImpl(Inline)]
        public Bitfield32(S state)
            => _State = state;

        public readonly S State
        {
            [MethodImpl(Inline)]
            get => _State;
        }

        public bit this[byte pos]
        {
            [MethodImpl(Inline)]
            get => bits.test(_State, pos);

            [MethodImpl(Inline)]
            set => bits.set(_State, pos, value);
        }

        public S this[byte min, byte max]
        {
            [MethodImpl(Inline)]
            get => Extract(min, max);

            [MethodImpl(Inline)]
            set => Store(value, min, max);
        }

        public readonly Bitfield16 Lo
        {
            [MethodImpl(Inline)]
            get => api.lo(this);
        }

        public readonly Bitfield16 Hi
        {
            [MethodImpl(Inline)]
            get => api.hi(this);
        }

        readonly Bitfield8 LoLo
        {
            [MethodImpl(Inline)]
            get => Lo.Lo;
        }

        readonly Bitfield8 LoHi
        {
            [MethodImpl(Inline)]
            get => Lo.Hi;
        }

        readonly Bitfield8 HiLo
        {
            [MethodImpl(Inline)]
            get => Hi.Lo;
        }

        readonly Bitfield8 HiHi
        {
            [MethodImpl(Inline)]
            get => Hi.Hi;
        }

        public readonly ReadOnlySpan<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(_State);
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

        [MethodImpl(Inline)]
        public Bitfield8 Seg(N0 n, W8 w)
            => LoLo;

        [MethodImpl(Inline)]
        public Bitfield8 Seg(N1 n, W8 w)
            => LoHi;

        [MethodImpl(Inline)]
        public Bitfield8 Seg(N2 n, W8 w)
            => HiLo;

        [MethodImpl(Inline)]
        public Bitfield8 Seg(N3 n, W8 w)
            => HiHi;

        [MethodImpl(Inline)]
        public Bitfield16 Seg(N0 n, W16 w)
            => Lo;

        [MethodImpl(Inline)]
        public Bitfield16 Seg(N1 n, W16 w)
            => Hi;

        public override string ToString()
            => Format();

        public string Format()
            => api.format(this);

        [MethodImpl(Inline)]
        internal void Overwrite(S src)
            => _State = src;


        [MethodImpl(Inline)]
        public static implicit operator Bitfield32(S src)
            => new Bitfield32(src);

        [MethodImpl(Inline)]
        public static explicit operator S(Bitfield32 src)
            => src.State;
    }
}