//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct TocTitle
        {
            public CharBlock128 Content;

            public ChapterPage Page;

            [MethodImpl(Inline)]
            public TocTitle(in CharBlock128 content, ChapterPage page)
            {
                Content = content;
                Page = page;
            }

            public string Format()
                => format(this);

            public override string ToString()
                => Format();

            public static TocTitle Empty => default;
        }
    }
}