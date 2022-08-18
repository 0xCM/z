//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Artifact<K,T> : IArtifact<K,T>
        where K : unmanaged
        where T : unmanaged
    {
        public readonly K Kind;

        public readonly T Location;

        [MethodImpl(Inline)]
        public Artifact(K kind, T locator)
        {
            Kind = kind;
            Location = locator;
        }

        T IArtifact<K,T>.Location
            => Location;

        K IArtifact<K>.Kind
            => Kind;

        public string Format()
            => Location.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Artifact<K,T>((K kind, T locator) src)
            => new Artifact<K,T>(src.kind, src.locator);
    }
}