//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    using static Windows.Kernel32;
    using static Algs;
    using static Spans;

    [ApiHost]
    public unsafe readonly partial struct MemorySections
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        public static ReadOnlySpan<T> view<T>(MemorySeg src)
            where T : unmanaged
                => Algs.cover(src.BaseAddress.Ref<T>(), capacity<T>(src));

        [MethodImpl(Inline)]
        public static uint capacity<T>(MemorySeg src)
            where T : unmanaged
                => (uint)(src.Length/size<T>());

        [MethodImpl(Inline), Op]
        public static Span<T> edit<T>(MemoryRange src)
            where T : unmanaged
                => Algs.cover(src.Min.Ref<T>(), capacity<T>(src));

        [MethodImpl(Inline)]
        public static MemoryRange range(MemoryAddress min, MemoryAddress max)
            => new MemoryRange(min,max);

        [MethodImpl(Inline)]
        public static MemoryRange range(MemoryAddress min, ByteSize size)
            => new MemoryRange(min, size);

        [MethodImpl(Inline), Op]
        static MemoryAddress liberate(MemoryAddress src, ulong length)
             => VirtualProtectEx(CurrentProcess.ProcessHandle, src, (UIntPtr)(ulong)length, PageProtection.ExecuteReadWrite, out var _) ? src : MemoryAddress.Zero;

        [MethodImpl(Inline), Op]
        public static Descriptor descriptor(in Section src)
            => new Descriptor(src.Index, src.Base(), src.Capacity());

        [MethodImpl(Inline)]
        public static Section<T> section<T>(in T src)
            where T : unmanaged, IMemorySection<T>
                => new Section<T>(src.Index, src.Base(), src.Capacity());

        [MethodImpl(Inline)]
        public static bool dispense<T>(T src, ushort id, out Section dst)
            where T : ISectionDispenser<T>
        {
            dst = src.Entry(id);
            return dst.IsNonEmpty;
        }

        [MethodImpl(Inline)]
        public static uint dispense<T>(T src, out ReadOnlySpan<Section> dst)
            where T : ISectionDispenser<T>
        {
            dst = src.Entries();
            return src.EntryCount;
        }

        [Op]
        public static ref readonly Section initialize(in Section section)
        {
            liberate(section.Base(), (ulong)section.TotalSize);
            return ref section;
        }

        /// <summary>
        /// Specifies a capacity predicated on a cell size, the number of cells in a segment, the block count and a segment scale factor
        /// </summary>
        /// <param name="cellsize">The cell size</param>
        /// <param name="blocks">The number of covered blocks</param>
        /// <param name="blocksegs">The numberr of cells in a block</param>
        /// <param name="segcells">The number of cells per segment</param>
        [MethodImpl(Inline), Op]
        public static Capacity capacity(ushort cellsize, uint blocks, byte blocksegs, uint segcells)
            => new Capacity(cellsize, blocks, blocksegs, segcells);

        [MethodImpl(Inline), Op]
        public static Span<byte> cells(in Section src)
            => cover(src.Base().Pointer<byte>(), src.TotalSize);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(in Section src)
            where T : unmanaged
                => cover(src.Base().Pointer<T>(), src.TotalSize/size<T>());

        [MethodImpl(Inline), Op]
        public static ref byte cell(in Section src, uint index)
        {
            var pBase = src.Base().Pointer<byte>();
            pBase += index;
            return ref @ref<byte>(pBase);
        }

        [MethodImpl(Inline), Op]
        public static Span<byte> segment(in Section src, uint index)
        {
            var pBase = src.Base().Pointer<byte>();
            var unit = src.SegSize;
            var offset = index*unit;
            pBase += offset;
            return cover(pBase, unit);
        }

        [MethodImpl(Inline), Op]
        public static Span<byte> block(in Section src, uint index)
        {
            var pBase = src.Base().Pointer<byte>();
            var unit = src.BlockSize;
            var offset = index*unit;
            pBase += offset;
            return cover(pBase, unit);
        }

        /// <summary>
        /// {CellSize}x{SegSize}x{SegsPerBlock}x{BlockCount}
        /// </summary>
        /// <param name="src"></param>
        [Op]
        public static string format(in CapacityIndicator src)
            => string.Format("{0}x{1}x{2}x{3}", src.CellSize, src.SegSize, src.SegsPerBlock, src.BlockCount);

        [Op]
        public static string format(in Descriptor src)
            => string.Format("{0} {1}{2}", src.Index, src.AddressRange, src.Capacity);
    }
}