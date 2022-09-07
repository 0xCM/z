//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Surrogates
    {
        /// <summary>
        /// Captures a delegate that is exposed as an emitter
        /// </summary>
        public readonly struct Emitter<T> : ISFxEmitter<T>
        {
            public _OpIdentity Id {get;}

            readonly Z0.Producer<T> F;

            [MethodImpl(Inline)]
            public Emitter(Z0.Producer<T> f, _OpIdentity id)
            {
                F = f;
                Id = id;
            }

            [MethodImpl(Inline)]
            public Emitter(Z0.Producer<T> f, string name)
            {
                F = f;
                Id = SFxIdentity.identity<T>(name);
            }

            [MethodImpl(Inline)]
            public T Invoke() => F();

            public Z0.Producer<T> Subject
            {
                [MethodImpl(Inline)]
                get => F;
            }

            [MethodImpl(Inline)]
            public Func<T> AsFunc()
                => SFx.surrogate(this);

            [MethodImpl(Inline)]
            public string Format()
                => Id;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Func<T>(Emitter<T> src)
                => src.AsFunc();

            [MethodImpl(Inline)]
            public static implicit operator Emitter<T>(Func<T> src)
                => SFx.canonical(src);
        }
    }
}