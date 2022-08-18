//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public struct Point<T> : IPoint<Point<T>,T>
        where T : unmanaged
    {
        public num<T> X;

        public num<T> Y;

        [MethodImpl(Inline)]
        public Point(T x, T y)
        {
            X = x;
            Y = y;
        }

        public string Format()
            => string.Format("({0}, {1})", X, Y);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(Point<T> src)
            => X == src.X && Y == src.Y;

        public override int GetHashCode()
            => (int)alg.hash.combine(u32(X), u32(Y));

        public override bool Equals(object src)
            => src is Point<T> p && Equals(p);

        [MethodImpl(Inline)]
        public int CompareTo(Point<T> src)
        {
            var result = X.CompareTo(src.X);
            if(result == 0)
                result = Y.CompareTo(src.Y);
            return result;
        }

        T IPoint<T>.X
            => X;

        T IPoint<T>.Y
            => Y;

        [MethodImpl(Inline)]
        public static implicit operator Point<T>((T x, T y) src)
            => new (src.x, src.y);

        [MethodImpl(Inline)]
        public static implicit operator (T x, T y)(Point<T> src)
            => (src.X, src.Y);

        [MethodImpl(Inline)]
        public static implicit operator Point<T>(ColPoint<T> src)
            => new (src.X,src.Y);

        [MethodImpl(Inline)]
        public static implicit operator Point<T>(RowPoint<T> src)
            => new (src.X,src.Y);

        [MethodImpl(Inline)]
        public static implicit operator ColPoint<T>(Point<T> src)
            => new (src.X,src.Y);

        [MethodImpl(Inline)]
        public static implicit operator RowPoint<T>(Point<T> src)
            => new (src.X,src.Y);

        [MethodImpl(Inline)]
        public static bit operator ==(Point<T> a, Point<T> b)
            => a.X == b.X && a.Y == b.Y;

        [MethodImpl(Inline)]
        public static bit operator !=(Point<T> a, Point<T> b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static bit operator >(Point<T> a, Point<T> b)
            => a.X > b.X;

        [MethodImpl(Inline)]
        public static bit operator <(Point<T> a, Point<T> b)
            => a.X < b.X;

        [MethodImpl(Inline)]
        public static bit operator >=(Point<T> a, Point<T> b)
            => a.X >= b.X;

        [MethodImpl(Inline)]
        public static bit operator <=(Point<T> a, Point<T> b)
            => a.X <= b.X;

        [MethodImpl(Inline)]
        public static Point<T> operator +(Point<T> a, Point<T> b)
            => new (a.X + b.X, a.Y + b.Y);

        [MethodImpl(Inline)]
        public static Point<T> operator -(Point<T> a, Point<T> b)
            => new (a.X - b.X, a.Y - b.Y);

        public static Point<T> Zero => default;
    }
}