//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = BinaryDigitSym;
    using C = BinaryDigitCode;
    using V = BinaryDigitValue;
    using D = BinaryDigit;
    using A = AsciCode;
    using T = bit;
    using B = Base2;

    /// <summary>
    /// Represents a binary digit
    /// </summary>
    [DataWidth(1)]
    public readonly record struct BinaryDigit : IDigit<D,B,S,C,V>
    {
        const string D0 = "0";

        const string D1 = "1";

        readonly T Storage;

        [MethodImpl(Inline)]
        public BinaryDigit(V value)
        {
            Storage = (bit)value;
        }

        [MethodImpl(Inline)]
        public BinaryDigit(C src)
        {
            Storage = src == C.b1 ? T.On : T.Off;
        }

        [MethodImpl(Inline)]
        public BinaryDigit(S src)
        {
            Storage = src == S.b1 ? T.On : T.Off;
        }

        [MethodImpl(Inline)]
        public BinaryDigit(char src)
        {
            Storage = (S)src == S.b1 ? T.On : T.Off;
        }

        [MethodImpl(Inline)]
        public BinaryDigit(A src)
        {
            Storage = (S)src == S.b1 ? V.b1 : V.b0;
        }

        [MethodImpl(Inline)]
        public BinaryDigit(T src)
        {
            Storage = src;
        }

        public readonly V Value
        {
            [MethodImpl(Inline)]
            get => (V)Storage;
        }

        public S Symbol
        {
            [MethodImpl(Inline)]
            get => Storage ? S.b1 : S.b0;
        }

        public C Code
        {
            [MethodImpl(Inline)]
            get => (C)Symbol;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Storage;
        }

        public char Char
        {
            [MethodImpl(Inline)]
            get => (char)Symbol;
        }

        public T Bit
        {
            [MethodImpl(Inline)]
            get => Storage;
        }

        public bool IsZero
        {
            [MethodImpl(Inline)]
            get => Storage == 0;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Storage != 0;
        }

        [MethodImpl(Inline)]
        public D Inc()
            => Storage ? new D(T.Off) : new D(T.On);

        [MethodImpl(Inline)]
        public D Dec()
            => Storage ? new D(T.Off) : new D(T.On);

        [MethodImpl(Inline)]
        public D Not()
            => !Storage;

        [MethodImpl(Inline)]
        public string Format()
            => Storage ? D1 : D0;

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(D src)
            => Value == src.Value;

        [MethodImpl(Inline)]
        public int CompareTo(D src)
            => Storage.CompareTo(src.Storage);

        [MethodImpl(Inline)]
        public static implicit operator D(C src)
            => new BinaryDigit(src);

        [MethodImpl(Inline)]
        public static implicit operator D(S src)
            => new D(src);

        [MethodImpl(Inline)]
        public static implicit operator D(char src)
            => new D(src);

        [MethodImpl(Inline)]
        public static implicit operator D(A src)
            => new D(src);

        [MethodImpl(Inline)]
        public static implicit operator C(D src)
            => src.Code;

        [MethodImpl(Inline)]
        public static implicit operator V(D src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator D(V src)
            => new D(src);

        [MethodImpl(Inline)]
        public static implicit operator D(T src)
            => new D(src);

        [MethodImpl(Inline)]
        public static implicit operator T(D src)
            => src.Bit;

        [MethodImpl(Inline)]
        public static implicit operator char(D src)
            => src.Char;

        [MethodImpl(Inline)]
        public static explicit operator byte(D src)
            => (byte)src.Value;
    }
}