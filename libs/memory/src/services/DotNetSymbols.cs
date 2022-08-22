//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class DotNetSymbols : AppService<DotNetSymbols>
    {
        SymbolArchives Symbols(FS.FolderPath src) 
            => SymbolArchives.create(src);

        IDumpArchive Dumps(FS.FolderPath src)  
            => new DumpArchive(src);

        public void DumpImageHex(FS.FolderPath src, FS.FolderPath dst, byte major = 6, byte minor = 0, byte revision = 203)
            => MemoryEmitter.create(Wf).DumpImages(Symbols(src).DotNetSymbolSource(major, minor, revision).Root, Dumps(dst).DotNetTargets(major,minor,revision));
    }
}