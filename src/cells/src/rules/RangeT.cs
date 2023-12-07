//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using XF = ExprPatterns;

partial class SyntaxRules
{
    /// <summary>
    /// Constrains an element or sequence to live within a specified range
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class Range<T> : IRuleExpr
        where T : IComparable<T>, IEquatable<T>
    {
        /// <summary>
        /// The min value in the range
        /// </summary>
        public readonly T Min;

        /// <summary>
        /// The max value in the range
        /// </summary>
        public readonly T Max;

        [MethodImpl(Inline)]
        public Range(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public string Format()
            => string.Format(XF.InclusiveRange, Min, Max);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Range<T>((T min, T max) src)
            => new Range<T>(src.min, src.max);
    }

}
