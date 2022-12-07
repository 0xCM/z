//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class PText
    {
        public class PT<T0> : PText
        {
            const byte Arity = 1;

            const byte Index = Arity - 1;

            public PT(TextBlock src)
                : base(src, Arity)
            {

            }

            public PT(TextBlock src, byte arity)
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