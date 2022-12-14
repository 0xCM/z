//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public record class CoffModule
    {
        public readonly FileUri Path;

        public readonly PeFileInfo PeInfo;

        public readonly CoffHeader CoffHeader;

        public readonly CorHeaderInfo? CorHeader;

        public readonly ReadOnlySeq<PeSectionHeader> Sections;

        [MethodImpl(Inline)]
        public CoffModule(FileUri path, PeFileInfo info, CoffHeader coff, CorHeaderInfo? cor, ReadOnlySeq<PeSectionHeader> sections)
        {
            Path = path;
            PeInfo = info;            
            CoffHeader = coff;
            CorHeader = cor;
            Sections = sections;
        }
    }
}