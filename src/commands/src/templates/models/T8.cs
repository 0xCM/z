//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TextParametrics
    {
        public class PT<T0,T1,T2,T3,T4,T5,T6,T7,T8> : PT<T0,T1,T2,T3,T4,T5,T6,T7>
        {
            const byte Arity = 9;

            const byte Index = Arity - 1;

            public PT(TextBlock src)
                : base(src, Arity)
            {

            }

            public PT(TextBlock src, byte arity)
                : base(src, Arity)
            {

            }

            public ref T8 Param8
            {
                [MethodImpl(Inline)]
                get => ref Var<T8>(Index);
            }

            public ref T8 this[N8 n]
            {
                [MethodImpl(Inline)]
                get => ref Param8;
            }
        }
    }
}