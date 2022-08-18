//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class dag<T> : IDag<T>
        where T : IExpr
    {
        public T Left {get;}

        public T Right {get;}

        [MethodImpl(Inline)]
        public dag(T left, T right)
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
        public static implicit operator dag<T>((T left, T right) src)
            => new dag<T>(src.left, src.right);

        [MethodImpl(Inline)]
        public static implicit operator dag<T>(dag<T,T> src)
            => new dag<T>(src.Left, src.Right);
    }
}