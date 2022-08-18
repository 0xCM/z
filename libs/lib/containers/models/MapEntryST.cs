//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct MapEntry<S,T>
    {
        public uint Index;

        public S Source;

        public T Target;

        [MethodImpl(Inline)]
        public MapEntry(uint index, S src, T dst)
        {
            Index = index;
            Source = src;
            Target = dst;
        }
    }
}