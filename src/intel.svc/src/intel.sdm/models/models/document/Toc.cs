//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        public readonly struct Toc
        {
            readonly Index<TocEntry> Data;

            [MethodImpl(Inline)]
            public Toc(TocEntry[] sections)
            {
                Data = sections;
            }

            public Span<TocEntry> Entries
            {
                [MethodImpl(Inline)]
                get => Data.Edit;
            }

            public uint EntryCount
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }
        }
    }
}