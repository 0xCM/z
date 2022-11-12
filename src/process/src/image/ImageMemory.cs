//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost,Free]
    public partial class ImageMemory
    {
        public static FileUri uri(ProcessAdapter src, IDbArchive dst)
            => new FileUri($"{dst.Root.Format(PathSeparator.FS)}/{src.ProcessName}.{src.Id}.{sys.timestamp()}.modules.{FileKind.Csv.Format()}");

        public static PEReader pe(Stream src)
            => new PEReader(src);

        [MethodImpl(Inline), Op]
        public static ref ProcessSegment segment(in ProcessMemoryRegion src, ref ProcessSegment dst)
        {
            dst.Seq = src.Seq;
            dst.Selector = src.BaseAddress.Quadrant(n2);
            dst.Base = src.BaseAddress.Lo();
            dst.Size = src.Size;
            dst.PageCount = src.Size/PageSize;
            dst.Range = (src.BaseAddress, src.MaxAddress);
            dst.Type = src.Type;
            dst.Protection = src.Protection;
            dst.Label = src.ImageName;
            return ref dst;
        }
    }
}