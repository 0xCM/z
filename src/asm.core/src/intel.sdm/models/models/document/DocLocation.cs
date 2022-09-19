//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        /// <summary>
        /// EG:Vol. 2C 5-557
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack =1)]
        public struct DocLocation
        {
            public VolPart Volume;

            public ChapterNumber Chapter;

            public Page Page;

            [MethodImpl(Inline)]
            public DocLocation(VolPart v, ChapterNumber c, Page p)
            {
                Volume = v;
                Chapter = c;
                Page = p;
            }
        }
    }
}