//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TextTemplates
    {
        public class TextTemplate<T0,T1,T2,T3,T4,T5,T6> : TextTemplate<T0,T1,T2,T3,T4,T5>
        {
            const byte Arity = 7;

            const byte Index = Arity - 1;

            public TextTemplate(TextBlock src)
                : base(src, Arity)
            {

            }

            public TextTemplate(TextBlock src, byte arity)
                : base(src, Arity)
            {

            }

            public ref T6 Param6
            {
                [MethodImpl(Inline)]
                get => ref Var<T6>(Index);
            }

            public ref T6 this[N6 n]
            {
                [MethodImpl(Inline)]
                get => ref Param6;
            }

        }
    }
}