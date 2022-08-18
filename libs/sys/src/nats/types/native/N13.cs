//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N13 :
        INativeNatural,
        INatNumber<N13>,
        INatPrior<N13,N12>
    {
        public const ulong Value = 13;

        public const string Text = "13";

        public ulong NatValue
            => Value;

        public string NatText
            => Text;

        [MethodImpl(Inline)]
        public static implicit operator int(N13 src)
            => (int)Value;

        [MethodImpl(Inline)]
        public static implicit operator byte(N13 src)
            => (byte)Value;

        [MethodImpl(Inline)]
        public static implicit operator ushort(N13 src)
            => (ushort)Value;

        [MethodImpl(Inline)]
        public static implicit operator uint(N13 src)
            => (uint)Value;

        [MethodImpl(Inline)]
        public static implicit operator ulong(N13 src)
            => Value;

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public override string ToString()
            => Text;
    }
}