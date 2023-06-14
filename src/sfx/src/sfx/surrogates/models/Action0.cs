//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct SurrogateAction<A0> : IAction<A0>
    {
        readonly Action<A0> F;

        public string Name {get;}

        public OpIdentity Id {get;}

        [MethodImpl(Inline)]
        public SurrogateAction(OpIdentity id, Action<A0> f)
        {
            Name = id.Name;
            Id = id;
            F = f;
        }

        [MethodImpl(Inline)]
        public void Invoke(A0 a)
            => F(a);

        public Action<A0> Subject
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
        public static implicit operator System.Action<A0>(SurrogateAction<A0> src)
            => src.F;
    }
}