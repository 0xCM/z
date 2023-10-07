//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class bits
{
    /// <summary>
    /// Disables a specified source bit
    /// </summary>
    /// <param name="src">The source value to manipulate</param>
    /// <param name="pos">The position of the bit to disable</param>
    [MethodImpl(Inline), Disable]
    public static sbyte disable(sbyte src, int pos)
        => bit.disable(src, pos);

    /// <summary>
    /// Disables a specified source bit
    /// </summary>
    /// <param name="src">The source value to manipulate</param>
    /// <param name="pos">The position of the bit to disable</param>
    [MethodImpl(Inline), Disable]
    public static byte disable(byte src, int pos)
        => bit.disable(src, pos);

    /// <summary>
    /// Disables a specified source bit
    /// </summary>
    /// <param name="src">The source value to manipulate</param>
    /// <param name="pos">The position of the bit to disable</param>
    [MethodImpl(Inline), Disable]
    public static short disable(short src, int pos)
        => bit.disable(src, pos);

    /// <summary>
    /// Disables a specified source bit
    /// </summary>
    /// <param name="src">The source value to manipulate</param>
    /// <param name="pos">The position of the bit to disable</param>
    [MethodImpl(Inline), Disable]
    public static ushort disable(ushort src, int pos)
        => bit.disable(src, pos);

    /// <summary>
    /// Disables a specified source bit
    /// </summary>
    /// <param name="src">The source value to manipulate</param>
    /// <param name="pos">The position of the bit to disable</param>
    [MethodImpl(Inline), Disable]
    public static int disable(int src, int pos)
        => bit.disable(src, pos);

    /// <summary>
    /// Disables a specified source bit
    /// </summary>
    /// <param name="src">The source value to manipulate</param>
    /// <param name="pos">The position of the bit to disable</param>
    [MethodImpl(Inline), Disable]
    public static uint disable(uint src, int pos)
        => bit.disable(src, pos);

    /// <summary>
    /// Disables a specified source bit
    /// </summary>
    /// <param name="src">The source value to manipulate</param>
    /// <param name="pos">The position of the bit to disable</param>
    [MethodImpl(Inline), Disable]
    public static long disable(long src, int pos)
        => bit.disable(src, pos);

    /// <summary>
    /// Disables a specified source bit
    /// </summary>
    /// <param name="src">The source value to manipulate</param>
    /// <param name="pos">The position of the bit to disable</param>
    [MethodImpl(Inline), Disable]
    public static ulong disable(ulong src, int pos)
        => bit.disable(src, pos);

    /// <summary>
    /// Disables a specified source bit
    /// </summary>
    /// <param name="src">The source value to manipulate</param>
    /// <param name="pos">The position of the bit to disable</param>
    [MethodImpl(Inline), Disable]
    public static float disable(float src, int pos)
    {
        ref var bits = ref Unsafe.As<float,int>(ref src);
        var m = 1 << pos;
        bits &= ~m;
        return src;
    }

    /// <summary>
    /// Disables a specified source bit
    /// </summary>
    /// <param name="src">The source value to manipulate</param>
    /// <param name="pos">The position of the bit to disable</param>
    [MethodImpl(Inline), Disable]
    public static double disable(double src, int pos)
    {
        ref var bits = ref Unsafe.As<double,long>(ref src);
        var m = 1L << pos;
        bits &= ~m;
        return src;
    }
}
