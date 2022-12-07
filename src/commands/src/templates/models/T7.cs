//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class PText
    {
        public class PT<T0,T1,T2,T3,T4,T5,T6,T7> : PT<T0,T1,T2,T3,T4,T5,T6>
        {
            const byte Arity = 8;

            const byte Index = Arity - 1;

            public PT(TextBlock src)
                : base(src, Arity)
            {

            }

            public PT(TextBlock src, byte arity)
                : base(src, Arity)
            {

            }

            public ref T7 Param7
            {
                [MethodImpl(Inline)]
                get => ref Var<T7>(Index);
            }

            public ref T7 this[N7 n]
            {
                [MethodImpl(Inline)]
                get => ref Param7;
            }
        }
    }
}