//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public struct ColPoint<T> : IPoint<ColPoint<T>,T>
        where T : unmanaged
    {
        public num<T> X;

        public num<T> Y;

        [MethodImpl(Inline)]
        public ColPoint(T x, T y)
        {
            X = x;
            Y = y;
        }

        public string Format()
            => string.Format("({0}, {1})", X, Y);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(ColPoint<T> src)
            => X == src.X && Y == src.Y;


        public override int GetHashCode()
            => (int)alg.hash.combine(u32(X), u32(Y));

        public override bool Equals(object src)
            => src is ColPoint<T> p && Equals(p);

        [MethodImpl(Inline)]
        public int CompareTo(ColPoint<T> src)
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
        public static implicit operator ColPoint<T>((T x, T y) src)
            => new (src.x, src.y);

        [MethodImpl(Inline)]
        public static implicit operator (T x, T y)(ColPoint<T> src)
            => (src.X, src.Y);

        [MethodImpl(Inline)]
        public static bit operator ==(ColPoint<T> a, ColPoint<T> b)
            => a.X == b.X && a.Y == b.Y;

        [MethodImpl(Inline)]
        public static bit operator !=(ColPoint<T> a, ColPoint<T> b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static bit operator >(ColPoint<T> a, ColPoint<T> b)
            => a.X > b.X;

        [MethodImpl(Inline)]
        public static bit operator <(ColPoint<T> a, ColPoint<T> b)
            => a.X < b.X;

        [MethodImpl(Inline)]
        public static bit operator >=(ColPoint<T> a, ColPoint<T> b)
            => a.X >= b.X;

        [MethodImpl(Inline)]
        public static bit operator <=(ColPoint<T> a, ColPoint<T> b)
            => a.X <= b.X;

        [MethodImpl(Inline)]
        public static ColPoint<T> operator +(ColPoint<T> a, ColPoint<T> b)
            => new (a.X + b.X, a.Y + b.Y);

        [MethodImpl(Inline)]
        public static ColPoint<T> operator -(ColPoint<T> a, ColPoint<T> b)
            => new (a.X - b.X, a.Y - b.Y);

        [MethodImpl(Inline)]
        public static ColPoint<T> operator ++(ColPoint<T> a)
        {
            a.Y--;
            return a;
        }

        [MethodImpl(Inline)]
        public static ColPoint<T> operator --(ColPoint<T> a)
        {
            a.Y++;
            return a;
        }

        public static ColPoint<T> Zero => default;

    }
}