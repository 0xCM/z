//-----------------------------------------------------------------------------
// Copyright   :  (c) LLVM Project
// License     :  Apache-2.0 WITH LLVM-exceptions
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    /// <summary>
    /// The integer type is a very simple type that simply specifies an arbitrary bit width for the integer type desired.
    /// Any bit width from 1 bit to 2^23 can be specified
    /// </summary>
    /// <remarks>
    /// From https://llvm.org/docs/LangRef.html#integer-type
    /// </remarks>
    public readonly struct IntType : IComparable<IntType>
    {
        [MethodImpl(Inline)]
        public static IntType define(uint width)
            => new IntType(width);

        public static IntType parse(string src)
        {
            var input = text.trim(src);
            if(empty(input))
                return Empty;

            var chars = span(input);
            var i = first(chars);
            if(i != Chars.i)
                return Empty;

            if(uint.TryParse(slice(chars,1), out var width))
                return new IntType(width);
            else
                return Empty;
        }

        readonly uint BitWidth;

        [MethodImpl(Inline)]
        public IntType(uint width)
        {
            BitWidth = math.clamp(width, MaxWidth);
        }

        public Identifier Name
        {
            [MethodImpl(Inline)]
            get => Format();
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => BitWidth == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => BitWidth != 0;
        }

        [MethodImpl(Inline)]
        public bool Equals(IntType src)
            => BitWidth.Equals(src.BitWidth);

        [MethodImpl(Inline)]
        public int CompareTo(IntType src)
            => BitWidth.CompareTo(src.BitWidth);

        public override int GetHashCode()
            => (int)BitWidth;

        public string Format()
            => string.Format("i{0}", BitWidth);

        public override string ToString()
            => Format();

        public override bool Equals(object src)
            => src is IntType i && Equals(i);

        [MethodImpl(Inline)]
        public static implicit operator IntType(uint width)
            => new IntType(width);

        [MethodImpl(Inline)]
        public static implicit operator string(IntType src)
            => src.Format();

        [MethodImpl(Inline)]
        public static implicit operator IntType(string src)
            => parse(src);

        public const uint MaxWidth = Pow2.T23;

        public static IntType Empty => default;
    }
}