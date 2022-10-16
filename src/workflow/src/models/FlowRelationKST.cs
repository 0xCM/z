//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout,Pack=1)]
    public readonly record struct FlowRelation<K,S,T> : IRelation<K,S,T>, IHashed
        where K : unmanaged
        where S : unmanaged
        where T : unmanaged
    {
        [Render(32)]
        public readonly FlowId Id;

        [Render(32)]
        public readonly K Kind;

        [Render(32)]
        public readonly S Source;

        [Render(32)]
        public readonly T Target;

        [MethodImpl(Inline)]
        public FlowRelation(FlowId id, K kind, S src, T dst)
        {
            Id = id;
            Kind = kind;
            Source = src;
            Target = dst;
        }

        K IRelation<K,S,T>.Kind
            => Kind;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Id.Hash;
        }

        S IRelation<S, T>.Source
            => Source;

        T IRelation<S, T>.Target
            => Target;

        public override int GetHashCode()
            => Hash;

        public string Format()
            => $"{Kind}:{Source} -> {Target}";


        public override string ToString()
            => Format();

    }
}