//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class DotNetSymbols : AppService<DotNetSymbols>
    {
        SymbolArchives Symbols(FolderPath src) 
            => SymbolArchives.create(src);

        IDumpArchive Dumps(FolderPath src)  
            => new DumpArchive(src);

        public void DumpImageHex(FolderPath src, FolderPath dst, byte major = 6, byte minor = 0, byte revision = 203)
            => HexEmitter.DumpImages(Channel, 
                Symbols(src).DotNetSymbolSource(major, minor, revision).Root, 
                Dumps(dst).DotNetTargets(major,minor,revision));
    }
}