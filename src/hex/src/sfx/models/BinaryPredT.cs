//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct BinaryPredSurrogate<T> : IFunc<T,T,bit>
    {
        readonly BinaryPredicate<T> F;

        public OpIdentity Id {get;}

        [MethodImpl(Inline)]
        public BinaryPredSurrogate(Z0.BinaryPredicate<T> f, OpIdentity id)
        {
            F = f;
            Id = id;
        }

        [MethodImpl(Inline)]
        public BinaryPredSurrogate(BinaryPredicate<T> f, string name)
        {
            F = f;
            Id = OpIdentity.Empty;
            //Id = SFxIdentity.identity<T>(name);
        }

        [MethodImpl(Inline)]
        public bit Invoke(T a, T b)
            => F(a,b);

        public BinaryPredicate<T> Subject
        {
            [MethodImpl(Inline)]
            get => F;
        }

        [MethodImpl(Inline)]
        public SurogateFunc<T,T,bit> AsFunc()
                => SFx.surrogate(this);

        [MethodImpl(Inline)]
        public string Format()
            => Id;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator SurogateFunc<T,T,bit>(BinaryPredSurrogate<T> src)
            => src.AsFunc();
    }
}
