//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using N = N4;
using A = asci4;
using S = System.UInt32;

using static sys;

using api = Asci;

/// <summary>
/// Defines an asci code sequence of length 4
/// </summary>
public readonly struct asci4 : IAsciSeq<A,N>, IUnmanaged<A>
{
    public const uint Size = 4;

    public readonly S Storage;

    [MethodImpl(Inline)]
    public asci4(S src)
        => Storage = src;

    [MethodImpl(Inline)]
    public asci4(char c0)
        => Storage = (byte)c0;

    [MethodImpl(Inline)]
    public asci4(char c0, char c1)
        => Storage = AsciSymbols.pack(c0, c1);

    [MethodImpl(Inline)]
    public asci4(char c0, char c1, char c2)
        => Storage = AsciSymbols.pack(c0,c1,c2);

    [MethodImpl(Inline)]
    public asci4(char c0, char c1, char c2, char c3)
        => Storage = AsciSymbols.pack(c0,c1,c2,c3);

    [MethodImpl(Inline)]
    public asci4(string src)
        => Storage = api.encode(n,src).Storage;

    [MethodImpl(Inline)]
    public asci4(ReadOnlySpan<char> src)
    {
        var c0 = src.Length >= 1 ? skip(src,0) : Chars.Null;
        var c1 = src.Length >= 2 ? skip(src,1) : Chars.Null;
        var c2 = src.Length >= 3 ? skip(src,2) : Chars.Null;
        var c3 = src.Length >= 4 ? skip(src,3) : Chars.Null;
        Storage = AsciSymbols.pack(c0,c1,c2,c3);
    }

    public bool IsBlank
    {
        [MethodImpl(Inline)]
        get => IsNull || Equals(Spaced);
    }

    public bool IsNull
    {
        [MethodImpl(Inline)]
        get => Equals(Null);
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Storage == 0;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Storage != 0;
    }

    public A Zero
    {
        [MethodImpl(Inline)]
        get => Null;
    }

    public int Length
    {
        [MethodImpl(Inline)]
        get => api.length(this);
    }

    public int Capacity
    {
        [MethodImpl(Inline)]
        get => (int)Size;
    }

    public string Text
    {
        [MethodImpl(Inline)]
        get => api.decode(this);
    }

    public AsciSymbol this[int i]
    {
        [MethodImpl(Inline)]
        get => sys.skip(sys.bytes(Storage), i);
    }

    public AsciSymbol this[uint i]
    {
        [MethodImpl(Inline)]
        get => sys.skip(sys.bytes(Storage), i);
    }

    [MethodImpl(Inline)]
    public int CompareTo(A src)
        => Text.CompareTo(src.Text);

    [MethodImpl(Inline)]
    public bool Equals(A src)
        => Storage.Equals(src.Storage);

    public override bool Equals(object src)
        => src is A j && Equals(j);

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => Storage;
    }

    public override int GetHashCode()
        => Hash;

    [MethodImpl(Inline)]
    public string Format()
        => Text;

    public override string ToString()
        => Text;

    public static A Null
    {
        [MethodImpl(Inline)]
        get => new (default(S));
    }

    public static A Spaced
    {
        [MethodImpl(Inline)]
        get => api.spaced(default(N));
    }

    [MethodImpl(Inline)]
    public static implicit operator A(string src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator A(ReadOnlySpan<char> src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator A(TextBlock src)
        => new (src.Format());

    [MethodImpl(Inline)]
    public static implicit operator string(A src)
        => src.Text;

    [MethodImpl(Inline)]
    public static implicit operator A(ushort src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator A(uint src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator A(asci2 src)
        => new (src.Storage);

    [MethodImpl(Inline)]
    public static explicit operator byte(A src)
        => (byte)src.Storage;

    [MethodImpl(Inline)]
    public static explicit operator ushort(A src)
        => (ushort)src.Storage;

    [MethodImpl(Inline)]
    public static explicit operator uint(A src)
        => src.Storage;

    [MethodImpl(Inline)]
    public static bool operator ==(A a, A b)
        => a.Equals(b);

    [MethodImpl(Inline)]
    public static bool operator !=(A a, A b)
        => !a.Equals(b);

    static N n => default;
}
