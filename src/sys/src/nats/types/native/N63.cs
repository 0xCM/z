//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using K = N63;

    public readonly struct N63 : INativeNatural, INatSeq<K,N6,N3>
    {
        public const ulong Value = (1ul << 6) - 1;

        public const string Text = "63";

        public ulong NatValue => Value;

        public string NatText => Text;

        public static K Rep => default;

        [MethodImpl(Inline)]
        public static implicit operator int(K src) => (int)Value;

        [MethodImpl(Inline)]
        public static implicit operator byte(K src) => (byte)Value;

        [MethodImpl(Inline)]
        public static implicit operator ushort(K src) => (ushort)Value;

        [MethodImpl(Inline)]
        public static implicit operator uint(K src) => (uint)Value;

        [MethodImpl(Inline)]
        public static implicit operator ulong(K src) => Value;

        [MethodImpl(Inline)]
        public string Format() => Text;


        public override string ToString() => Format();


        public override int GetHashCode() =>  (int)Value;
    }
}