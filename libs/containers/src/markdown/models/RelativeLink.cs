//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public readonly record struct RelativeLink : ILink<RelativeLink,LinkTarget<FS.RelativeFilePath>>
        {
            public readonly Label Label;

            public readonly LinkTarget<FS.RelativeFilePath> Target;

            [MethodImpl(Inline)]
            public RelativeLink(Label label, LinkTarget<FS.RelativeFilePath> target)
            {
                Label = label;
                Target = target;
            }

            public string Format()
                => string.Format("{0}(./{1})", Label, Target);

            public override string ToString()
                => Format();

            Label ILabeled.Label
                => Label;

            LinkTarget<FS.RelativeFilePath> ILink<LinkTarget<FS.RelativeFilePath>>.Target
                => Target;
        }
    }
}