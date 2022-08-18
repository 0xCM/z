//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TextTemplates
    {
        public class TextTemplate<T0,T1> : TextTemplate<T0>
        {
            const byte Arity = 2;

            const byte Index = Arity - 1;

            public TextTemplate(TextBlock src)
                : base(src, Arity)
            {

            }

            public TextTemplate(TextBlock src, byte arity)
                : base(src, Arity)
            {

            }

            public ref T1 Param1
            {
                [MethodImpl(Inline)]
                get => ref Var<T1>(Index);
            }

            public ref T1 this[N1 n]
            {
                [MethodImpl(Inline)]
                get => ref Param1;
            }
        }
    }
}