//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct IMAGE_LOAD_CONFIG_DIRECTORY32
    {
        public uint Size;

        public uint TimeDateStamp;

        public ushort MajorVersion;

        public ushort MinorVersion;

        public uint GlobalFlagsClear;

        public uint GlobalFlagsSet;

        public uint CriticalSectionDefaultTimeout;

        public uint DeCommitFreeBlockThreshold;

        public uint DeCommitTotalFreeThreshold;

        public uint LockPrefixTable;

        public uint MaximumAllocationSize;

        public uint VirtualMemoryThreshold;

        public uint ProcessHeapFlags;

        public uint ProcessAffinityMask;

        public ushort CSDVersion;

        public ushort DependentLoadFlags;

        public uint EditList;

        public uint SecurityCookie;

        public uint SEHandlerTable;

        public uint SEHandlerCount;

        public uint GuardCFCheckFunctionPointer;

        public uint GuardCFDispatchFunctionPointer;

        public uint GuardCFFunctionTable;

        public uint GuardCFFunctionCount;

        public uint GuardFlags;

        public IMAGE_LOAD_CONFIG_CODE_INTEGRITY CodeIntegrity;

        public uint GuardAddressTakenIatEntryTable;

        public uint GuardAddressTakenIatEntryCount;

        public uint GuardLongJumpTargetTable;

        public uint GuardLongJumpTargetCount;

        public uint DynamicValueRelocTable;

        public uint CHPEMetadataPointer;

        public uint GuardRFFailureRoutine;

        public uint GuardRFFailureRoutineFunctionPointer;

        public uint DynamicValueRelocTableOffset;

        public ushort DynamicValueRelocTableSection;

        public ushort Reserved2;

        public uint GuardRFVerifyStackPointerFunctionPointer;

        public uint HotPatchTableOffset;

        public uint Reserved3;

        public uint EnclaveConfigurationPointer;

        public uint VolatileMetadataPointer;

        public uint GuardEHContinuationTable;

        public uint GuardEHContinuationCount;
    }
}