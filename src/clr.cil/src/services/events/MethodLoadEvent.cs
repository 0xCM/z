//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct MethodLoadEvent
    {
        public const uint Keyword = 0x10;

        public const string EventName = "MethodLoadVerbose_V1";

        /// <summary>
        /// Unique identifier of the method. For JIT helper methods, set to the start address of the method
        /// </summary>
        public MemoryAddress MethodID;

        /// <summary>
        /// Identifier of the module to which this method belongs (0 for JIT helpers).
        /// </summary>
        public ulong ModuleID;

        public MemoryAddress MethodStartAddress;

        public Hex32 MethodSize;

        /// <summary>
        /// 0 for dynamic methods and JIT helpers.
        /// </summary>
        public EcmaToken MethodToken;

        public MethodFlag MethodFlags;

        /// <summary>
        /// Full namespace name associated with the method
        /// </summary>
        public string MethodNameSpace;

        /// <summary>
        /// Full class name associated with the method.
        /// </summary>
        public string MethodName;

        /// <summary>
        /// Signature of the method (comma-separated list of type names).
        /// </summary>
        public string MethodSignature;

        /// <summary>
        /// Unique ID for the instance of CLR or CoreCLR.
        /// </summary>
        public ushort ClrInstanceID;

        [Flags]
        public enum MethodFlag : byte
        {
            None = 0,

            /// <summary>
            /// Dynamic method
            /// </summary>
            Dynamic = 1,

            /// <summary>
            /// Generic method
            /// </summary>
            Generic = 2,

            /// <summary>
            /// JIT-compiled method
            /// </summary>
            JitCompiled = 4,

            /// <summary>
            /// Helper method
            /// </summary>
            Helper = 8,
        }
    }
}