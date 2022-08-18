//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        [ApiComplete("intel.sdm.pagefooters")]
        public readonly struct PageFooters
        {
            const string Null = "{null}";

            static PageFooter Base = footer("{Title}", Null, VolPartNumber.Descriptor, ChapterPage.Descriptor);

            /// <summary>
            /// Returns a descripter of the form {Title} {null} Vol. {Major}.{Minor} {ChapterNumber}.{PageNumber}
            /// </summary>
            public static ref readonly PageFooter TitleVolPage() => ref Base;

            /// <summary>
            /// Returns a descripter of the form <paramref parameter='{title}'/> {null} Vol. {Major}.{Minor} {ChapterNumber}.{PageNumber}
            /// </summary>
            public static PageFooter TitleVolPage(string title)
                => footer(title, Null,VolPartNumber.Descriptor, ChapterPage.Descriptor);

            /// <summary>
            /// Returns a descripter of the form <paramref parameter='{title}'/> {null} <paramref parameter='{vol}'/> {ChapterNumber}.{PageNumber}
            /// </summary>
            public static PageFooter TitleVolPage(string title, VolPartNumber vol)
                => footer(title, Null, vol.Format(), ChapterPage.Descriptor);

            /// <summary>
            /// Returns a descripter of the form <paramref parameter='{title}'/> {null} <paramref parameter='{vol}'/> <paramref parameter='{page}'/>
            /// </summary>
            public static PageFooter TitleVolPage(string title, VolPartNumber vol, ChapterPage page)
                => footer(title, Null, vol.Format(), page.Format());
        }
    }
}