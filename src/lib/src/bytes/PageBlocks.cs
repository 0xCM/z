//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public unsafe readonly struct PageBlocks
    {
        /// <summary>
        /// Windows page size = 4096 bytes
        /// </summary>
        public const uint PageSize = MemoryPage.PageSize;

        [MethodImpl(Inline), Op]
        public static PageBlockInfo describe(MemoryPage src)
            => new PageBlockInfo(src.Range);

        // [MethodImpl(Inline)]
        // public static MemoryCells<T> cells<T>(MemoryPage src)
        //     where T : unmanaged
        //         => new MemoryCells<T>(src.Range);

        [MethodImpl(Inline)]
        public static void alloc(out PageBlock16x4 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline)]
        public static void alloc(out PageBlock128 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline)]
        public static void alloc(out PageBlock256 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline)]
        public static uint PageCount<T>()
            where T : unmanaged, IPageBlock<T>
                => size<T>()/PageSize;

        [MethodImpl(Inline), Op]
        public static void Read(byte* pSrc, ref MemoryPage dst)
            => Bytes.read4096(pSrc, ref dst);
   }
}