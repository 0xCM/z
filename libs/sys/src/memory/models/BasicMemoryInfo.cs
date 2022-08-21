//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public record struct BasicMemoryInfo
    {
        public const string TableId = "memory.basic";

        /// <summary>
        /// A pointer to the base address of the region of pages
        /// </summary>
        public MemoryAddress BaseAddress;

        /// <summary>
        /// A pointer to the base address of a range of pages allocated by the VirtualAlloc function. 
        /// The page pointed to by the BaseAddress member is contained within this allocation range.
        /// </summary>
        public MemoryAddress AllocationBase;

        /// <summary>
        /// The size of the region beginning at the base address in which all pages have identical attributes, in bytes.
        /// </summary>
        public ByteSize RegionSize;

        public ByteSize StackSize;

        public PageProtection AllocProtect;

        public PageProtection Protection;

        public MemState State;

        public MemType Type;

        public static BasicMemoryInfo Empty => default;
    }
}