//-----------------------------------------------------------------------------
// Author       : Chris Moore, 2020
// Source       : https://github.com/imneme/pcg-c
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

// Adapted from https://github.com/imneme/pcg-c
[ApiHost,Free]
public class Pcg
{
    /// <summary>
    /// Creates a pcg 64-bit rng
    /// </summary>
    /// <param name="s0">The initial state</param>
    /// <param name="index">The stream index</param>
    [MethodImpl(Inline), Op]
    public static Pcg32 pcg32(ulong s0, ulong? index = null)
        => new (s0,index);

    /// <summary>
    /// Creates a pcg 64-bit rng
    /// </summary>
    /// <param name="s0">The initial state</param>
    /// <param name="index">The stream index</param>
    [MethodImpl(Inline), Op]
    public static Pcg64 pcg64(ulong s0, ulong? index = null)
        => new (s0, index);

    /// <summary>
    /// Creates a 32-bit Pcg RNG
    /// </summary>
    /// <param name="seed">The initial rng state</param>
    /// <param name="index">The stream index, if any</param>
    [MethodImpl(Inline), Op]
    public static Pcg32 nav32(ulong? seed = null, ulong? index = null)
        => new (seed ?? PolySeed64.Seed00, index);

    /// <summary>
    /// Creates a 32-bit Pcg RNG
    /// </summary>
    /// <param name="seed">The initial rng state</param>
    /// <param name="index">The stream index, if any</param>
    [MethodImpl(Inline), Op]
    public static Pcg32 nav32()
        => new (PolySeed64.Seed00);

    /// <summary>
    /// Creates a 32-bit Pcg RNG suite predicated on spans of seeds and stream indices
    /// </summary>
    /// <param name="seeds">A span of seed values</param>
    /// <param name="indices">A span of index values</param>
    [MethodImpl(Inline), Op]
    public static Span<Pcg32> nav32Suite(Span<ulong> seeds, Span<ulong> indices)
    {
        var count = seeds.Length;
        var g = span<Pcg32>(count);
        for(var i=0; i<count; i++)
            seek(g,i) = nav32(skip(seeds,i), skip(indices,i));
        return g;
    }

    [MethodImpl(Inline), Op]
    public static ulong next(ref Pcg64 src)
        => grind64(step(ref src));

    [MethodImpl(Inline), Op]
    public static void retreat(ref Pcg64 src, ulong count)
        => src.Advance(gmath.negate(count));

    /// <summary>
    /// Advances the generator to the next state and returns the prior state for consumption
    /// </summary>
    [MethodImpl(Inline), Op]
    static ulong step(ref Pcg64 src)
    {
        var prior = src.State;
        src.State =  prior*Pcg64.Multiplier + src.Index;
        return prior;
    }

    /// <summary>
    /// Rotates bits in the source rightwards by a specified offset
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="offset">The magnitude of the rotation</param>
    [MethodImpl(Inline), Op]
    static uint rotr(uint src, uint offset)
        => (src >> (int)offset) | (src << (32 - (int)offset));

    /// <summary>
    /// Produces a pseudorandom output from a given source state
    /// </summary>
    /// <param name="state">The source state</param>
    /// <remarks>Follows the implementation of pcg_output_xsh_rr_64_32</remarks>
    [MethodImpl(Inline), Op]
    internal static uint grind32(ulong state)
    {
        var src = ((state >> 18) ^ state) >> 27;
        var dst = rotr((uint)src,(uint)(state >> 59));
        return dst;
    }

    /// <summary>
    /// Produces a pseudorandom output predicated on a state
    /// </summary>
    /// <param name="state">The source state</param>
    /// <remarks>Follows the implementation of pcg_output_rxs_m_xs_64_64</remarks>
    [MethodImpl(Inline), Op]
    internal static ulong grind64(ulong state)
    {
        var shift = (int) ((state >> 59) + 5);
        var src = ((state >> shift) ^ state) * 12605985483714917081ul;
        var dst = (src >> 43) ^ src;
        return dst;
    }

    public const ulong DefaultMultiplier = 6364136223846793005;

    public const ulong DefaultIndex = 1442695040888963407;

    [MethodImpl(Inline), Op]
    public static ulong advance(ulong state, ulong delta, ulong multiplier, ulong index)
    {
        ulong factor = 1u;
        ulong increment = 0u;
        while (delta > 0)
        {
            if ((delta & 1)  != 0)
            {
                factor *= multiplier;
                increment = increment * multiplier + index;
            }
            index = (multiplier + 1) * index;
            multiplier *= multiplier;
            delta /= 2;
        }
        return factor * state + increment;
    }

    [MethodImpl(Inline), Op]
    public static byte pcg_output_xsh_rs_16_8(ushort state)
        => (byte)(((state >> 7) ^ state) >> ((state >> 14) + 3));

    [MethodImpl(Inline), Op]
    public static ushort pcg_output_xsh_rs_32_16(uint state)
        => (ushort)(((state >> 11) ^ state) >> (int)((state >> 30) + 11));

    [MethodImpl(Inline), Op]
    public static uint pcg_output_xsh_rs_64_32(ulong state)
        => (uint)(((state >> 22) ^ state) >> (int)((state >> 61) + 22u));

    [MethodImpl(Inline), Op]
    public static ulong pcg_output_xsh_rs_128_64(UInt128 state)
        => (ulong)(((state >> 43) ^ state) >> (int)((state >> 124) + 45));

    [MethodImpl(Inline), Op]
    static byte pcg_rotr_8(byte src, int count)
        => math.rotr(src, (byte)count);

    [MethodImpl(Inline), Op]
    static ushort pcg_rotr_16(ushort src, int count)
        => math.rotr(src, (byte)count);

    [MethodImpl(Inline), Op]
    static uint pcg_rotr_32(uint src, int count)
        => math.rotr(src, (byte)count);

    [MethodImpl(Inline), Op]
    static ulong pcg_rotr_64(ulong src, int count)
        => math.rotr(src, (byte)count);

    [MethodImpl(Inline), Op]
    static UInt128 pcg_rotr_128(UInt128 src, int count)
        => math.rotr(src, (byte)count);

    [MethodImpl(Inline), Op]
    public static byte pcg_output_xsh_rr_16_8(ushort state)
        => pcg_rotr_8((byte)(((state >> 5) ^ state) >> 5), state >> 13);

    [MethodImpl(Inline), Op]
    public static ushort pcg_output_xsh_rr_32_16(uint state)
        => pcg_rotr_16((ushort)(((state >> 10) ^ state) >> 12), (byte)(state >> 28));

    [MethodImpl(Inline), Op]
    public static uint pcg_output_xsh_rr_64_32(ulong state)
        => pcg_rotr_32((uint)(((state >> 18) ^ state) >> 27), (byte)(state >> 59));

    [MethodImpl(Inline), Op]
    public static ulong pcg_output_xsh_rr_128_64(UInt128 state)
        => pcg_rotr_64((ulong)(((state >> 35) ^ state) >> 58), (byte)(state >> 122));

}
