//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly record struct CharCount
    {
        public readonly char Char;

        public readonly uint Count;

        [MethodImpl(Inline)]
        public CharCount(char c, uint count)
        {
            Char = c;
            Count = count;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (Count & 0xFFFF)| ((uint)Char) << 16;
        }

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public bool Equals(CharCount src)
            => Hash == src.Hash;

        public string Format()
            => string.Format("('{0}', {1})", Char, Count);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CharCount((char c, int i) src)
            => new CharCount(src.c, (uint)src.i);

        [MethodImpl(Inline)]
        public static implicit operator CharCount((char c, uint i) src)
            => new CharCount(src.c, src.i);
    }
}