//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class LogicOps
    {
        public readonly struct Except : IExpr
        {
            HashSet<IExpr> _Terms {get;}

            public bool IsEmpty
                => _Terms.Count == 0;

            [MethodImpl(Inline)]
            public Except(IExpr[] choices)
                => _Terms = sys.hashset(choices);

            public IReadOnlyCollection<IExpr> Terms
            {
                [MethodImpl(Inline)]
                get => _Terms;
            }

            public Label Name => "exclude";

            public string Format()
                => OpFormatters.format(this);

            public override string ToString()
                => Format();
        }
    }
}