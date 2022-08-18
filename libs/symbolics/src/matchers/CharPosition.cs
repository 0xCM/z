//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class StringMatcher
    {
        /// <summary>
        /// Within the context of a string, pairs a character with its relative Position
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly struct CharPosition
        {
            public readonly uint Target;

            public readonly ushort Position;

            public readonly char Char;

            [MethodImpl(Inline)]
            public CharPosition(uint target, char c, ushort i)
            {
                Target = target;
                Char = c;
                Position = i;
            }

            public uint Hash
            {
                [MethodImpl(Inline)]
                get => (Target & 0xFFFF) | ((((uint)Char) &0xFF) << 16) |((((uint)(Position)) & 0xFF) << 24);
            }

            public override int GetHashCode()
                => (int)Hash;

            [MethodImpl(Inline)]
            public bool Equals(CharPosition src)
                => Target == src.Target && Char == src.Char && Position == src.Position;

            public override bool Equals(object src)
                => src is CharPosition x && Equals(x);

            public string Format()
                => string.Format("({0}, '{1}', {2})", Char, Position);

            public override string ToString()
                => Format();
        }
    }
}