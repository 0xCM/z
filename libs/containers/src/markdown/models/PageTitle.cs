//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public readonly record struct PageTitle : ISection<PageTitle,string>
        {
            public readonly uint Index;

            public readonly SectionHeader Header;

            public readonly string Content;

            [MethodImpl(Inline)]
            public PageTitle(Name src, string content)
            {
                Index = 0;
                Header = new (1,src);
                Content = content;
            }

            string IContented<string>.Content
                => Content;

            ISectionHeader ISection.Header
                => Header;

            uint ISection.Index
                => Index;
            public string Format()
                => string.Format("{0}", Header);

            public override string ToString()
                => Format();

        }
    }
}