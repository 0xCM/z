//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct HashCode<S>
        where S : IEquatable<S>
    {
        public readonly Hash32 Hash;

        public readonly S Source;

        [MethodImpl(Inline)]
        public HashCode(S src, Hash32 hash)
        {
            Source = src;
            Hash = hash;
        }

        public string Format()
            => string.Format("{0}: {1}", Hash, Source);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator HashCode<S>((S input, uint output) src)
            => new HashCode<S>(src.input, src.output);
    }
}