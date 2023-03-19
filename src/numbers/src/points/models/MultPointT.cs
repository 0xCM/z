//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct MultiPoint<T> : IPoint<MultiPoint<T>,Point<T>>
        where T : unmanaged
    {
        public RowPoint<T> X;

        public ColPoint<T> Y;

        [MethodImpl(Inline)]
        public MultiPoint(RowPoint<T> x, ColPoint<T> y)
        {
            X = x;
            Y = y;
        }

        public string Format()
            => string.Format("({0}, {1})", X, Y);

        public override string ToString()
            => Format();


        [MethodImpl(Inline)]
        public bool Equals(MultiPoint<T> src)
            => X == src.X && Y == src.Y;


        public override int GetHashCode()
            => sys.nhash(u32(X), u32(Y));

        public override bool Equals(object src)
            => src is MultiPoint<T> p && Equals(p);

        [MethodImpl(Inline)]
        public int CompareTo(MultiPoint<T> src)
        {
            var result = X.CompareTo(src.X);
            if(result == 0)
                result = Y.CompareTo(src.Y);
            return result;
        }

        Point<T> IPoint<Point<T>>.X
            => X;

        Point<T> IPoint<Point<T>>.Y
            => Y;

        [MethodImpl(Inline)]
        public static implicit operator MultiPoint<T>((RowPoint<T> x, ColPoint<T> y) src)
            => new (src.x, src.y);

        [MethodImpl(Inline)]
        public static implicit operator (RowPoint<T> x, ColPoint<T> y)(MultiPoint<T> src)
            => (src.X, src.Y);

        [MethodImpl(Inline)]
        public static implicit operator MultiPoint<T>(Point<T> src)
            => new (src, src);

        [MethodImpl(Inline)]
        public static implicit operator MultiPoint<T>(ColPoint<T> src)
            => new ((Point<T>)src, (Point<T>)src);

        [MethodImpl(Inline)]
        public static implicit operator MultiPoint<T>(RowPoint<T> src)
            => new ((Point<T>)src, (Point<T>)src);

        [MethodImpl(Inline)]
        public static implicit operator RowPoint<T>(MultiPoint<T> src)
            => src.X;

        [MethodImpl(Inline)]
        public static implicit operator ColPoint<T>(MultiPoint<T> src)
            => src.Y;

        [MethodImpl(Inline)]
        public static bit operator ==(MultiPoint<T> a, MultiPoint<T> b)
            => a.X == b.X && a.Y == b.Y;

        [MethodImpl(Inline)]
        public static bit operator !=(MultiPoint<T> a, MultiPoint<T> b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static bit operator >(MultiPoint<T> a, MultiPoint<T> b)
            => a.X > b.X;

        [MethodImpl(Inline)]
        public static bit operator <(MultiPoint<T> a, MultiPoint<T> b)
            => a.X < b.X;

        [MethodImpl(Inline)]
        public static bit operator >=(MultiPoint<T> a, MultiPoint<T> b)
            => a.X >= b.X;

        [MethodImpl(Inline)]
        public static bit operator <=(MultiPoint<T> a, MultiPoint<T> b)
            => a.X <= b.X;

        [MethodImpl(Inline)]
        public static MultiPoint<T> operator +(MultiPoint<T> a, MultiPoint<T> b)
            => new (a.X + b.X, a.Y + b.Y);

        [MethodImpl(Inline)]
        public static MultiPoint<T> operator -(MultiPoint<T> a, MultiPoint<T> b)
            => new (a.X - b.X, a.Y - b.Y);


        [MethodImpl(Inline)]
        public static MultiPoint<T> operator ++(MultiPoint<T> a)
        {
            a.X--;
            a.Y--;
            return a;
        }

        [MethodImpl(Inline)]
        public static MultiPoint<T> operator --(MultiPoint<T> a)
        {
            a.X++;
            a.Y++;
            return a;
        }

        public static MultiPoint<T> Zero => default;

    }
}