//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct ResourceSeg
    {
        public readonly string Name;

        public readonly MemorySeg Segment;

        [MethodImpl(Inline)]
        public ResourceSeg(string name, in MemorySeg segment)
        {
            Name = name;
            Segment = segment;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Segment.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(ResourceSeg src)
            => Name == src.Name && Segment.Equals(src.Segment);

        [MethodImpl(Inline)]
        public string Format()
            => string.Format("{0}[{1}:{2}]", Name, Segment.BaseAddress, Segment.Length);

        public override string ToString()
            => Format();
    }
}