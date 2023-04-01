//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public record class CoffModuleInfo
    {
        public readonly FilePath Path;

        public readonly PeFileInfo PeInfo;

        public readonly CoffHeader CoffHeader;

        public readonly PeCorHeader? CorHeader;

        public readonly ReadOnlySeq<SectionHeaderRow> Sections;

        [MethodImpl(Inline)]
        public CoffModuleInfo(FilePath path, PeFileInfo info, CoffHeader coff, PeCorHeader? cor, ReadOnlySeq<SectionHeaderRow> sections)
        {
            Path = path;
            PeInfo = info;            
            CoffHeader = coff;
            CorHeader = cor;
            Sections = sections;
        }
    }
}