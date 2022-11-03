//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class StringMatcher
    {
        /// <summary>
        /// Within the context of a string, pairs a character with its relative index
        /// </summary>
        [StructLayout(StructLayout, Pack=1)]
        public readonly record struct CharIndex
        {
            public readonly ushort Index;

            public readonly char Char;

            [MethodImpl(Inline)]
            public CharIndex(char c, ushort i)
            {
                Char = c;
                Index = i;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => (uint)Index | ((uint)Char) << 16;
            }

            public override int GetHashCode()
                => (int)Hash;

            [MethodImpl(Inline)]
            public bool Equals(CharIndex src)
                => Hash == src.Hash;

            public string Format()
                => string.Format("('{0}', {1})", Char, Index);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator CharIndex((char c, int i) src)
                => new CharIndex(src.c, (ushort)src.i);

            [MethodImpl(Inline)]
            public static implicit operator CharIndex((char c, uint i) src)
                => new CharIndex(src.c, (ushort)src.i);

            [MethodImpl(Inline)]
            public static implicit operator CharIndex((char c, ushort i) src)
                => new CharIndex(src.c, src.i);
        }
    }
}