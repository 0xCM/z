//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static System.Runtime.Intrinsics.Vector128;
using static System.Runtime.Intrinsics.Vector256;

partial class vcpu
{
    /// <summary>
    /// Defines a 256-bit vector by explicit component specification, from least -> most significant
    /// </summary>
    /// <param name="w">The vector width selector</param>
    [MethodImpl(Inline),Op]
    public static Vector256<byte> vparts(W256 w,
        byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7,
        byte x8, byte x9, byte xa, byte xb, byte xc, byte xd, byte xe, byte xf,
        byte x10, byte x11, byte x12, byte x13, byte x14, byte x15, byte x16, byte x17,
        byte x18, byte x19, byte x1a, byte x1b, byte x1c, byte x1d, byte x1e, byte x1f)
            => Create(x0,x1,x2,x3,x4,x5,x6, x7,x8,x9,xa,xb,xc,xd,xe,xf,
                    x10,x11,x12,x13,x14,x15, x16,x17,x18,x19,x1a,x1b,x1c,x1d,x1e,x1f);

    /// <summary>
    /// Defines a 256-bit vector by explicit component specification, from least -> most significant
    /// </summary>
    /// <param name="w">The vector width selector</param>
    [MethodImpl(Inline),Op]
    public static Vector256<sbyte> vparts(W256i w,
        sbyte x0, sbyte x1, sbyte x2, sbyte x3, sbyte x4, sbyte x5, sbyte x6, sbyte x7,
        sbyte x8, sbyte x9, sbyte xa, sbyte xb, sbyte xc, sbyte xd, sbyte xe, sbyte xf,
        sbyte x10, sbyte x11, sbyte x12, sbyte x13, sbyte x14, sbyte x15, sbyte x16, sbyte x17,
        sbyte x18, sbyte x19, sbyte x1a, sbyte x1b, sbyte x1c, sbyte x1d, sbyte x1e, sbyte x1f)
            => Create(x0,x1,x2,x3,x4,x5,x6, x7,x8,x9,xa,xb,xc,xd,xe,xf,
                x10,x11,x12,x13,x14,x15, x16,x17,x18,x19,x1a,x1b,x1c,x1d,x1e,x1f);

    /// <summary>
    /// Defines a 256-bit vector by explicit component specification, from least -> most significant
    /// </summary>
    /// <param name="w">The vector width selector</param>
    [MethodImpl(Inline),Op]
    public static Vector256<ushort> vparts(W256 w,
        ushort x0, ushort x1, ushort x2, ushort x3, ushort x4, ushort x5, ushort x6, ushort x7,
        ushort x8, ushort x9, ushort xA, ushort xB, ushort xC, ushort xD, ushort xE, ushort xF)
            => Create(x0,x1, x2, x3, x4, x5, x6, x7,x8,x9,xA,xB,xC,xD,xE,xF);

    /// <summary>
    /// Defines a 256-bit vector by explicit component specification, from least -> most significant
    /// </summary>
    /// <param name="w">The vector width selector</param>
    [MethodImpl(Inline),Op]
    public static Vector256<short> vparts(W256i w,
        short x0, short x1, short x2, short x3, short x4, short x5, short x6, short x7,
        short x8, short x9, short xA, short xB, short xC, short xD, short xE, short xF)
            => Create(x0,x1, x2, x3, x4, x5, x6, x7,x8,x9,xA,xB,xC,xD,xE,xF);

    /// <summary>
    /// Defines a 256-bit vector by explicit component specification, from least -> most significant
    /// </summary>
    /// <param name="w">The vector width selector</param>
    [MethodImpl(Inline),Op]
    public static Vector256<int> vparts(W256i w, int x0, int x1, int x2, int x3, int x4, int x5, int x6, int x7)
        => Vector256.Create(x0,x1,x2,x3,x4,x5,x6,x7);

    /// <summary>
    /// Defines a 256-bit vector by explicit component specification, from least -> most significant
    /// </summary>
    /// <param name="w">The vector width selector</param>
    [MethodImpl(Inline),Op]
    public static Vector256<uint> vparts(uint x0, uint x1, uint x2, uint x3, uint x4, uint x5, uint x6, uint x7)
        => Create(x0, x1, x2, x3, x4, x5, x6, x7);

    /// <summary>
    /// Defines a 256-bit vector by explicit component specification, from least -> most significant
    /// </summary>
    /// <param name="w">The vector width selector</param>
    [MethodImpl(Inline),Op]
    public static Vector256<uint> vparts(W256 w,uint x0, uint x1, uint x2, uint x3, uint x4, uint x5, uint x6, uint x7)
        => Create(x0, x1, x2, x3, x4, x5, x6, x7);

    /// <summary>
    /// Defines a 256-bit vector by explicit component specification, from least -> most significant
    /// </summary>
    /// <param name="w">The vector width selector</param>
    [MethodImpl(Inline),Op]
    public static Vector256<long> vparts(W256i w, long x0, long x1, long x2, long x3)
        => Create(x0,x1,x2,x3);

    /// <summary>
    /// Defines a 256-bit vector by explicit component specification, from least -> most significant
    /// </summary>
    /// <param name="w">The vector width selector</param>
    [MethodImpl(Inline),Op]
    public static Vector256<ulong> vparts(W256 w, ulong x0, ulong x1, ulong x2, ulong x3)
        => Create(x0,x1,x2,x3);

    /// <summary>
    /// Defines a 256-bit vector by explicit component specification, from least -> most significant
    /// </summary>
    /// <param name="w">The vector width selector</param>
    [MethodImpl(Inline),Op]
    public static Vector256<float> vparts(W256 w, float x0, float x1, float x2, float x3, float x4, float x5, float x6, float x7)
        => Create(x0,x1,x2,x3,x4,x5,x6,x7);

    /// <summary>
    /// Defines a 256-bit vector by explicit component specification, from least -> most significant
    /// </summary>
    /// <param name="w">The vector width selector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vparts(W256 w, double x0, double x1, double x2, double x3)
        => Create(x0, x1, x2, x3);
}
