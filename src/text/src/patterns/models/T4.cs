//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 4020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TextPatterns
    {
        public class PT<T0,T1,T2,T3,T4> : PT<T0,T1,T2,T3>
        {
            const byte Arity = 5;

            public PT(TextBlock src)
                : base(src, Arity)
            {

            }

            public PT(TextBlock src, byte arity)
                : base(src, arity)
            {

            }

            public ref T4 Param4
            {
                [MethodImpl(Inline)]
                get => ref Var<T4>(Arity - 1);
            }

            public ref T4 this[N4 n]
            {
                [MethodImpl(Inline)]
                get => ref Param4;
            }
        }
    }
}