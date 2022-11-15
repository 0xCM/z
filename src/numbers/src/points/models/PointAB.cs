//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [StructLayout(StructLayout,Pack=1)]
    public readonly record struct Point<A,B> : IComparable<Point<A,B>>
        where A : unmanaged
        where B : unmanaged
    {
        public readonly A X;

        public readonly B Y;

        [MethodImpl(Inline)]
        public Point(A x, B y)
        {
            X = x;
            Y = y;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get
            {
                var x = Convert(w32);
                return alg.hash.combine(x.X,x.Y);
            }
        }

        [MethodImpl(Inline)]
        public int CompareTo(Point<A,B> src)
        {
            var a = Convert(w64);
            var b = src.Convert(w64);
            var result = a.X.CompareTo(b.X);
            if(result == 0)
                result = a.Y.CompareTo(b.Y);
            return result;
        }

        [MethodImpl(Inline)]
        public bool Equals(Point<A,B> src)
        {
            var p = Convert(w64);
            var q = src.Convert(w64);
            return p.X == q.X && p.Y == q.Y;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public Point<byte,byte> Convert(W8 w)
            => (bw8(X),bw8(Y));

        [MethodImpl(Inline)]
        public Point<ushort,ushort> Convert(W16 w)
            => (bw16(X),bw16(Y));

        [MethodImpl(Inline)]
        public Point<byte,ushort> Convert(W8 m, W16 n)
            => (bw8(X),bw16(Y));

        [MethodImpl(Inline)]
        public Point<byte,uint> Convert(W8 m, W32 n)
            => (bw8(X),bw32(Y));

        [MethodImpl(Inline)]
        public Point<byte,ulong> Convert(W8 m, W64 n)
            => (bw8(X),bw64(Y));

        [MethodImpl(Inline)]
        public Point<ushort,byte> Convert(W16 m, W8 n)
            => (bw16(X),bw8(Y));

        [MethodImpl(Inline)]
        public Point<ushort,uint> Convert(W16 m, W32 n)
            => (bw16(X),bw32(Y));

        [MethodImpl(Inline)]
        public Point<ushort,ulong> Convert(W16 m, W64 n)
            => (bw16(X),bw64(Y));

        [MethodImpl(Inline)]
        public Point<uint,uint> Convert(W32 w)
            => (bw32(X),bw32(Y));

        [MethodImpl(Inline)]
        public Point<uint,byte> Convert(W32 m, W8 n)
            => (bw32(X),bw8(Y));

        [MethodImpl(Inline)]
        public Point<uint,ushort> Convert(W32 m, W16 n)
            => (bw32(X),bw16(Y));

        [MethodImpl(Inline)]
        public Point<uint,ulong> Convert(W32 m, W64 n)
            => (bw32(X),bw64(Y));

        [MethodImpl(Inline)]
        public Point<ulong,ulong> Convert(W64 w)
            => (bw64(X),bw64(Y));

        [MethodImpl(Inline)]
        public Point<ulong,byte> Convert(W64 m, W8 n)
            => (bw64(X),bw8(Y));

        [MethodImpl(Inline)]
        public Point<ulong,ushort> Convert(W64 m, W16 n)
            => (bw64(X),bw16(Y));

        [MethodImpl(Inline)]
        public Point<ulong,uint> Convert(W64 m, W32 n)
            => (bw64(X),bw32(Y));

        public string Format()
            => string.Format("({0}, {1})", X, Y);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Point<A,B>((A x, B y) src)
            => new Point<A,B>(src.x, src.y);

        [MethodImpl(Inline)]
        public static implicit operator Point<A,B>(Paired<A,B> src)
            => new Point<A,B>(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator Paired<A,B>(Point<A,B> src)
            => (src.X,src.Y);

        [MethodImpl(Inline)]
        public static implicit operator (A x, B y)(Point<A,B> src)
            => (src.X,src.Y);

        [MethodImpl(Inline)]
        public static implicit operator Point<A,B>(ReadOnlySpan<byte> src)
            => first(recover<Point<A,B>>(src));
    }
}