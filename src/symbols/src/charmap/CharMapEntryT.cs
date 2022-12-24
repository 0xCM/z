//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct CharMapEntry<T> : IDataType<CharMapEntry<T>>
        where T : unmanaged, IComparable<T>, IEquatable<T>
    {
        public readonly Hex16 Source;

        public readonly T Target;

        [MethodImpl(Inline)]
        public CharMapEntry(Hex16 src, T dst)
        {
            Source = src;
            Target = dst;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Widths.u64(this) == 0;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => sys.nhash(Source, Target);
        }

        [MethodImpl(Inline)]
        public bool Equals(CharMapEntry<T> src)
            => Source == src.Source && Target.Equals(src.Target);

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(CharMapEntry<T> src)
        {
            var result = Source.CompareTo(src.Source);
            if(result == 0)
                result = Target.CompareTo(src.Target);
            return result;
        }
    }
}