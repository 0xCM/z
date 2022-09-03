//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ClrMdRecords
    {
        /// <summary>
        /// Shape derived from https://github.com/microsoft/clrmd/src/Microsoft.Diagnostics.Runtime/src/DacInterface/Structs/MethodDescData.cs
        /// </summary>
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public record struct MethodInfo
        {
            public const string TableId = "diagnostic.methods";

            public readonly bit HasNativeCode;

            public readonly bit IsDynamic;

            public readonly ushort SlotNumber;

            public readonly MemoryAddress NativeCodeAddr;

            public readonly MemoryAddress AddressOfNativeCodeSlot;

            public readonly MemoryAddress MethodDesc;

            public readonly MemoryAddress MethodTable;

            public readonly MemoryAddress Module;

            public readonly CliToken MetadataToken;

            public readonly MemoryAddress GCInfo;

            public readonly MemoryAddress GCStressCodeCopy;

            // This is only valid if bIsDynamic is true
            public readonly MemoryAddress ManagedDynamicMethodObject;

            public readonly MemoryAddress RequestedIP;

            // Gives info for the single currently active version of a method
            public readonly RejitInfo RejitDataCurrent;

            // Gives info corresponding to requestedIP (for !ip2md)
            public readonly RejitInfo RejitDataRequested;

            // Total number of rejit versions that have been jitted
            public readonly uint JittedRejitVersions;
        }
    }
}