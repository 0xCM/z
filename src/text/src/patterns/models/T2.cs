//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TextPatterns
    {
        public class PT<T0,T1,T2> : PT<T0,T1>
        {
            const byte Arity = 3;

            public PT(TextBlock src)
                : base(src, Arity)
            {

            }

            public PT(TextBlock src, byte arity)
                : base(src, arity)
            {

            }

            public ref T2 Param2
            {
                [MethodImpl(Inline)]
                get => ref Var<T2>(Arity - 1);
            }

            public ref T2 this[N2 n]
            {
                [MethodImpl(Inline)]
                get => ref Param2;
            }
        }
    }
}