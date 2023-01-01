//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TextPatterns
    {
        public class PT<T0> : TextPattern
        {
            const byte Arity = 1;

            public PT(TextBlock src)
                : base(src, Arity)
            {

            }

            public PT(TextBlock src, byte arity)
                : base(src, arity)
            {

            }

            public ref T0 Param0
            {
                [MethodImpl(Inline)]
                get => ref Var<T0>(Arity - 1);
            }

            public ref T0 this[N0 n]
            {
                [MethodImpl(Inline)]
                get => ref Param0;
            }
        }
    }
}