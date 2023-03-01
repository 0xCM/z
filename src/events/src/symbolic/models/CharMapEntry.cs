//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct CharMapEntry
    {
        public readonly Hex16 Source;

        public readonly char Target;

        [MethodImpl(Inline)]
        public CharMapEntry(Hex16 src, char dst)
        {
            Source = src;
            Target = dst;
        }

        public string Format()
            => CharMaps.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CharMapEntry<char>(CharMapEntry src)
            => new CharMapEntry<char>(src.Source, src.Target);

        [MethodImpl(Inline)]
        public static implicit operator CharMapEntry(CharMapEntry<char> src)
            => new CharMapEntry(src.Source, src.Target);
    }
}