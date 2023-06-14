//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures a delegate that is exposed as an emitter
    /// </summary>
    public readonly struct SurrogateEmitter<T> : ISFxEmitter<T>
    {
        public OpIdentity Id {get;}

        readonly Producer<T> F;

        [MethodImpl(Inline)]
        public SurrogateEmitter(Producer<T> f, OpIdentity id)
        {
            F = f;
            Id = id;
        }

        [MethodImpl(Inline)]
        public SurrogateEmitter(Producer<T> f, string name)
        {
            F = f;
            Id = SFxIdentity.identity<T>(name);
        }

        [MethodImpl(Inline)]
        public T Invoke() => F();

        public Producer<T> Subject
        {
            [MethodImpl(Inline)]
            get => F;
        }

        [MethodImpl(Inline)]
        public SurrogateFunc<T> AsFunc()
            => SFx.surrogate(this);

        [MethodImpl(Inline)]
        public string Format()
            => Id;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator SurrogateFunc<T>(SurrogateEmitter<T> src)
            => src.AsFunc();

        [MethodImpl(Inline)]
        public static implicit operator SurrogateEmitter<T>(SurrogateFunc<T> src)
            => SFx.canonical(src);
    }
}
