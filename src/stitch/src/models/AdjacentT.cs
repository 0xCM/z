//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents the consecutive occurrence of two values within a sequence
    /// </summary>
    public class Adjacent<T> : RuleExpr<Pair<T>>
    {
        [MethodImpl(Inline)]
        public Adjacent(T a, T b)
            : base((a,b))
        {

        }

        public override string Format()
            => string.Format(RP.Adjacent2,Content.Left, Content.Right);

        [MethodImpl(Inline)]
        public static implicit operator Adjacent<T>((T left, T right) src)
            => new Adjacent<T>(src.left, src.right);

        [MethodImpl(Inline)]
        public static implicit operator Adjacent<T>(Pair<T> src)
            => new Adjacent<T>(src.Left, src.Right);
    }
}