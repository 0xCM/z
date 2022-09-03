//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N18 :
        INativeNatural,
        INatNumber<N18>,
        INatSeq<N18>,
        INatEven<N18>
    {
        public const ulong Value = 18;

        public const string Text = "18";

        public static N18 Rep
            => default;

        public static NatSeq<N1,N8> Seq
            => default;

        public string NatText
            => Text;

        public ulong NatValue
            => Value;

        [MethodImpl(Inline)]
        public static implicit operator int(N18 src)
            => (int)Value;

        [MethodImpl(Inline)]
        public static implicit operator byte(N18 src)
            => (byte)Value;

        [MethodImpl(Inline)]
        public static implicit operator ushort(N18 src)
            => (ushort)Value;

        [MethodImpl(Inline)]
        public static implicit operator uint(N18 src)
            => (uint)Value;

        [MethodImpl(Inline)]
        public static implicit operator ulong(N18 src)
            => Value;

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public override string ToString()
            => Text;
   }
}