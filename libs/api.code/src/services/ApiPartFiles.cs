//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiFiles
    {
        public static ApiPartFiles part(IApiPack src, PartId part)
            => ApiPartFiles.create(src,part);
            
        public static FS.FileName filename(ApiHostUri host, FS.FileExt ext)
            => FS.file(host.Id.Format(), ext);

        public static FS.FileName filename(ApiHostUri host, FS.FileExt a, FS.FileExt b)
            => FS.file(text.concat(host.Id.Format(), a), b);

        [MethodImpl(Inline), Op]
        public static FS.FolderName folder(ApiHostUri host)
            => FS.folder(host.HostName);

        [MethodImpl(Inline), Op]
        public static FS.FolderName folder(PartId part)
            => FS.folder(part.Format());
    }    

    public class ApiPartFiles
    {
        public static ApiPartFiles create(IApiPack src, PartId part)
            => new ApiPartFiles(part, src);

        public readonly PartId Part;

        readonly IApiPack Location;

        public ApiPartFiles(PartId part, IApiPack dir)
        {
            Part = part;
            Location = dir;
        }

        public FS.Files Asm()
            => Location.AsmExtracts(Part);

        public FS.Files Msil()
            => Location.MsilExtracts(Part);

        public FS.Files Hex()
            => Location.HexExtracts(Part);
    }
}