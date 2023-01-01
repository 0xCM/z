//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TextPatterns
    {
        public class PT<T0,T1,T2,T3> : PT<T0,T1,T2>
        {
            const byte Arity = 4;

            public PT(TextBlock src)
                : base(src, Arity)
            {

            }

            public PT(TextBlock src, byte arity)
                : base(src, arity)
            {

            }

            public ref T3 Param3
            {
                [MethodImpl(Inline)]
                get => ref Var<T3>(Arity - 1);
            }

            public ref T3 this[N3 n]
            {
                [MethodImpl(Inline)]
                get => ref Param3;
            }
        }
    }
}