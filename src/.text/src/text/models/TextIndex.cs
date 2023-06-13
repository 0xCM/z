//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TextIndex
    {
        public int Value {get;}

        [MethodImpl(Inline)]
        public TextIndex(int value)
        {
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value < 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Value >= 0;
        }

        [MethodImpl(Inline)]
        public static implicit operator TextIndex(int i)
            => new TextIndex(i);

        [MethodImpl(Inline)]
        public static implicit operator TextIndex(uint i)
            => new TextIndex((int)i);

        [MethodImpl(Inline)]
        public static implicit operator int(TextIndex i)
            => i.Value;

        [MethodImpl(Inline)]
        public static TextIndex operator +(TextIndex a, TextIndex b)
            => (a.IsEmpty || b.IsEmpty) ? Empty : new TextIndex(a.Value + b.Value);

        public static TextIndex Empty
        {
            [MethodImpl(Inline)]
            get => new TextIndex(-1);
        }
    }
}