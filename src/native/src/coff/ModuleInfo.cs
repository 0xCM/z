//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public record class FileModuleInfo
    {
        public readonly PeFileInfo Info;

        public readonly CoffHeader Coff;

        public readonly CorHeader Core;

        public readonly ReadOnlySeq<PeSectionHeader> Sections;

        [MethodImpl(Inline)]
        public FileModuleInfo(PeFileInfo info, CoffHeader coff, CorHeader cor, ReadOnlySeq<PeSectionHeader> sections)
        {
            Info = info;            
            Coff = coff;
            Core = cor;
            Sections = sections;
        }
    }
}