//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct SystemMemoryInfo
    {
        /// <summary>
        /// The page size and the granularity of page protection and commitment.
        /// </summary>
        public uint PageSize;

        /// <summary>
        /// Th lowest memory address accessible to applications and DLL's
        /// </summary>
        public MemoryAddress MinAppAddress;

        /// <summary>
        /// The highest memory address accessible to applications and DLL's
        /// </summary>
        public MemoryAddress MaxAppAddress;

        /// <summary>
        /// The granularity for the starting address at which virtual memory can be allocated
        /// </summary>
        public uint Granularity;
    }
}