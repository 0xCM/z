//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    using S = System;

    partial class Surrogates
    {
        public readonly struct Action<A0,A1,A2> : IAction<A0,A1,A2>
        {
            readonly S.Action<A0,A1,A2> F;

            public string Name {get;}

            public OpIdentity Id {get;}

            [MethodImpl(Inline)]
            internal Action(OpIdentity id, S.Action<A0,A1,A2> f)
            {
                Id = id;
                Name = id.Name;
                F = f;
            }

            [MethodImpl(Inline)]
            public void Invoke(A0 a0, A1 a1, A2 a2)
                => F(a0,a1,a2);

            public S.Action<A0,A1,A2> Subject
            {
                [MethodImpl(Inline)]
                get => F;
            }

            [MethodImpl(Inline)]
            public string Format()
                => Name;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator System.Action<A0,A1,A2>(Action<A0,A1,A2> src)
                => src.F;
        }
    }
}