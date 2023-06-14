//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct UnarySurrogate<T> : IUnaryOp<T>
    {
        public OpIdentity Id {get;}

        readonly UnaryOp<T> F;

        [MethodImpl(Inline)]
        public UnarySurrogate(UnaryOp<T> f, OpIdentity id)
        {
            F = f;
            Id = id;
        }

        [MethodImpl(Inline)]
        public UnarySurrogate(Z0.UnaryOp<T> f, string name)
        {
            F = f;
            Id = SFxIdentity.identity<T>(name);
        }

        [MethodImpl(Inline)]
        public T Invoke(T a) => F(a);

        public Z0.UnaryOp<T> Subject
        {
            [MethodImpl(Inline)]
            get => F;
        }

        [MethodImpl(Inline)]
        public SurrogateFunc<T,T> AsFunc()
            => SFx.surrogate(this);

        [MethodImpl(Inline)]
        public static implicit operator SurrogateFunc<T,T>(UnarySurrogate<T> src)
            => src.AsFunc();
    }
}
