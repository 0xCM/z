//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Surrogates
    {
        public readonly struct UnaryPredicate<T> : IFunc<T,bit>
        {
            public _OpIdentity Id {get;}

            readonly Z0.UnaryPredicate<T> F;

            [MethodImpl(Inline)]
            internal UnaryPredicate(Z0.UnaryPredicate<T> f, _OpIdentity id)
            {
                F = f;
                Id = id;
            }

            [MethodImpl(Inline)]
            public bit Invoke(T a)
                => F(a);

            public Z0.UnaryPredicate<T> Subject
            {
                [MethodImpl(Inline)]
                get => F;
            }

            [MethodImpl(Inline)]
            public Func<T,bit> AsFunc()
                 => SFx.surrogate(this);

            [MethodImpl(Inline)]
            public static implicit operator Func<T,bit>(UnaryPredicate<T> src)
                => src.AsFunc();
        }
    }
}