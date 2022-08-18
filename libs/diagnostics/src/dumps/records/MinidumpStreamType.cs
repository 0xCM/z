//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct MinidumpRecords
    {
        // The MINIDUMP_DIRECTORY field StreamType may be one of the following types.
        // Types will be added in the future, so if a program reading the minidump
        // header encounters a stream type it does not understand it should ignore
        // the data altogether. Any tag above LastReservedStream will not be used by
        // the system and is reserved for program-specific information.
        // From minidumpapiset.h
        public enum MinidumpStreamType : uint
        {
            UnusedStream = 0,

            ReservedStream0 = 1,

            ReservedStream1 = 2,

            ThreadListStream = 3,

            ModuleListStream = 4,

            MemoryListStream = 5,

            ExceptionStream = 6,

            SystemInfoStream = 7,

            ThreadExListStream = 8,

            Memory64ListStream = 9,

            CommentStreamA = 10,

            CommentStreamW = 11,

            HandleDataStream = 12,

            FunctionTableStream = 13,

            UnloadedModuleListStream = 14,

            MiscInfoStream = 15,

            MemoryInfoListStream = 16,

            ThreadInfoListStream = 17,

            HandleOperationListStream = 18,

            TokenStream = 19,

            JavaScriptDataStream = 20,

            SystemMemoryInfoStream = 21,

            ProcessVmCountersStream = 22,

            IptTraceStream = 23,

            ThreadNamesStream = 24,

            ceStreamNull = 0x8000,

            ceStreamSystemInfo = 0x8001,

            ceStreamException  = 0x8002,

            ceStreamModuleList = 0x8003,

            ceStreamProcessList = 0x8004,

            ceStreamThreadList = 0x8005,

            ceStreamThreadContextList = 0x8006,

            ceStreamThreadCallStackList = 0x8007,

            ceStreamMemoryVirtualList = 0x8008,

            ceStreamMemoryPhysicalList = 0x8009,

            ceStreamBucketParameters = 0x800A,

            ceStreamProcessModuleMap = 0x800B,

            ceStreamDiagnosisList = 0x800C,

            LastReservedStream = 0xffff
        }
    }
}