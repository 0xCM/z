//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    partial struct SdmModels
    {
        /// <summary>
        /// EG 'Vol.1-11-8'; '14-18 Vol. 3B'
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack =1)]
        public struct VolPage
        {
            public VolPart Volume;

            public ChapterPage Page;

            [MethodImpl(Inline)]
            public VolPage(VolPart vol, ChapterPage page)
            {
                Volume = vol;
                Page = page;
            }
        }
    }
}