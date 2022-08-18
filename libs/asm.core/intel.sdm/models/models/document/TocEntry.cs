//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        [StructLayout(LayoutKind.Sequential, Pack =1), Record(TableId)]
        public struct TocEntry
        {
            const string TableId ="intel.sdm.toc.entries";

            [Render(10)]
            public VolNumber Volume;

            [Render(10)]
            public SectionNumber Section;

            [Render(10)]
            public ChapterPage Page;

            [Render(1)]
            public CharBlock128 Title;

            [MethodImpl(Inline)]
            public TocEntry(VolNumber vol, in SectionNumber sn, in TocTitle toc)
            {
                Volume = vol;
                Section = sn;
                Page = toc.Page;
                Title = toc.Content;
            }

            public string Format()
                => format(this);

            public override string ToString()
                => Format();

            public static TocEntry Empty => default;
        }
    }
}