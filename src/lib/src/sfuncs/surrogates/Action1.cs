//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = System;

    partial class Surrogates
    {
        public readonly struct Action<A0,A1> : IAction<A0,A1>
        {
            readonly S.Action<A0,A1> F;

            public string Name {get;}

            public OpIdentity Id {get;}

            [MethodImpl(Inline)]
            internal Action(OpIdentity id, S.Action<A0,A1> f)
            {
                Name = id.Name;
                Id = id;
                F = f;
            }

            [MethodImpl(Inline)]
            public void Invoke(A0 a0, A1 a1)
                => F(a0,a1);

            public S.Action<A0,A1> Subject
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
            public static implicit operator System.Action<A0,A1>(Action<A0,A1> src)
                => src.F;
        }
    }
}