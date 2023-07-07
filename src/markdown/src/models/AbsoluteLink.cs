//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public readonly record struct AbsoluteLink : ILink<AbsoluteLink,LinkTarget<_FileUri>>
        {
            public readonly Label Label;

            public readonly LinkTarget<_FileUri> Target;

            public readonly bool Bare;

            [MethodImpl(Inline)]
            public AbsoluteLink(Label label, LinkTarget<_FileUri> target, bool bare)
            {
                Label = label;
                Target = target;
                Bare = bare;
            }

            Label ILabeled.Label
                => Label;

            LinkTarget<_FileUri> ILink<LinkTarget<_FileUri>>.Target
                => Target;

            public string Format()
                => Bare ? string.Format("<{0}>", Target) : string.Format("{0}({1})", Label, Target);

            public override string ToString()
                => Format();
        }
    }
}