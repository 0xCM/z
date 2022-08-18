//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Retrieves, at most, one cell's worth of bits defined by an inclusive bit index range
        /// </summary>
        /// <param name="i0">The linear index of the first bit</param>
        /// <param name="i1">The linear index of the last bit</param>
        [MethodImpl(Inline)]
        public static T BitSeg<T>(this Span<T> src, uint i0, uint i1)
            where T : unmanaged
                => gbits.extract(src, i0, i1);
    }
}