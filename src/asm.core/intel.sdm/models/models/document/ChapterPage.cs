//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        /// <summary>
        /// Represents content of the form '{Chapter}-{Page}'
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct ChapterPage
        {
            public const string RenderPattern = "{0}-{1}";

            public const string Descriptor = "{ChapterNumber}-{PageNumber}";

            public ChapterNumber Chapter;

            public Page Page;

            [MethodImpl(Inline)]
            public ChapterPage(ChapterNumber chapter, Page page)
            {
                Chapter = chapter;
                Page = page;
            }

            public string Format()
                => string.Format(RenderPattern, Chapter, Page);

            public override string ToString()
                => Format();

            public static implicit operator string(ChapterPage src)
                => src.Format();

            public static ChapterPage Empty => new ChapterPage(0,0);
        }
    }
}