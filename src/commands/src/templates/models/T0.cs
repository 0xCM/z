//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TextTemplates
    {
        public class TextTemplate<T0> : TextTemplate
        {
            const byte Arity = 1;

            const byte Index = Arity - 1;

            public TextTemplate(TextBlock src)
                : base(src, Arity)
            {

            }

            public TextTemplate(TextBlock src, byte arity)
                : base(src, Arity)
            {

            }

            public ref T0 Param0
            {
                [MethodImpl(Inline)]
                get => ref Var<T0>(Index);
            }

            public ref T0 this[N0 n]
            {
                [MethodImpl(Inline)]
                get => ref Param0;
            }
        }
    }
}