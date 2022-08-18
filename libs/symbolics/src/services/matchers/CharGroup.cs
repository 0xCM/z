//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class StringMatcher
    {
        /// <summary>
        /// Defines an equivalence class over a set of strings predicated on a string length and an index within the string
        /// </summary>
        [StructLayout(StructLayout, Pack=1)]
        public readonly struct CharGroup : IEquatable<CharGroup>, INullity
        {
            public readonly ushort Length;

            public readonly ushort Index;

            [MethodImpl(Inline)]
            public CharGroup(ushort length, ushort index)
            {
                Length = length;
                Index = index;
            }

            public uint Id
            {
                [MethodImpl(Inline)]
                get => (uint)Index | ((uint)Length << 16);
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Id == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Id != 0;
            }

            public string Format()
                => Id.FormatHex();

            [MethodImpl(Inline)]
            public bool Equals(CharGroup src)
                => Id == src.Id;

            public override int GetHashCode()
                => (int)Id;

            public override bool Equals(object src)
                => src is CharGroup g && Equals(g);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator CharGroup((ushort length, ushort index) src)
                => new CharGroup(src.length, src.index);

            [MethodImpl(Inline)]
            public static bool operator ==(CharGroup a, CharGroup b)
                => a.Id == b.Id;

            [MethodImpl(Inline)]
            public static bool operator !=(CharGroup a, CharGroup b)
                => a.Id != b.Id;

            public static CharGroup Empty => default;
        }
    }
}