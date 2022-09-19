//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class dag : IDag<IExpr>
    {
        public static string format(IDag src, DagFormatStyle style)
        {
            var pattern = style == DagFormatStyle.Graph ? "{0} -> {1}" : "{0}, {1}";
            if(src.Left.IsNonEmpty && src.Right.IsNonEmpty)
                return string.Format(pattern, src.Left.Format(), src.Right.Format());
            else if(src.Left.IsEmpty && src.Right.IsEmpty)
                return EmptyString;
            else if(src.Left.IsNonEmpty)
                return src.Left.Format();
            else
                return src.Right.Format();
        }

        public IExpr Left {get;}

        public IExpr Right {get;}

        [MethodImpl(Inline)]
        public dag(IExpr left, IExpr right)
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
            => format(this, style);

        public override string ToString()
            => Format();
    }
}