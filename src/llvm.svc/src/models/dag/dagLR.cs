//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class dag<L,R> : IDag<L,R>
        where L : IExpr
        where R : IExpr
    {
        public L Left {get;}

        public R Right {get;}

        [MethodImpl(Inline)]
        public dag(L left, R right)
        {
            Left = left;
            Right = right;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Left.IsEmpty && Right.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Left.IsNonEmpty && Right.IsNonEmpty;
        }

        public string Format()
            => Format(DagFormatStyle.List);

        public string Format(DagFormatStyle style)
            => dag.format(this, style);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator dag<L,R>((L left, R right) src)
            => new dag<L,R>(src.left, src.right);
    }
}