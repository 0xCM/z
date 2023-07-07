//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public readonly record struct SectionLink : ILink<SectionLink, LinkTarget<Name>>
        {
            public readonly Label Label;

            public readonly LinkTarget<Name> Target;

            [MethodImpl(Inline)]
            public SectionLink(Label label, LinkTarget<Name> dst)
            {
                Label = label;
                Target = dst;
            }

            public string Format()
                => string.Format("{0}(#{1})", Label, Target);

            public override string ToString()
                => Format();

            Label ILabeled.Label
                => Label;

            LinkTarget<Name> ILink<LinkTarget<Name>>.Target
                => Target;
        }
    }
}