//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public readonly record struct AbsoluteLink : ILink<AbsoluteLink,LinkTarget<FS.FileUri>>
        {
            public readonly Label Label;

            public readonly LinkTarget<FS.FileUri> Target;

            public readonly bool Bare;

            [MethodImpl(Inline)]
            public AbsoluteLink(Label label, LinkTarget<FS.FileUri> target, bool bare)
            {
                Label = label;
                Target = target;
                Bare = bare;
            }

            Label ILabeled.Label
                => Label;

            LinkTarget<FS.FileUri> ILink<LinkTarget<FS.FileUri>>.Target
                => Target;

            public string Format()
                => Bare ? string.Format("<{0}>", Target) : string.Format("{0}({1})", Label, Target);

            public override string ToString()
                => Format();
        }
    }
}