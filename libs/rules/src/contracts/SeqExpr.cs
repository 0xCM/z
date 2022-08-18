//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Rules;

    public class SeqExpr : RuleExpr<Index<IExpr>>, ISeqExpr<IExpr>
    {
        public SeqExpr(params IExpr[] terms)
            : base(terms)
        {

        }

        public uint N
        {
            [MethodImpl(Inline)]
            get => Content.Count;
        }

        public ReadOnlySpan<IExpr> Terms
            => Content;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsNonEmpty;
        }

        public override string Format()
            => text.embrace(Content.Delimit().Format());

        public static implicit operator SeqExpr(IExpr[] src)
            => new SeqExpr(src);
    }

}