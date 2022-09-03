//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class ClrInternals
    {
        // public static void check(WfEventLogger log)
        // {
        //     var src = typeof(math);
        //     var table = ClrInternals.methods(src);
        //     var eec = ClrInternals.eeclass(table);
        //     var c0 = ClrInternals.chunk(eec);
        //     var c1 = ClrInternals.next(c0);
        //     var c2 = ClrInternals.next(c1);
        //     var c3 = ClrInternals.next(c2);
        //     log(Events.data(c0));
        //     log(Events.data(c1));
        //     log(Events.data(c2));
        //     log(Events.data(c3));
        // }
        // public static void Introspect(Type src)
        // {
        //     var t = typeof(System.String);
        //     var mt = Marshal.PtrToStructure<MethodTable>(t.TypeHandle.Value);
        //     var ec = Marshal.PtrToStructure<EEClass>(mt.m_pEEClass);
        //     var mdc = Marshal.PtrToStructure<MethodDescChunk>(ec.m_pChunks);
        //     var md = Marshal.PtrToStructure<MethodDesc>((IntPtr)ec.m_pChunks + 0x18);

        // }

        public static MethodTable methods(Type src)
            => Marshal.PtrToStructure<MethodTable>(src.TypeHandle.Value);

        public static EEClass eeclass(in MethodTable src)
            => Marshal.PtrToStructure<EEClass>(src.m_pEEClass);

        public static MethodDescChunk chunk(in EEClass src)
            => Marshal.PtrToStructure<MethodDescChunk>((IntPtr)src.m_pChunks);

        public static MethodDescChunk next(in MethodDescChunk src)
            => Marshal.PtrToStructure<MethodDescChunk>(src.m_next);

        [StructLayout(LayoutKind.Explicit)]
        public record struct MethodTable
        {
            [FieldOffset(0)]
            public uint m_dwFlags;

            [FieldOffset(0x4)]
            public uint m_BaseSize;

            [FieldOffset(0x8)]
            public ushort m_wFlags2;

            [FieldOffset(0x0a)]
            public ushort m_wToken;

            [FieldOffset(0x0c)]
            public ushort m_wNumVirtuals;

            [FieldOffset(0x0e)]
            public ushort m_wNumInterfaces;

            [FieldOffset(0x10)]
            public Ptr m_pParentMethodTable;

            [FieldOffset(0x18)]
            public Ptr m_pLoaderModule;

            [FieldOffset(0x20)]
            public Ptr m_pWriteableData;

            [FieldOffset(0x28)]
            public Ptr m_pEEClass;

            [FieldOffset(0x30)]
            public Ptr m_pPerInstInfo;

            [FieldOffset(0x38)]
            public Ptr m_pInterfaceMap;
        }

        [StructLayout(LayoutKind.Explicit)]
        public record struct EEClass
        {
            [FieldOffset(0)]
            public Ptr m_pGuidInfo;

            [FieldOffset(0x8)]
            public Ptr m_rpOptionalFields;

            [FieldOffset(0x10)]
            public Ptr m_pMethodTable;

            [FieldOffset(0x18)]
            public Ptr m_pFieldDescList;

            [FieldOffset(0x20)]
            public Ptr m_pChunks;
        }

        [StructLayout(LayoutKind.Explicit)]
        public record struct MethodDescChunk
        {
            [FieldOffset(0)]
            public Ptr m_methodTable;

            [FieldOffset(8)]
            public Ptr m_next;

            [FieldOffset(0x10)]
            public byte m_size;

            [FieldOffset(0x11)]
            public byte m_count;

            [FieldOffset(0x12)]
            public byte m_flagsAndTokenRange;
        }

        [StructLayout(LayoutKind.Explicit)]
        public record struct MethodDesc
        {
            [FieldOffset(0)]
            public ushort m_wFlags3AndTokenRemainder;

            [FieldOffset(2)]
            public byte m_chunkIndex;

            [FieldOffset(0x3)]
            public byte m_bFlags2;

            [FieldOffset(0x4)]
            public ushort m_wSlotNumber;

            [FieldOffset(0x6)]
            public ushort m_wFlags;

            [FieldOffset(0x8)]
            public Ptr TempEntry;
        }

        public const int mdcHasNonVtableSlot = 0x0008;

        public const int mdcHasNativeCodeSlot = 0x0020;

        [Flags]
        public enum AllocationType
        {
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            Physical = 0x400000,
            TopDown = 0x100000,
            WriteWatch = 0x200000,
            LargePages = 0x20000000
        }

        [Flags]
        public enum MemoryProtection
        {
            Execute = 0x10,
            ExecuteRead = 0x20,
            ExecuteReadWrite = 0x40,
            ExecuteWriteCopy = 0x80,
            NoAccess = 0x01,
            ReadOnly = 0x02,
            ReadWrite = 0x04,
            WriteCopy = 0x08,
            GuardModifierflag = 0x100,
            NoCacheModifierflag = 0x200,
            WriteCombineModifierflag = 0x400
        }
    }
}