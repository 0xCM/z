//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct tuple<T0,T1,T2> : ITuple<tuple<T0,T1,T2>,N3,T0,T1,T2>
        where T0: IEquatable<T0>
        where T1: IEquatable<T1>
        where T2: IEquatable<T2>
    {
        T0 c0;

        T1 c1;

        T2 c2;

        [MethodImpl(Inline)]
        public tuple(T0 a0, T1 a1, T2 a2)
        {
            c0 = a0;
            c1 = a1;
            c2 = a2;
        }

        public T0 this[N0 n]
        {
            [MethodImpl(Inline)]
            get => c0;
            [MethodImpl(Inline)]
            set => c0 = value;
        }

        public T1 this[N1 n]
        {
            [MethodImpl(Inline)]
            get => c1;
            [MethodImpl(Inline)]
            set => c1 = value;
        }

        public T2 this[N2 n]
        {
            [MethodImpl(Inline)]
            get => c2;
            [MethodImpl(Inline)]
            set => c2 = value;
        }

        public string Format()
            => string.Format("({0},{1},{2})", c0, c1, c2);

        [MethodImpl(Inline)]
        public bool Equals(tuple<T0,T1,T2> src)
            => c0.Equals(src.c0) && c1.Equals(src.c1) && c2.Equals(src.c2);

        public override string ToString()
            => Format();
    }
}