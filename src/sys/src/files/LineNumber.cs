//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct LineNumber : IDataType<LineNumber>
    {
        public const byte RenderLength = 9;

        public readonly uint Value;

        [MethodImpl(Inline)]
        public LineNumber(uint value)
        {
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Value != 0;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => string.Format("{0:D8}",Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(LineNumber src)
            => Value.CompareTo(src);

        [MethodImpl(Inline)]
        public bool Equals(LineNumber src)
            => Value == src.Value;

        [MethodImpl(Inline)]
        public static implicit operator LineNumber(uint src)
            => new LineNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator uint(LineNumber src)
            => src.Value;

        [MethodImpl(Inline)]
        public static LineNumber operator ++(LineNumber src)
            => new LineNumber(src.Value + 1);

        public static LineNumber Empty => default;
    }
}