//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = NativeFlows;

    public readonly struct NativeFlow<K,S,T> : INativeFlow<K,S,T>
        where K : unmanaged
        where S : INativeChannel
        where T : INativeChannel
    {
        public K Kind {get;}

        public S Source {get;}

        public T Target {get;}

        [MethodImpl(Inline)]
        public NativeFlow(K kind, S src, T dst)
        {
            Kind = kind;
            Source = src;
            Target = dst;
        }

        public string Format()
            => api.format(this);

        public string Syntax
            => api.syntax(this);


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator NativeFlow<K,S,T>((K actor, S src, T dst) x)
            => new NativeFlow<K,S,T>(x.actor, x.src, x.dst);
    }
}