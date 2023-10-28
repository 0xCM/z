//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct vpack
{
    /// <summary>
    /// Distributes each bit of the source to to a specified bit of each byte in a 256-bit target vector
    /// </summary>
    /// <param name="src">The source bits</param>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vinflate256x8u(uint src, byte index)
        => vunpack1x32(src,index);
}
