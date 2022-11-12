//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ImageMemory
    {
        static _FileUri Nul => FolderPath.Empty +  FS.file("dev",FS.ext("null"));

        public static ReadOnlySeq<ProcessMemoryRegion> pages(ReadOnlySpan<MemoryRangeInfo> src)
        {
            var count = src.Length;
            var buffer = sys.alloc<ProcessMemoryRegion>(count);
            ref var dst = ref first(buffer);
            for(var i=0u; i<count; i++)
                fill(skip(src,i), i, out seek(dst,i));
            return buffer.Resequence();
        }

        static ProcessMemoryRegion fill(in MemoryRangeInfo src, uint index, out ProcessMemoryRegion dst)
        {
            var owner = src.Owner;
            dst.Seq = index;
            if(text.nonempty(owner))
            {
                dst.ImagePath = FS.path(owner);
                if(owner.Contains("."))
                    dst.ImageName = Path.GetFileName(owner);
                else
                    dst.ImageName = owner.Substring(0, min(owner.Length, 12));
            }
            else
            {
                dst.ImageName = "unknown";
                dst.ImagePath = Nul;
            }

            dst.BaseAddress = src.StartAddress;
            dst.MaxAddress = src.EndAddress;
            dst.Size = src.Size;
            dst.Protection = src.Protection;
            dst.Type = src.Type;
            dst.State = src.State;
            return dst;
        }
    }
}