//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TextPatterns
    {
        public class PT<T0,T1> : PT<T0>
        {
            const byte Arity = 2;

            public PT(TextBlock src)
                : base(src, Arity)
            {

            }

            public PT(TextBlock src, byte arity)
                : base(src, arity)
            {

            }

            public ref T1 Param1
            {
                [MethodImpl(Inline)]
                get => ref Var<T1>(Arity - 1);
            }

            public ref T1 this[N1 n]
            {
                [MethodImpl(Inline)]
                get => ref Param1;
            }
        }
    }
}