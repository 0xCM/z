//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;

    [ApiClass, SymSource(api_classes)]
    public enum ApiMemoryClass : ushort
    {
        None = 0,

        /// <summary>
        /// Identifies operations that allocate memory/resources
        /// </summary>
        Alloc = ApiClassKind.Alloc,

        /// <summary>
        /// Identifies an operation that accepts a memory buffer, such as a memory segmented covered by an S-span,
        /// and returns the buffer unaltered but with an alternate presentation, such as a T-span
        /// </summary>
        Recover = ApiClassKind.Recover,

        MemAdd = ApiClassKind.MemAdd,

        MemSub = ApiClassKind.MemSub,
    }
}