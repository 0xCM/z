//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ExprPatterns;

    [StructLayout(LayoutKind.Sequential)]
    public class Between<T> : RuleExpr<Pair<T>>
    {
        public T Left => Content.Left;

        public T Right => Content.Right;

        public Between(T min, T max)
            : base((min,max))
        {

        }

        public override string Format()
        => string.Format(InclusiveRange, Left, Right);

        [MethodImpl(Inline)]
        public static implicit operator Between<T>((T min, T max) src)
            => new Between<T>(src.min, src.max);
    }

}