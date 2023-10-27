//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct vpack
{
    /// <summary>
    /// Packs 16 1-bit values taken from each source byte at a specified index
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="index">The byte-relative index from which the bit will be extracted, an integer in the range [0,7]</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static ushort vpack16u<T>(Vector128<T> src, byte index)
        where T : unmanaged
            => vgcpu.vmask16u(src, index);
}
