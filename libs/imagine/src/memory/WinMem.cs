//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics;
    using Windows;

    [ApiHost]
    public readonly unsafe struct WinMem
    {
        const string Kernel = "kernel32.dll";

        public static SystemMemoryInfo system()
        {
            var src = new SYSTEM_INFO();
            Kernel32.GetSystemInfo(ref src);
            var dst = new SystemMemoryInfo();
            dst.PageSize = src.dwPageSize;
            dst.Granularity = src.dwAllocationGranularity;
            dst.MinAppAddress = src.lpMinimumApplicationAddress;
            dst.MaxAppAddress = src.lpMaximumApplicationAddress;
            return dst;
        }

        [Op]
        public static unsafe BasicMemoryInfo basic()
        {
            var src = new MEMORY_BASIC_INFORMATION();
            var dst = new BasicMemoryInfo();
            VirtualQuery(&src, ref src, new IntPtr(sizeof(MEMORY_BASIC_INFORMATION)));

            dst.AllocationBase = src.AllocationBase;
            dst.BaseAddress = src.BaseAddress;
            dst.RegionSize = src.RegionSize;
            dst.StackSize = (ulong)(dst.BaseAddress - dst.AllocationBase) + dst.RegionSize;
            dst.AllocProtect = (PageProtection)src.AllocationProtect;
            dst.Protection = (PageProtection)src.Protect;
            dst.State = src.State;
            dst.Type = src.Type;
            return dst;
        }

        /// <summary>
        /// Reserves, commits, or changes the state of a region of pages in the virtual address space of the calling process.
        /// Memory allocated by this function is automatically initialized to zero.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <param name="protect"></param>
        /// <remarks>
        /// https://docs.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-virtualalloc
        /// </remarks>
        [MethodImpl(Inline), Op]
        public static MemoryAddress valloc(ByteSize size, MemAllocType type, PageProtection protect)
            => VirtualAlloc(address: UIntPtr.Zero, size, type, protect);

        [MethodImpl(Inline), Op]
        public static unsafe bool vfree(MemoryAddress address, ByteSize size, MemFreeType type)
            => VirtualFree(address.Pointer(), (UIntPtr)size, type);

        /// <summary>
        /// Retrieves information about a range of pages in the virtual address space of the calling process
        /// </summary>
        /// <param name="base">A pointer to the base address of the region of pages to be queried. This value is rounded down to the next page boundary.</param>
        /// <param name="dst">The query result</param>
        /// <remarks>
        /// https://docs.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-virtualquery
        /// </remarks>
        [MethodImpl(Inline), Op]
        public static void vquery(MemoryAddress @base, ref BasicMemoryInfo dst)
            => VirtualQuery((IntPtr)@base, ref dst, (UIntPtr)Sized.size<BasicMemoryInfo>());

        /// <summary>
        /// Specifies the protection level for a page segment
        /// </summary>
        /// <param name="address"></param>
        /// <param name="size"></param>
        /// <param name="protect"></param>
        [MethodImpl(Inline), Op]
        public static bool vprotect(MemoryAddress address, ByteSize size, PageProtection protect)
            => VirtualProtect(address, size, protect, out var prior);

        /// <summary>
        /// Removes all protection from a page segment
        /// </summary>
        /// <param name="base">The segment base address</param>
        /// <param name="size">The segment size</param>
        [MethodImpl(Inline), Op]
        public static bool liberate(MemoryAddress @base, ByteSize size)
            => vprotect(@base,size, PageProtection.ExecuteReadWrite);

        [MethodImpl(Inline), Op]
        public static bool liberate(MemoryRange range)
            => vprotect(range.Min, range.ByteCount, PageProtection.ExecuteReadWrite);

        public static unsafe ulong ReadProcessMemory(IntPtr process, ulong address, Span<byte> dst)
        {
            try
            {
                fixed(byte* ptr = dst)
                {
                    int res = ReadProcessMemory(process, &address, ptr, new UIntPtr((uint)dst.Length), out UIntPtr read);
                    return (ulong)read;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static bool AllocateUserPhysicalPages(ref uint numberOfPages, UIntPtr pageArray)
        {
            var numberOfPagesRequested = new UIntPtr(numberOfPages);
            var res = AllocateUserPhysicalPages(Process.GetCurrentProcess().Handle, ref numberOfPagesRequested, pageArray);
            numberOfPages = numberOfPagesRequested.ToUInt32();
            return res;
        }

        public static bool MapUserPhysicalPages(UIntPtr virtualAddress, uint numberOfPages, UIntPtr pageArray)
        {
            UIntPtr numberOfPagesToMap = new UIntPtr(numberOfPages);
            return MapUserPhysicalPages(virtualAddress, numberOfPagesToMap, pageArray);
        }

        public static bool FreeUserPhysicalPages(ref uint numberfOfPages, UIntPtr pageArray)
        {
            UIntPtr numberOfPagesToFree = new UIntPtr(numberfOfPages);
            bool res = FreeUserPhysicalPages(Process.GetCurrentProcess().Handle, ref numberOfPagesToFree, pageArray);
            numberfOfPages = numberOfPagesToFree.ToUInt32();
            return res;
        }

        public static UIntPtr HeapAlloc(uint bytesRequested)
            => HeapAlloc(GetProcessHeap(), HeapFlags.None, new UIntPtr(bytesRequested));

        public static bool HeapFree(UIntPtr memory)
            => HeapFree(GetProcessHeap(), HeapFlags.None, memory);

        public static uint HeapSize(UIntPtr heapAddress)
        {
            UIntPtr heapSize = HeapSize(GetProcessHeap(), 0, heapAddress);
            return heapSize.ToUInt32();
        }

        [DllImport(Kernel, SetLastError = true), Free]
        public static extern IntPtr GetProcessHeap();

        [DllImport(Kernel, SetLastError = true), Free]
        static extern UIntPtr VirtualQuery(IntPtr address, ref BasicMemoryInfo lpBuffer, UIntPtr dwLength);

        /// <summary>
        /// Retrieves information about a range of pages within the virtual address space of a specified proces.
        /// The return value is the actual number of bytes returned in the information buffer.
        /// </summary>
        /// <param name="process"></param>
        /// <param name="address"></param>
        /// <param name="info"></param>
        /// <param name="size"></param>
        /// <remarks>
        /// https://docs.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-virtualqueryex
        /// </remarks>
        [DllImport(Kernel, SetLastError = true), Free]
        public static extern UIntPtr VirtualQueryEx(IntPtr process, IntPtr address, out BasicMemoryInfo info, UIntPtr size);

        [DllImport(Kernel, SetLastError = true), Free]
        public static extern bool VirtualProtectEx(IntPtr process, IntPtr address, UIntPtr size, PageProtection protect, out PageProtection prior);

        [DllImport(Kernel, SetLastError = true), Free]
        public static extern bool VirtualProtect(IntPtr address, UIntPtr size, PageProtection protect, out PageProtection prior);

        [DllImport(Kernel, SetLastError = true), Free]
        public static extern UIntPtr VirtualAlloc(UIntPtr address, UIntPtr size, MemAllocType type, PageProtection protect);

        [DllImport(Kernel, SetLastError = true), Free]
        [return: MarshalAs(UnmanagedType.Bool)]
        static unsafe extern bool VirtualFree(void* address, UIntPtr size, [MarshalAs(UnmanagedType.U4)] MemFreeType type);

        [DllImport(Kernel, SetLastError = true), Free]
        public static extern bool GetProcessWorkingSetSizeEx(IntPtr hProcess, out IntPtr minSize, out IntPtr maxSize, out WorkingSetFlags flags);

        [DllImport(Kernel)]
        static unsafe extern IntPtr VirtualQuery(void* address, ref MEMORY_BASIC_INFORMATION buffer, IntPtr length);

        [DllImport(Kernel, SetLastError = true), Free]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool HeapFree(IntPtr heapHandle, [MarshalAs(UnmanagedType.U4)] HeapFlags heapFlags, UIntPtr lpMem);

        [DllImport(Kernel), Free]
        static extern UIntPtr HeapAlloc(IntPtr heapHandle, [MarshalAs(UnmanagedType.U4)] HeapFlags heapFlags, UIntPtr bytesRequested);

        [DllImport(Kernel, SetLastError = true), Free]
        static extern UIntPtr HeapSize(IntPtr heap, uint flags, UIntPtr lpMem);

        [DllImport(Kernel, SetLastError = true), Free]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocateUserPhysicalPages(IntPtr processHandle, ref UIntPtr numberOfPages, UIntPtr pageArray);

        [DllImport(Kernel, SetLastError = true), Free]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool MapUserPhysicalPages(UIntPtr virtualAddress, UIntPtr numberOfPages, UIntPtr pageArray);

        [DllImport(Kernel, SetLastError = true), Free]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FreeUserPhysicalPages(IntPtr processHandle, ref UIntPtr numberOfPages, UIntPtr pageArray);

        /// <summary>
        /// Reads data from an area of memory in a specified process. The entire area to be read must be accessible or the operation fails.
        /// </summary>
        /// <param name="hProcess">A handle to the process with memory that is being read. The handle must have <see cref="ProcessAccess.PROCESS_VM_READ"/> access to the process.</param>
        /// <param name="lpBaseAddress">A pointer to the base address in the specified process from which to read. Before any data transfer occurs, the system verifies that all data in the base address and memory of the specified size is accessible for read access, and if it is not accessible the function fails.</param>
        /// <param name="lpBuffer">A pointer to a buffer that receives the contents from the address space of the specified process.</param>
        /// <param name="nSize">The number of bytes to be read from the specified process.</param>
        /// <param name="lpNumberOfBytesRead">A variable that receives the number of bytes transferred into the specified buffer.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is 0 (zero). To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// The function fails if the requested read operation crosses into an area of the process that is inaccessible.
        /// </returns>
        [DllImport(Kernel), Free]
        static unsafe extern int ReadProcessMemory(IntPtr hProcess, void* lpBaseAddress, byte* lpBuffer, UIntPtr dwSize, out UIntPtr lpNumberOfBytesRead);

        /// <summary>
        /// Writes data to an area of memory in a specified process. The entire area to be written to must be accessible or the operation fails.
        /// </summary>
        /// <param name="hProcess">A handle to the process memory to be modified. The handle must have <see cref="ProcessAccess.PROCESS_VM_WRITE"/> and <see cref="ProcessAccess.PROCESS_VM_OPERATION"/> access to the process.</param>
        /// <param name="lpBaseAddress">A pointer to the base address in the specified process to which data is written. Before data transfer occurs, the system verifies that all data in the base address and memory of the specified size is accessible for write access, and if it is not accessible, the function fails.</param>
        /// <param name="lpBuffer">A pointer to the buffer that contains data to be written in the address space of the specified process.</param>
        /// <param name="nSize">The number of bytes to be written to the specified process.</param>
        /// <param name="lpNumberOfBytesWritten">A variable that receives the number of bytes transferred into the specified process.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is 0 (zero). To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>. The function fails if the requested write operation crosses into an area of the process that is inaccessible.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool WriteProcessMemory(IntPtr hProcess, void* lpBaseAddress, byte* lpBuffer, UIntPtr nSize, out UIntPtr lpNumberOfBytesWritten);
   }
}