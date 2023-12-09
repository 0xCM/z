//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// Shuffles the first four elements of the content vector with the lo mask and the last four elements with the hi mask
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="lo">The lo mask</param>
    /// <param name="hi">The hi mask</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vshuffle4x16(Vector128<short> src, [Imm] Arrange4L lo, [Imm] Arrange4L hi)
        => vshufflehi(vshufflelo(src,lo), hi);

    /// <summary>
    /// Shuffles the first four elements of the content vector with the lo mask and the last four elements with the hi mask
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="lo">The lo mask</param>
    /// <param name="hi">The hi mask</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vshuffle4x16(Vector128<ushort> src, [Imm] Arrange4L lo, [Imm] Arrange4L hi)
        => vshufflehi(vshufflelo(src,lo), hi);

    /// <summary>
    /// Shuffles lo/hi parts of each 128-bit lane as respectively determined by the shuffle specs
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="lo">The lo mask</param>
    /// <param name="hi">The hi mask</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vshuffle4x16(Vector256<short> src, [Imm] Arrange4L lo, [Imm] Arrange4L hi)
        => vshufflehi(vshufflelo(src,lo), hi);

    /// <summary>
    /// Shuffles lo/hi parts of each 128-bit lane as respectively determined by the shuffle specs
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="lo">The lo mask</param>
    /// <param name="hi">The hi mask</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vshuffle4x16(Vector256<ushort> src, [Imm] Arrange4L lo, [Imm] Arrange4L hi)
        => vshufflehi(vshufflelo(src,lo), hi);
}
