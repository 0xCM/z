//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CollectedHost
    {
        public readonly ApiHostMembers Resolved;

        public readonly ReadOnlySeq<ApiEncoded> Blocks;

        public CollectedHost(ApiHostMembers resolved, ReadOnlySeq<ApiEncoded> blocks)
        {
            Resolved = resolved;
            Blocks = blocks;
        }

        public _ApiHostUri Host
        {
            [MethodImpl(Inline)]
            get => Resolved.Host;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Blocks.Count;            
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Count == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Count != 0;
        }

        public ref readonly ApiEncoded this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Blocks[i];
        }

        public ref readonly ApiEncoded this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Blocks[i];
        }
    }
}