//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public record class Doc : IContented<Doc,Index<ISection>>
        {
            public readonly Index<ISection> Content;

            public Doc(ISection[] src)
            {
                Content = src;
            }

            public uint SectionCount
            {
                [MethodImpl(Inline), Op]
                get => Content.Count;
            }

            Index<ISection> IContented<Index<ISection>>.Content
                => Content;

            public ref ISection this[uint i]
            {
                [MethodImpl(Inline), Op]
                get => ref Content[i];
            }

            public ref ISection this[int i]
            {
                [MethodImpl(Inline), Op]
                get => ref Content[i];
            }

            public string Format()
            {
                var dst = text.buffer();
                for(var i=0; i<SectionCount; i++)
                {
                    ref readonly var section = ref this[i];
                    if(section != null)
                    {
                        dst.AppendLine(section.Format());
                        if(i != SectionCount - 1)
                            dst.AppendLine();
                    }
                }
                return dst.Emit();
            }

            public override string ToString()
                => Format();
        }
    }
}