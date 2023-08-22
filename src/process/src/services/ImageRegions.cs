//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

[Free]
public class ImageRegions : Channeled<ImageRegions>
{
    public readonly ref struct Traverser
    {
        readonly ReadOnlySpan<ProcessMemoryRegion> Regions;

        readonly bool IsLive;

        [MethodImpl(Inline)]
        public Traverser(ReadOnlySpan<ProcessMemoryRegion> src, bool live)
        {
            Regions = src;
            IsLive = live;
        }

        [MethodImpl(Inline), Op]
        public ByteSize Traverse(IReceiver<ProcessMemoryRegion> dst)
        {
            var size = ByteSize.Zero;
            var src = Regions;
            var count = src.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var region = ref skip(src,i);
                dst.Deposit(region);
                size += region.Size;
            }
            return size;
        }

        [MethodImpl(Inline), Op]
        public unsafe ByteSize Traverse(delegate* unmanaged<in ProcessMemoryRegion,void> dst)
        {
            var size = ByteSize.Zero;
            var src = Regions;
            var count = src.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var region = ref skip(src,i);
                dst(region);
                size += region.Size;
            }
            return size;
        }
    }
}
