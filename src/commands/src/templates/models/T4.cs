//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 4020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TextParametrics
    {
        public class PT<T0,T1,T2,T3,T4> : PT<T0,T1,T2,T3>
        {
            const byte Arity = 5;

            const byte Index = Arity - 1;

            public PT(TextBlock src)
                : base(src, Arity)
            {

            }

            public PT(TextBlock src, byte arity)
                : base(src, Arity)
            {

            }

            public ref T4 Param4
            {
                [MethodImpl(Inline)]
                get => ref Var<T4>(Index);
            }

            public ref T4 this[N4 n]
            {
                [MethodImpl(Inline)]
                get => ref Param4;
            }
        }
    }
}