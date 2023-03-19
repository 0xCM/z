//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using Windows;

    public unsafe class PeFiles
    {
        public static bool test(MemorySeg src)
        {
            var result = *src.BaseAddress.Pointer<ushort>() == IMAGE_DOS_HEADER.MAGIC;
            if(result)
            {
                if(src.Size > 0x3C + 4)
                {
                    var offset = *(src.BaseAddress + PeSig.LocationOffset).Pointer<uint>();
                    var sig = *(src.BaseAddress + offset).Pointer<PeSig>();
                    result &= (sig == PeSig.Required);
                }
            }
            return result;
        }

        public static PeMemory pe(MemorySeg src)
            => new PeMemory(src);

        public static MetadataMemory metadata(MemorySeg src)  
            => new MetadataMemory(src);
    }   
}