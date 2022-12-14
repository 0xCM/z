//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TextTemplates
    {
        public class TextTemplate<T0,T1,T2,T3,T4,T5> : TextTemplate<T0,T1,T2,T3,T4>
        {
            const byte Arity = 6;

            const byte Index = Arity - 1;

            public TextTemplate(TextBlock src)
                : base(src, Arity)
            {

            }

            public TextTemplate(TextBlock src, byte arity)
                : base(src, Arity)
            {

            }

            public ref T5 Param5
            {
                [MethodImpl(Inline)]
                get => ref Var<T5>(Index);
            }

            public ref T5 this[N5 n]
            {
                [MethodImpl(Inline)]
                get => ref Param5;
            }

        }
    }
}