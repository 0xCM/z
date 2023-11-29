//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

[StructLayout(StructLayout,Pack=1)]
public readonly record struct Point<A,B,C> : IComparable<Point<A,B,C>>
    where A : unmanaged
    where B : unmanaged
    where C : unmanaged
{
    public readonly A X;

    public readonly B Y;

    public readonly C Z;

    [MethodImpl(Inline)]
    public Point(A x, B y, C c)
    {
        X = x;
        Y = y;
        Z = c;
    }

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get
        {
            var q = Convert(w32);
            return nhash(q.X, q.Y, q.Z);
        }
    }

    [MethodImpl(Inline)]
    public int CompareTo(Point<A,B,C> src)
    {
        var a = Convert(w64);
        var b = src.Convert(w64);
        var result = a.X.CompareTo(b.X);
        if(result == 0)
            result = a.Y.CompareTo(b.Y);
        if(result == 0)
            result = a.Z.CompareTo(b.Z);
        return result;
    }

    [MethodImpl(Inline)]
    public bool Equals(Point<A,B,C> src)
    {
        var p = Convert(w64);
        var q = src.Convert(w64);
        return p.X == q.X && p.Y == q.Y && p.Z == q.Z;
    }

    public override int GetHashCode()
        => Hash;

    [MethodImpl(Inline)]
    public Point<byte,byte,byte> Convert(W8 w)
        => (bw8(X), bw8(Y), bw8(Z));

    [MethodImpl(Inline)]
    public Point<ushort,ushort,ushort> Convert(W16 w)
        => (bw16(X), bw16(Y), bw16(Z));

    [MethodImpl(Inline)]
    public Point<ushort,byte,byte> Convert(W16 m, W8 n, W8 p)
        => (bw16(X), bw8(Y), bw8(Z));

    [MethodImpl(Inline)]
    public Point<uint,uint,uint> Convert(W32 w)
        => (bw32(X), bw32(Y), bw32(Z));

    [MethodImpl(Inline)]
    public Point<ulong,ulong,ulong> Convert(W64 w)
        => (bw64(X), bw64(Y), bw64(Z));

    public string Format()
        => string.Format("({0}, {1}, {3})", X, Y, Z);

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator Point<A,B,C>((A x, B y, C z) src)
        => new Point<A,B,C>(src.x, src.y, src.z);

    [MethodImpl(Inline)]
    public static implicit operator (A x, B y, C z)(Point<A,B,C> src)
        => (src.X, src.Y, src.Z);

    [MethodImpl(Inline)]
    public static implicit operator Point<A,B,C>(Tripled<A,B,C> src)
        => new Point<A,B,C>(src.First, src.Second, src.Third);

    [MethodImpl(Inline)]
    public static implicit operator Tripled<A,B,C>(Point<A,B,C> src)
        => (src.X,src.Y,src.Z);

    [MethodImpl(Inline)]
    public static implicit operator Point<A,B,C>(ReadOnlySpan<byte> src)
        => first(recover<Point<A,B,C>>(src));
}
