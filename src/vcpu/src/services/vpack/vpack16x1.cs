//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct vpack
{
    /// <summary>
    /// Packs 16 1-bit values taken from the least significant bit of each source byte
    /// </summary>
    /// <param name="src">The bit source</param>
    [MethodImpl(Inline), Op]
    public static ushort vpack16x1(Vector128<byte> src)
        => vpacklsb(src);
}
