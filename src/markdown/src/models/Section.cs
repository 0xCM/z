//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public readonly record struct Section : ISection<Section,SectionHeader,string>
        {
            public readonly uint Index;

            public readonly SectionHeader Header;

            public readonly string Content;

            [MethodImpl(Inline)]
            public Section(uint index, SectionHeader header, string content)
            {
                Index = index;
                Header = header;
                Content = content;
            }

            public @string Name
            {
                [MethodImpl(Inline)]
                get => Header.Name;
            }        
            public string Format()
                => text.concat(Header, Chars.Eol, Chars.Eol, Content);

            string IContented<string>.Content
                => Content;

            SectionHeader ISection<Section, SectionHeader, string>.Header
                => Header;

            uint ISection.Index
                => Index;

            public override string ToString()
                => Format();
        }
    }
}