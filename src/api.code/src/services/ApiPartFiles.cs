//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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

        public IEnumerable<FilePath> Asm()
            => Location.AsmExtracts(Part);

        public IEnumerable<FilePath> Msil()
            => Location.MsilExtracts(Part);

        public IEnumerable<FilePath> Hex()
            => Location.HexExtracts(Part);
    }
}