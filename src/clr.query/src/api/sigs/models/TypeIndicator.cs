//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Partitions types into manageable pieces in various ways, hopefully sensible, with 16 bits
    /// </summary>
    public readonly struct TypeIndicator : IExpr
    {
        readonly char Value;

        [MethodImpl(Inline)]
        internal TypeIndicator(char c)
            => Value = c;

        [MethodImpl(Inline)]
        public static TypeIndicator Define(char c)
            => new TypeIndicator(c);

        /// <summary>
        /// The nonindicating indicator
        /// </summary>
        public static TypeIndicator Empty
            => new TypeIndicator(Chars.Null);

        /// <summary>
        /// Identifies the signed numeric partition
        /// </summary>
        public static TypeIndicator Signed
            => IDI.Signed;

        /// <summary>
        /// Identifies the unsigned numeric partition
        /// </summary>
        public static TypeIndicator Unsigned
            => IDI.Unsigned;

        /// <summary>
        /// Identifies the floating-point numeric partition
        /// </summary>
        public static TypeIndicator Float
            => IDI.Float;

        /// <summary>
        /// Identifies the vectorized type partition
        /// </summary>
        public static TypeIndicator Vector
            => IDI.Vector;

        /// <summary>
        /// Specifies whether the indicator is non-indicating
        /// </summary>
        public bool IsEmpty
            => Value == Chars.Null;

        public string Format()
            => IsEmpty ? EmptyString : Value.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator string(TypeIndicator src)
            => src.Format();

        [MethodImpl(Inline)]
        public static implicit operator TypeIndicator(char src)
            => new TypeIndicator(src);
    }
}