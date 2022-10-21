//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XVK
    {
        /// <summary>
        /// Returns the clr cell type of a vector of specified kind
        /// </summary>
        /// <param name="kind">The vector kind</param>
        [MethodImpl(Inline), Op]
        public static Type CellType(this NativeVectorKind kind)
            => VK.celltype(kind);
    }
}