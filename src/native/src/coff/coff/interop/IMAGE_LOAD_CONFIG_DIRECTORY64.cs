//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct IMAGE_LOAD_CONFIG_DIRECTORY64
    {
        public uint Size;

        public uint TimeDateStamp;

        public ushort MajorVersion;

        public ushort MinorVersion;

        public uint GlobalFlagsClear;

        public uint GlobalFlagsSet;

        public uint CriticalSectionDefaultTimeout;

        public ulong DeCommitFreeBlockThreshold;

        public ulong DeCommitTotalFreeThreshold;

        public ulong LockPrefixTable;

        public ulong MaximumAllocationSize;

        public ulong VirtualMemoryThreshold;

        public ulong ProcessAffinityMask;

        public uint ProcessHeapFlags;

        public ushort CSDVersion;

        public ushort DependentLoadFlags;

        public ulong EditList;

        public ulong SecurityCookie;

        public ulong SEHandlerTable;

        public ulong SEHandlerCount;

        public ulong GuardCFCheckFunctionPointer;

        public ulong GuardCFDispatchFunctionPointer;

        public ulong GuardCFFunctionTable;

        public ulong GuardCFFunctionCount;

        public uint GuardFlags;

        public IMAGE_LOAD_CONFIG_CODE_INTEGRITY CodeIntegrity;

        public ulong GuardAddressTakenIatEntryTable;

        public ulong GuardAddressTakenIatEntryCount;

        public ulong GuardLongJumpTargetTable;

        public ulong GuardLongJumpTargetCount;

        public ulong DynamicValueRelocTable;

        public ulong CHPEMetadataPointer;

        public ulong GuardRFFailureRoutine;

        public ulong GuardRFFailureRoutineFunctionPointer;

        public uint DynamicValueRelocTableOffset;

        public ushort DynamicValueRelocTableSection;

        public ushort Reserved2;

        public ulong GuardRFVerifyStackPointerFunctionPointer;

        public uint HotPatchTableOffset;

        public uint Reserved3;

        public ulong EnclaveConfigurationPointer;

        public ulong VolatileMetadataPointer;

        public ulong GuardEHContinuationTable;

        public ulong GuardEHContinuationCount;
    }
}