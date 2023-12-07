//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using S = DecimalDigitSym;
using C = DecimalDigitCode;
using V = DecimalDigitValue;
using D = DecimalDigit;
using T = System.Byte;
using B = Base10;

[DataWidth(4)]
public readonly record struct DecimalDigit : IDigit<D,B,S,C,V>
{
    readonly T Data;

    [MethodImpl(Inline)]
    public DecimalDigit(V src)
    {
        Data = (T)src;
    }

    public readonly V Value
    {
        [MethodImpl(Inline)]
        get => (V)Data;
    }

    public S Symbol
    {
        [MethodImpl(Inline)]
        get => Digital.symbol(Value);
    }

    public C Code
    {
        [MethodImpl(Inline)]
        get => Digital.code(Value);
    }

    public char Char
    {
        [MethodImpl(Inline)]
        get => (char)Symbol;
    }

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => Data;
    }

    public bool IsZero
    {
        [MethodImpl(Inline)]
        get => Data == 0;
    }

    public bool IsNonZero
    {
        [MethodImpl(Inline)]
        get => Data != 0;
    }

    [MethodImpl(Inline)]
    public int CompareTo(D src)
        => Data.CompareTo(src.Data);

    public override int GetHashCode()
        => Hash;

    [MethodImpl(Inline)]
    public bool Equals(D src)
        => Value == src.Value;

    public string Format()
        => Char.ToString();

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator byte(D src)
        => (byte)src.Value;

    [MethodImpl(Inline)]
    public static implicit operator D(V src)
        => new D(src);

    [MethodImpl(Inline)]
    public static implicit operator V(D src)
        => src.Value;
}
