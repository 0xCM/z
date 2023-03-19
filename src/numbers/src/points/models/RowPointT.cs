//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct RowPoint<T> : IPoint<RowPoint<T>,T>
        where T : unmanaged
    {
        public num<T> X;

        public num<T> Y;

        [MethodImpl(Inline)]
        public RowPoint(T x, T y)
        {
            X = x;
            Y = y;
        }

        public string Format()
            => string.Format("({0}, {1})", X, Y);

        public override string ToString()
            => Format();


        [MethodImpl(Inline)]
        public bool Equals(RowPoint<T> src)
            => X == src.X && Y == src.Y;


        public override int GetHashCode()
            => (int)sys.nhash(u32(X), u32(Y));

        public override bool Equals(object src)
            => src is RowPoint<T> p && Equals(p);

        [MethodImpl(Inline)]
        public int CompareTo(RowPoint<T> src)
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
        public static implicit operator RowPoint<T>((T x, T y) src)
            => new (src.x, src.y);

        [MethodImpl(Inline)]
        public static implicit operator (T x, T y)(RowPoint<T> src)
            => (src.X, src.Y);

        [MethodImpl(Inline)]
        public static bit operator ==(RowPoint<T> a, RowPoint<T> b)
            => a.X == b.X && a.Y == b.Y;

        [MethodImpl(Inline)]
        public static bit operator !=(RowPoint<T> a, RowPoint<T> b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static bit operator >(RowPoint<T> a, RowPoint<T> b)
            => a.X > b.X;

        [MethodImpl(Inline)]
        public static bit operator <(RowPoint<T> a, RowPoint<T> b)
            => a.X < b.X;

        [MethodImpl(Inline)]
        public static bit operator >=(RowPoint<T> a, RowPoint<T> b)
            => a.X >= b.X;

        [MethodImpl(Inline)]
        public static bit operator <=(RowPoint<T> a, RowPoint<T> b)
            => a.X <= b.X;

        [MethodImpl(Inline)]
        public static RowPoint<T> operator +(RowPoint<T> a, RowPoint<T> b)
            => new (a.X + b.X, a.Y + b.Y);

        [MethodImpl(Inline)]
        public static RowPoint<T> operator -(RowPoint<T> a, RowPoint<T> b)
            => new (a.X - b.X, a.Y - b.Y);

        [MethodImpl(Inline)]
        public static RowPoint<T> operator ++(RowPoint<T> a)
        {
            a.X--;
            return a;
        }

        [MethodImpl(Inline)]
        public static RowPoint<T> operator --(RowPoint<T> a)
        {
            a.X++;
            return a;
        }

        public static RowPoint<T> Zero => default;
    }
}