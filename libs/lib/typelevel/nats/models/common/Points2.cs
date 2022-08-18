//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TypeNats
    {
        public readonly struct Points<X0,X1,T> : IIndex<Point<X0,X1,T>>
            where X0 : unmanaged, ITypeNat
            where X1 : unmanaged, ITypeNat
            where T : unmanaged
        {
            public readonly Index<Point<X0,X1,T>> Data;

            [MethodImpl(Inline)]
            public Points(Point<X0,X1,T>[] src)
            {
                Data = src;
            }

            public Point<X0,X1,T>[] Storage
            {
                [MethodImpl(Inline)]
                get => Data.Storage;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsNonEmpty;
            }

            public ref Point<X0,X1,T> this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref Point<X0,X1,T> this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public Dim<X0,X1,T> Dim => default;

            [MethodImpl(Inline)]
            public static implicit operator Points<X0,X1,T>(Point<X0,X1,T>[] src)
                => new (src);

            [MethodImpl(Inline)]
            public static implicit operator Points<X0,X1,T>(Index<Point<X0,X1,T>> src)
                => new (src);

            [MethodImpl(Inline)]
            public static implicit operator Point<X0,X1,T>[](Points<X0,X1,T> src)
                => src.Data;

            public static Points<X0,X1,T> Empty => sys.empty<Point<X0,X1,T>>();
        }
    }

}
