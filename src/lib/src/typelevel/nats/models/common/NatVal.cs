//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Captures the value of a type natural
    /// </summary>
    public readonly struct NatVal
    {
        public readonly ulong Value;

        [MethodImpl(Inline)]
        public static NatVal From(ulong src)
            => new NatVal(src);

        [MethodImpl(Inline)]
        public static NatVal From(long src)
            => new NatVal((ulong)src);

        [MethodImpl(Inline)]
        public static implicit operator byte(NatVal src)
            => (byte)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator sbyte(NatVal src)
            => (sbyte)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator short(NatVal src)
            => (short)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator ushort(NatVal src)
            => (ushort)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator int(NatVal src)
            => (int)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator uint(NatVal src)
            => (uint)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator long(NatVal src)
            => (long)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator ulong(NatVal src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator NatVal(ulong src)
            => From(src);

        [MethodImpl(Inline)]
        NatVal(ulong src)
            => this.Value = src;

        public override string ToString()
            => Value.ToString();
    }
}