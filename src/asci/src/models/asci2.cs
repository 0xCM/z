//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using N = N2;
using W = W16;
using A = asci2;
using S = System.UInt16;

using static sys;

using api = Asci;

/// <summary>
/// Defines an asci code sequence of length 2
/// </summary>
public readonly record struct asci2 : IAsciSeq<A,N>, IUnmanaged<A>
{
    internal readonly S Storage;

    [MethodImpl(Inline)]
    public asci2(S src)
        => Storage = src;

    [MethodImpl(Inline)]
    public asci2(string src)
        => Storage = api.encode(n, src).Storage;

    [MethodImpl(Inline)]
    public asci2(char c0)
        => Storage = (byte)c0;

    [MethodImpl(Inline)]
    public asci2(char c0, char c1)
        => Storage = AsciSymbols.pack(c0, c1);

    [MethodImpl(Inline)]
    public asci2(ReadOnlySpan<char> src)
    {
        var c0 = src.Length >= 1 ? skip(src,0) : Chars.Null;
        var c1 = src.Length >= 2 ? skip(src,1) : Chars.Null;
        Storage = AsciSymbols.pack(c0,c1);
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
        get => Size;
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
        => Storage == src.Storage;

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

    public const int Size = 2;

    public static A Null
    {
        [MethodImpl(Inline)]
        get => new (default(S));
    }

    public static A Spaced
    {
        [MethodImpl(Inline)]
        get => Asci.spaced(n);
    }

    static N n => default;

    static W w => default;

    [MethodImpl(Inline)]
    public static implicit operator string(A src)
        => src.Text;

    [MethodImpl(Inline)]
    public static implicit operator A(string src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator A(ReadOnlySpan<char> src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator A((char a, char b) src)
        => api.encode(src.a, src.b);

    [MethodImpl(Inline)]
    public static implicit operator A(Pair<char> src)
        => api.encode(src.Left, src.Right);

    [MethodImpl(Inline)]
    public static implicit operator A(TextBlock src)
        => new (src.Format());

    [MethodImpl(Inline)]
    public static implicit operator A(S src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator ushort(A src)
        => src.Storage;

    [MethodImpl(Inline)]
    public static implicit operator AsciSeq<N,A>(A src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator AsciSeq<A>(A src)
        => new (src);
}
