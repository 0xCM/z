//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Bmi1;
    using static System.Runtime.Intrinsics.X86.Bmi1.X64;
    using static core;

    unsafe partial class Bytes
    {
        [MethodImpl(Inline), Op]
        public static void read4096(byte* pSrc, ref MemoryPage dst)
        {
            ReadLo(pSrc, ref dst);
            ReadHi(pSrc, ref dst);
        }

        [MethodImpl(Inline), Op]
        static void ReadLo(byte* pSrc, ref MemoryPage dst)
        {
            var pData = pSrc;
            var offset = z16;
            read2048(ref pData, ref dst, ref offset);
        }

        [MethodImpl(Inline), Op]
        static void ReadHi(byte* pSrc, ref MemoryPage dst)
        {
            const ushort Half = Root.PageSize/2;
            var pData = pSrc + Half;
            var offset = Half;
            read2048(ref pData, ref dst, ref offset);
        }

        [MethodImpl(Inline), Op]
        public static void read32(ref byte* pSrc, ref MemoryPage dst, ref ushort offset)
        {
            ref var target = ref u8(dst);
            cpu.vstore(cpu.vload(w256, pSrc), ref target, (int)offset);
            pSrc +=32;
            offset+= 32;
        }

        [MethodImpl(Inline), Op]
        public static void read64(ref byte* pSrc, ref MemoryPage dst, ref ushort offset)
        {
            read32(ref pSrc, ref dst, ref offset);
            read32(ref pSrc, ref dst, ref offset);
        }

        [MethodImpl(Inline), Op]
        public static void read128(ref byte* pSrc, ref MemoryPage dst, ref ushort offset)
        {
            read64(ref pSrc, ref dst, ref offset);
            read64(ref pSrc, ref dst, ref offset);
        }

        [MethodImpl(Inline), Op]
        public static void read256(ref byte* pSrc, ref MemoryPage dst, ref ushort offset)
        {
            read128(ref pSrc, ref dst, ref offset);
            read128(ref pSrc, ref dst, ref offset);
        }

        [MethodImpl(Inline), Op]
        public static void read512(ref byte* pSrc, ref MemoryPage dst, ref ushort offset)
        {
            read256(ref pSrc, ref dst, ref offset);
            read256(ref pSrc, ref dst, ref offset);
        }

        [MethodImpl(Inline), Op]
        public static void read1024(ref byte* pSrc, ref MemoryPage dst, ref ushort offset)
        {
            read512(ref pSrc, ref dst, ref offset);
            read512(ref pSrc, ref dst, ref offset);
        }

        [MethodImpl(Inline), Op]
        public static void read2048(ref byte* pSrc, ref MemoryPage dst, ref ushort offset)
        {
            read1024(ref pSrc, ref dst, ref offset);
            read1024(ref pSrc, ref dst, ref offset);
        }
    }
}