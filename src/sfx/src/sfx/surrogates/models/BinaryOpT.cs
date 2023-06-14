//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct BinarySurrogate<T> : IBinaryOp<T>
    {
        readonly BinaryOp<T> F;

        public OpIdentity Id {get;}

        [MethodImpl(Inline)]
        public BinarySurrogate(BinaryOp<T> f, OpIdentity id)
        {
            F = f;
            Id = id;
        }

        [MethodImpl(Inline)]
        public BinarySurrogate(BinaryOp<T> f, string name)
        {
            F = f;
            Id = SFxIdentity.identity<T>(name);
        }

        [MethodImpl(Inline)]
        public T Invoke(T a, T b)
            => F(a, b);

        public BinaryOp<T> Subject
        {
            [MethodImpl(Inline)]
            get => F;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Id;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public SurogateFunc<T,T,T> AsFunc()
            => SFx.surrogate(this);

        [MethodImpl(Inline)]
        public static implicit operator SurogateFunc<T,T,T>(BinarySurrogate<T> src)
            => src.AsFunc();

        [MethodImpl(Inline)]
        public static implicit operator BinarySurrogate<T>(SurogateFunc<T,T,T> src)
            => SFx.canonical(src);
    }
}
