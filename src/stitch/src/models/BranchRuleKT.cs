//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using XF = ExprPatterns;

    public class BranchRule<K,T>
        where K : unmanaged
        where T : IExprDeprecated
    {
        readonly Index<Literal<K>> _Choices;

        readonly Index<T> _Targets;

        public Label Name {get;}

        public BranchRule(Label name, Literal<K>[] src, T[] terms)
        {
            Name = name;
            _Choices = src;
            _Targets = terms;
            Require.equal(src.Length, terms.Length);
        }

        public ReadOnlySpan<Literal<K>> Choices
        {
            [MethodImpl(Inline)]
            get => _Choices.Edit;
        }

        public ReadOnlySpan<T> Targets
        {
            [MethodImpl(Inline)]
            get => _Targets.View;
        }

        public string Format()
        {
            var dst = text.buffer();
            var margin = 0u;
            var choices = Choices;
            var terms = Targets;
            var count = choices.Length;
            dst.IndentLineFormat(margin, "{0}({1}) {", "branch", Name);
            margin += 2;
            for(var i=0; i<count; i++)
                dst.IndentLineFormat(margin, XF.BranchCase, skip(choices,i).Format(), skip(terms,i).Format());
            margin -=2;
            dst.IndentLine(margin, "}");

            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}