//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TypeNats
    {
        public readonly struct Point<X0,X1,T>
            where X0 : unmanaged, ITypeNat
            where X1 : unmanaged, ITypeNat
            where T : unmanaged
        {
            public readonly T Value;

            [MethodImpl(Inline)]
            public Point(T value)
            {
                Value = value;
            }

            public Dim<X0,X1,T> Dim => default;


            [MethodImpl(Inline)]
            public static implicit operator Point<X0,X1,T>(T src)
                => new (src);

            [MethodImpl(Inline)]
            public static implicit operator T(Point<X0,X1,T> src)
                => src.Value;
        }
    }
}