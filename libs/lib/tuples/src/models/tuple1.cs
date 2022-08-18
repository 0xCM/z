//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct tuple<T0> : ITuple<tuple<T0>,N1,T0>
        where T0: IEquatable<T0>
    {
        T0 c0;

        [MethodImpl(Inline)]
        public tuple(T0 a0)
        {
            c0 = a0;
        }

        public T0 this[N0 n]
        {
            [MethodImpl(Inline)]
            get => c0;
            [MethodImpl(Inline)]
            set => c0 = value;
        }

        public string Format()
            => string.Format("({0})", c0);

        [MethodImpl(Inline)]
        public bool Equals(tuple<T0> src)
            => c0.Equals(src.c0);

        public override string ToString()
            => Format();
    }
}