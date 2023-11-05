//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static LimitValues;
using static TaggedLiterals;
using static bits;

partial struct Bitfields
{
    /// <summary>
    /// Creates a mask that covers an inclusive range of bits
    /// </summary>
    /// <param name="w">The target width selector</param>
    /// <param name="i0">The position of the first bit</param>
    /// <param name="i1">The position of the last bit</param>
    [MethodImpl(Inline), Enable]
    public static byte ones(W8 w, byte i0, byte i1)
        => math.sll(zhi(max(w), segwidth(i0,i1)), i0);

    /// <summary>
    /// Creates a mask that covers an inclusive range of bits
    /// </summary>
    /// <param name="w">The target width selector</param>
    /// <param name="i0">The position of the first bit</param>
    /// <param name="i1">The position of the last bit</param>
    [MethodImpl(Inline), Enable]
    public static ushort ones(W16 w, byte i0, byte i1)
        => math.sll(zhi(max(w), segwidth(i0,i1)), i0);

    /// <summary>
    /// Creates a mask that covers an inclusive range of bits
    /// </summary>
    /// <param name="w">The target width selector</param>
    /// <param name="i0">The position of the first bit</param>
    /// <param name="i1">The position of the last bit</param>
    [MethodImpl(Inline), Enable]
    public static uint ones(W32 w, byte i0, byte i1)
        => math.sll(zhi(max(w), segwidth(i0,i1)), i0);

    /// <summary>
    /// Creates a mask that covers an inclusive range of bits
    /// </summary>
    /// <param name="w">The target width selector</param>
    /// <param name="i0">The position of the first bit</param>
    /// <param name="i1">The position of the last bit</param>
    [MethodImpl(Inline), Enable]
    public static ulong ones(W64 w, byte i0, byte i1)
        => math.sll(zhi(max(w), segwidth(i0,i1)), i0);

    [MethodImpl(Inline), Op]
    public static BitMask one(byte width, byte pos)
        => bit.enable(0ul,pos);
}